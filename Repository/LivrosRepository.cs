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

    public async Task DeleteLivroAsync(Livro livro)
    {
        _context.Livro.Remove(livro);
        await _context.SaveChangesAsync();
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

    public async Task UpdateLivroAsync(Livro livro)
    {
        _context.Livro.Update(livro);
        await _context.SaveChangesAsync();
    }


}