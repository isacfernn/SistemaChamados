using SistemaChamados.Data;
using SistemaChamados.Models;

namespace SistemaChamados.Repositories
{
    public class TicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Ticket> GetAllRepository()
        {
            return _context.Tickets.ToList();
        }

        public Ticket? GetByIdRepository(int id)
        {
            var ticketEncontrado = _context.Tickets.FirstOrDefault(t => 
                t.Id == id);
            
            if (ticketEncontrado == null) 
            {
                return null;
            }
            return ticketEncontrado;
        }

        public Ticket CreateRepository(Ticket ticket) 
        {           
            _context.Tickets.Add(ticket);
            _context.SaveChanges();

            return ticket;
        }

        public Ticket? UpdateRepository(int id, Ticket ticket)
        {
            var ticketEncontrado = _context.Tickets
                .FirstOrDefault(t => t.Id == id);

            if (ticketEncontrado == null)
            {
                return null;
            }

            ticketEncontrado.Title = ticket.Title;
            ticketEncontrado.Description = ticket.Description;

            _context.SaveChanges();

            return ticketEncontrado;
        }

        public Ticket? DeleteRepository(int id)
        {
            var ticketEncontrado = _context.Tickets
                .FirstOrDefault(t => t.Id == id);

            if (ticketEncontrado == null)
            {
                return null;
            }

            _context.Tickets.Remove(ticketEncontrado);
            _context.SaveChanges();

            return ticketEncontrado;
        }
    }
}
