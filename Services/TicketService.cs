using SistemaChamados.DTOs;
using SistemaChamados.Models;
using SistemaChamados.Repositories;
using static SistemaChamados.Models.Ticket;

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
                Status = TicketStatus.Pending,
                Priority = request.Priority
            };

            return await _repository.CreateRepository(ticket);
        }


        public async Task<Ticket?> Update(int id, UpdateTicketRequest request)
        {

            var currentStatus = await _repository.GetByIdRepository(id);

            if (currentStatus == null)
            {
                return null;
            }

            if (currentStatus.Status == TicketStatus.Resolved)
            {
                throw new InvalidOperationException
                    ("O ticket não pode ser alterado porque está concluído");
            }

            if (currentStatus.Status == TicketStatus.Canceled)
            {
                throw new InvalidOperationException
                    ("O ticket não pode ser alterado porque está cancelado");
            }

            if (currentStatus.Status == TicketStatus.InProgress 
                && request.Status == TicketStatus.Pending)
            {
                throw new InvalidOperationException
                    ("O ticket em andamento não pode voltar para pendente");
            }

            var ticket = new Ticket
            {
                Title = request.Title,
                Description = request.Description,
                UpdatedAt = DateTime.UtcNow,
                Status = request.Status,
                Priority = request.Priority,
            };

            return await _repository.UpdateRepository(id, ticket);
        }


        public async Task<Ticket?> Delete(int id)
        {
            return await _repository.DeleteRepository(id);
        }
    }
}
