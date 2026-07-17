using Microsoft.AspNetCore.Mvc;

namespace SistemaBiblioteca.API.Controllers;

[ApiController]
//[Route("[controller]")]
[Route("api/Livros")]
public class LivroController : ControllerBase
{
    private readonly BibliotecaService _bibliotecaService;

    public LivroController(BibliotecaService bibliotecaService)
    {
        _bibliotecaService = bibliotecaService;
    }

    [HttpGet(Name = "GetAllLivros")]
    public async Task<IActionResult> GetAllLivros()
    {   

        try
        {
            var livros = await _bibliotecaService.GetAllLivrosAsync();

            if(livros == null) return NotFound();
            
            return Ok(livros);   
        } catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao obter livros");
        }
        
    }

    [HttpGet("{id:int}", Name = "GetLivroById")]
    public async Task<IActionResult> GetLivroById(int id)
    {

        try
        {
            var livro = await _bibliotecaService.LivrosByIdAsync(id);
            
            if(livro == null) return NotFound();    

            return Ok(livro);
        } catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao obter livro com id {id}");
        }
    }

    [HttpPost("AddLivro")]
    public async Task<IActionResult> AddLivro( CreateLivroDTO livro) 
    {
        try
        {
            var newLivro = new Livro
            {
                Titulo = livro.Titulo,
                Autor = livro.Autor,
                CodigoLivro = livro.CodigoLivro,
                Disponivel = true
            };

            await _bibliotecaService.AddLivroAsync(newLivro);

            return CreatedAtRoute("GetLivroById", new { id = newLivro.Id }, newLivro);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao adicionar livro");
        }
    }
}
