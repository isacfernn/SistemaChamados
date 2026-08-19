using System.ComponentModel.DataAnnotations;

namespace SistemaChamados.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres.")]
        public string Title { get; set; } = string.Empty;


        [Required]
        [StringLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public TicketStatus Status { get; set; } = TicketStatus.Pending;
        public TicketPriority Priority { get; set; } = TicketPriority.Low;

        public enum TicketStatus
        {
            Pending = 1,
            InProgress = 2,
            Resolved = 3,
            Canceled = 4
        }

        public enum TicketPriority
        {
            Low = 1,
            Medium = 2,
            High = 3
        }
    }
}