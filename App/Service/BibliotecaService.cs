public class BibliotecaService
{
    private readonly ILivroRepository _livrosRepository;

    public BibliotecaService(ILivroRepository livrosRepository)
    {
        _livrosRepository = livrosRepository;
    }

    public async Task<List<Livro>> GetAllLivrosAsync()
    {
        return await _livrosRepository.GetAllLivrosAsync();
    }

    public async Task<Livro?> LivrosByIdAsync(int id)
    {
        return await _livrosRepository.GetLivroByIdAsync(id);
    }

    public async Task AddLivroAsync(Livro livro)
    {
        await _livrosRepository.AddLivroAsync(livro);
    }
}