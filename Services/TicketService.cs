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

        public List<Ticket> GetAll()
        {
            return _repository.GetAllRepository();
        }

        public Ticket? GetById(int id)
        {            
            return _repository.GetByIdRepository(id);
        }
        

        public Ticket Create(Ticket ticket)
        {

            ticket.CreatedAt = DateTime.UtcNow;

            return _repository.CreateRepository(ticket);
        }


        public Ticket? Update(int id, Ticket ticket)
        {
            return _repository.UpdateRepository(id, ticket);
        }


       public Ticket? Delete(int id)
        {
            return _repository.DeleteRepository(id);
        }
    }
}
