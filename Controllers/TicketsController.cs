using Microsoft.AspNetCore.Mvc;
using SistemaChamados.DTOs;
using SistemaChamados.Services;

namespace SistemaChamados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketService _service;

        public TicketsController(TicketService service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _service.GetAll();

            var response = tickets.Select(ticket => new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                CreatedAt = ticket.CreatedAt,
                UpdatedAt = ticket.UpdatedAt,
                Status = ticket.Status,
                Priority = ticket.Priority
            }).ToList();

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TicketResponse>> GetById(int id)
        {
            var ticket = await _service.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            var response = new TicketResponse
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Description = ticket.Description,
                CreatedAt = ticket.CreatedAt,
                UpdatedAt = ticket.UpdatedAt,
                Status = ticket.Status,
                Priority = ticket.Priority
            };

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateTicketRequest request)
        {
            var ticketNovo = await _service.Create(request);

            var response = new TicketResponse
            {
                Id = ticketNovo.Id,
                Title = ticketNovo.Title,
                Description = ticketNovo.Description,
                Status = ticketNovo.Status,
                Priority = ticketNovo.Priority,
                CreatedAt = ticketNovo.CreatedAt
            };

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTicketRequest request)
        { 
            var ticketEditado = await _service.Update(id, request);

            if (ticketEditado == null)
            {
                return NotFound();
            }

            var response = new TicketResponse
            {
                Id = ticketEditado.Id,
                Title = ticketEditado.Title,
                Description = ticketEditado.Description,
                CreatedAt = ticketEditado.CreatedAt,
                UpdatedAt = ticketEditado.UpdatedAt,
                Status = ticketEditado.Status,
                Priority = ticketEditado.Priority
            };

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            var ticketEncontrado = await _service.Delete(id);

            if (ticketEncontrado == null)
            {
                return NotFound();
            }

            return Ok(new {mensagem = "Ticket Deletado"});
        }
    }
}