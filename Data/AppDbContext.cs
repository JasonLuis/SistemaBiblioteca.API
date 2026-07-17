using Microsoft.EntityFrameworkCore;

public class AppDbContext: DbContext
{
    public DbSet<Livro> Livro { get; set; }

    public AppDbContext() {}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LivrosConfiguration());
    }
}