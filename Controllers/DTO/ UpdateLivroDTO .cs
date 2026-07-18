using System.ComponentModel.DataAnnotations;

public class UpdateLivroDTO
{
    [Required(ErrorMessage = "O título do livro é obrigatório.")]
    [StringLength(100, ErrorMessage = "O título do livro não pode exceder 100 caracteres.")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "O autor do livro é obrigatório.")]
    [StringLength(100, ErrorMessage = "O autor do livro não pode exceder 100 caracteres.")]
    public string Autor { get; set; }

    [Required(ErrorMessage = "O código do livro é obrigatório.")]
    [Range(1000000, 9999999, ErrorMessage = "O código do livro deve conter 7 dígitos.")]
    public int CodigoLivro { get; set; }
}