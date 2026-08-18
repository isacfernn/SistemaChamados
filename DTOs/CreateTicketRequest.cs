using System.ComponentModel.DataAnnotations;

namespace SistemaChamados.DTOs
{
    public class CreateTicketRequest
    {
        [Required(ErrorMessage = "Informe o título.")]
        [StringLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Informe a descrição.")]
        public string Description { get; set; }
    }
}
