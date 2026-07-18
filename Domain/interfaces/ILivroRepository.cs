public interface ILivroRepository
{
    Task AddLivroAsync(Livro livro);
    Task DeleteLivroAsync(Livro livro);
    Task<Livro?> GetLivroByIdAsync(int id);
    Task<List<Livro>> GetAllLivrosAsync();
    Task UpdateLivroAsync(Livro livro);
}