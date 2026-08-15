using SistemaChamados.Data;
using SistemaChamados.Models;
using SistemaChamados.Repositories;

namespace SistemaChamados.Services
{
    public class TicketService
    {
        private readonly TicketRepository _repository;

        public TicketService(TicketRepository repository)
        {
            _repository = repository;
        }

        public List<Ticket>? GetAll()
        {
            var ticketRepository = _repository.GetAllRepository();

            return ticketRepository;
        }

        public Ticket? GetById(int id)
        {
            var ticketRepository = _repository.GetByIdRepository(id);
            
            return ticketRepository;
        }
        

        public Ticket Create(Ticket ticket)
        {
            var ticketRepositoy = _repository.CreateRepository(ticket);

            return ticketRepositoy;
        }


        public Ticket? Update(int id, Ticket ticket)
        {
            var ticketRepositoy = _repository.UpdateRepository(id, ticket);

            return ticketRepositoy;
        }


       public Ticket? Delete(int id)
        {
            var ticketRepository = _repository.DeleteRepositoy(id);

            return ticketRepository;
        }
    }
}
