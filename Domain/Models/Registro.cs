using Microsoft.AspNetCore.Identity;

public class Registro : IdentityUser
{
    public string Email { get; set; }
    public string Senha { get; set; }
    
}