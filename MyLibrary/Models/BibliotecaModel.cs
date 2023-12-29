using System.ComponentModel.DataAnnotations;

namespace MyLibrary.Models
{
    public class BibliotecaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do livro")]
        public string NomeDoLivro { get; set; }
        [Required(ErrorMessage = "Digite o nome do autor")]
        public string Autor { get; set; }
        [Required(ErrorMessage = "Digite o número de páginas do livro")]
        public int Paginas { get; set; }
        public DateTime UltimaAtualizacao { get; set; } = DateTime.Now;

    }
}
