
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/Auth")]
public class AuthController: ControllerBase
{
    
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var token = await _authService.Register(registerDTO);
            return Ok(token);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao registrar usuário: {ex.Message}");
        }
    }
}