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

        public async Task<List<Ticket>> GetAll()
        {
           return await _repository.GetAllRepository();
        }

        public async Task<Ticket?> GetById(int id)
        {            
            return await _repository.GetByIdRepository(id);
        }
        

        public async Task<Ticket> Create(Ticket ticket)
        {

            ticket.CreatedAt = DateTime.UtcNow;

            return await _repository.CreateRepository(ticket);
        }


        public async Task<Ticket?> Update(int id, Ticket ticket)
        {
            return await _repository.UpdateRepository(id, ticket);
        }


       public async Task<Ticket?> Delete(int id)
        {
            return await _repository.DeleteRepository(id);
        }
    }
}
