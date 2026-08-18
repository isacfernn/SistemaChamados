using SistemaChamados.Data;
using SistemaChamados.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaChamados.Repositories
{
    public class TicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ticket>> GetAllRepository()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket?> GetByIdRepository(int id)
        {
            var ticketEncontrado = await _context.Tickets.FirstOrDefaultAsync(t => 
                t.Id == id);

            return ticketEncontrado;
        }

        public async Task<Ticket> CreateRepository(Ticket ticket) 
        {           
           await _context.Tickets.AddAsync(ticket);

           await _context.SaveChangesAsync();

           return ticket;
        }

        public async Task<Ticket?> UpdateRepository(int id, Ticket ticket)
        {
            var ticketEncontrado = await _context.Tickets
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticketEncontrado == null)
            {
                return null;
            }

            ticketEncontrado.Title = ticket.Title;
            ticketEncontrado.Description = ticket.Description;

            await _context.SaveChangesAsync();

            return ticketEncontrado;
        }

        public async Task<Ticket?> DeleteRepository(int id)
        {
            var ticketEncontrado = await _context.Tickets
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticketEncontrado == null)
            {
                return null;
            }

            _context.Tickets.Remove(ticketEncontrado);

            await _context.SaveChangesAsync();

            return ticketEncontrado;
        }
    }
}
