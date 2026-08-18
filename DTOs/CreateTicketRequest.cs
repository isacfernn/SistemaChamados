using SistemaChamados.Models;
using System.ComponentModel.DataAnnotations;
using static SistemaChamados.Models.Ticket;


namespace SistemaChamados.DTOs
{
    public class CreateTicketRequest
    {
        [Required(ErrorMessage = "Informe o título.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Title { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe a descrição.")]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
        public string Description { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe a prioridade.")]
        public TicketPriority Priority { get; set; } = TicketPriority.Low;
    }
}
