public interface ILivroRepository
{
    Task AddLivroAsync(Livro livro);
    Task DeleteLivroAsync(int id);
    Task<Livro?> GetLivroByIdAsync(int id);
    Task<List<Livro>> GetAllLivrosAsync();
    Task UpdateLivroAsync(Livro livro);
}