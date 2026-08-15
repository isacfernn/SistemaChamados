using SistemaChamados.Data;
using SistemaChamados.Models;

namespace SistemaChamados.Repositories
{
    public class TicketRepository
    {
        public List<Ticket>? GetAllRepository()
        {
            return FakeDatabase.Tickets;
        }

        public Ticket? GetByIdRepository(int id)
        {
            var ticketEncontrado = FakeDatabase.Tickets.FirstOrDefault(t => 
                t.Id == id);

            return ticketEncontrado;
        }

        public Ticket CreateRepository(Ticket ticket) 
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

        public Ticket? UpdateRepository(int id, Ticket ticket)
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

        public Ticket? DeleteRepositoy(int id)
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
