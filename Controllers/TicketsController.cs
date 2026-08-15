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
        public IActionResult GetAll()
        {
            var tickets = _service.GetAll();

            return Ok(tickets);
        }


        [HttpGet("{id}")]
        public ActionResult<Ticket> GetById(int id)
        {
            var ticket = _service.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }


        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            var ticketNovo = _service.Create(ticket);
           
            return Ok(ticketNovo);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Ticket ticket)
        {
            var ticketEditado = _service.Update(id, ticket);

            if (ticketEditado == null)
            {
                return NotFound();
            }

            return Ok(ticketEditado);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var ticketEncontrado = _service.Delete(id);

            if (ticketEncontrado == null)
            {
                return NotFound();
            }

            return Ok(new {mensagem = "Ticket Deletado"});
        }
    }
}