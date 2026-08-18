using SistemaChamados.Data;
using SistemaChamados.DTOs;
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
        

        public async Task<Ticket> Create(CreateTicketRequest request)
        {
            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            return await _repository.CreateRepository(ticket);
        }


        public async Task<Ticket?> Update(int id, UpdateTicketRequest request)
        {
            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description
            };

            return await _repository.UpdateRepository(id, ticket);
        }


       public async Task<Ticket?> Delete(int id)
       {
            return await _repository.DeleteRepository(id);
       }
    }
}
