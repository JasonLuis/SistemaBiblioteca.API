using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

public class AuthService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(SignInManager<IdentityUser> signInManager,
                       UserManager<IdentityUser> userManager,
                       IOptions<JwtSettings> jwtSettings)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<string?> Register(RegisterDTO registerDTO)
    {
        var user = new IdentityUser
        {
            UserName = registerDTO.Email,
            Email = registerDTO.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, registerDTO.Senha);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return await GerarJwt(user.Email);
        }

        throw new Exception("Falha ao registrar usuário.");
    }
    

    private async Task<string> GerarJwt(string email)
    {
        var user = await _userManager.FindByEmailAsync(email); // busca o usuário pelo email
        var roles = await _userManager.GetRolesAsync(user); // busca as roles do usuário
        
        var claims = new List<Claim> // cria os claims do usuário
        {
            new Claim(ClaimTypes.Name, user.UserName), // nome do usuário

        };

        foreach (var role in roles) // percorre as roles
        {
            claims.Add(new Claim(ClaimTypes.Role, role)); // adiciona a role do usuário
        }

        var tokenHandler = new JwtSecurityTokenHandler(); // cria o manipulador de tokens JWT
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret); // converte a chave secreta para bytes

        var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims), // adiciona os claims ao token
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        });

        var encondedToken = tokenHandler.WriteToken(token); // transforma o token em string

        return encondedToken; // retorna o token
    }
}