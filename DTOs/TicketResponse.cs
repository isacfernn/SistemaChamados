using SistemaChamados.Models;
using System.ComponentModel.DataAnnotations;
using static SistemaChamados.Models.Ticket;

namespace SistemaChamados.DTOs
{
    public class TicketResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public TicketStatus Status { get; set; }
        public TicketPriority Priority { get; set; }

        public UserResponse User { get; set; }
        public DepartmentResponse Department { get; set; }
    }
}
