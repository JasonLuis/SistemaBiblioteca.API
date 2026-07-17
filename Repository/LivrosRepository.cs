using Microsoft.EntityFrameworkCore;

public class LivrosRepository : ILivroRepository
{
    private readonly AppDbContext _context;

    public LivrosRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddLivroAsync(Livro livro)
    {
        await _context.Livro.AddAsync(livro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteLivroAsync(int id)
    {
        var livro = await _context.Livro.FindAsync(id);
        if (livro != null)
        {
            _context.Livro.Remove(livro);
            await _context.SaveChangesAsync();
        }

        throw new Exception("Livro not found");
    }

    public async Task<List<Livro>> GetAllLivrosAsync()
    {
       var livros = await _context.Livro.ToListAsync();
       return livros;
    }

    public async Task<Livro?> GetLivroByIdAsync(int id)
    {
        return await _context.Livro.FirstOrDefaultAsync(l => l.Id == id);
    }

    public Task UpdateLivroAsync(Livro livro)
    {
        var existingLivro = _context.Livro.FirstOrDefault(l => l.Id == livro.Id);
        if (existingLivro != null)
        {
            existingLivro.Titulo = livro.Titulo;
            existingLivro.Autor = livro.Autor;
            existingLivro.CodigoLivro = livro.CodigoLivro;
            existingLivro.Disponivel = livro.Disponivel;
            _context.Livro.Update(existingLivro);

            return _context.SaveChangesAsync();
        }

        throw new Exception("Livro not found");
    }


}