using System.ComponentModel.DataAnnotations;

namespace SistemaChamados.Models

{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título.")]
        [StringLength(50, ErrorMessage = "O título deve ter no máximo 50 caracteres.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Informe a descrição.")]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public Ticket()
        {
        }
    }
}

