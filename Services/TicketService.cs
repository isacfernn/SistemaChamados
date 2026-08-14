using SistemaChamados.Data;
using SistemaChamados.Models;

namespace SistemaChamados.Services
{
    public class TicketService
    {
        public List<Ticket> GetAll()
        {
            return FakeDatabase.Tickets;
        }

        public Ticket? GetById(int id)
        {
            var Ticket = FakeDatabase.Tickets.FirstOrDefault(t => 
                t.Id == id);
            
            return Ticket;
        }

        public Ticket Create(Ticket ticket)
        {
            int maiorId = FakeDatabase.Tickets
                 .Select(m => (int?)m.Id)
                 .Max() ?? 0;

            maiorId++;

            var novoTicket = new Ticket
            {
                Id = maiorId,
                Title = ticket.Title,
                Description = ticket.Description
            };

            FakeDatabase.Tickets.Add(novoTicket);

            return novoTicket;
        }

        public Ticket? Update(int id, Ticket ticket)
        {
            var ticketEncontrado = FakeDatabase.Tickets
                .FirstOrDefault(t => t.Id == id);

            if (ticketEncontrado == null)
            {
                return null;
            }

            ticketEncontrado.Title = ticket.Title;
            ticketEncontrado.Description = ticket.Description;

            return ticketEncontrado;
        }

        public Ticket? Delete(int id)
        {
            var ticketEncontrado = FakeDatabase.Tickets
                .FirstOrDefault(t => t.Id == id);

            if (ticketEncontrado == null)
            {
                return null;
            }

            FakeDatabase.Tickets.Remove(ticketEncontrado);

            return ticketEncontrado;

        }
    }
}
