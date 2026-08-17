using Microsoft.AspNetCore.Mvc;
using SistemaChamados.Models;
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

            return Ok(tickets);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetById(int id)
        {
            var ticket = await _service.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            var ticketNovo = await _service.Create(ticket);
           
            return Ok(ticketNovo);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ticket ticket)
        {
            var ticketEditado = await _service.Update(id, ticket);

            if (ticketEditado == null)
            {
                return NotFound();
            }

            return Ok(ticketEditado);
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