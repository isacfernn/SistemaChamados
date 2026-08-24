using static SistemaChamados.Models.Ticket;

namespace SistemaChamados.DTOs
{
    public class UserTicketResponse
    {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public TicketStatus Status { get; set; }
            public TicketPriority Priority { get; set; }
    }
}
