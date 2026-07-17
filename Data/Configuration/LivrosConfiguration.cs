using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LivrosConfiguration: IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Titulo).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Autor).IsRequired().HasMaxLength(100);
        builder.Property(l => l.CodigoLivro).IsRequired();
        builder.Property(l => l.Disponivel).IsRequired();
        builder.Property(l => l.DataCadastro).IsRequired().HasDefaultValueSql("GETDATE()");
    }
}