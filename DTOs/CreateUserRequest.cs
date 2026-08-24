using System.ComponentModel.DataAnnotations;

namespace SistemaChamados.DTOs
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Informe o Nome.")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe o e-mail.")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        public string Email { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe a senha.")]
        public string Password { get; set; } = string.Empty;


        [Required(ErrorMessage = "Informe um departamento válido.")]
        public int DepartmentId { get; set; } 
    }
}
