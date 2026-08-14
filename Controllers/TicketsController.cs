using Microsoft.AspNetCore.Mvc;
using SistemaChamados.Models;
using SistemaChamados.Services;

namespace SistemaChamados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var services = new TicketService();

            var tickets = services.GetAll();

            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public ActionResult<Ticket> GetById(int id)
        {
            var service = new TicketService();

            var ticket = service.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }


        [HttpPost]
        public IActionResult Create(Ticket ticket)
        {
            var service = new TicketService();

            var ticketNovo = service.Create(ticket);
           
            return Ok(ticketNovo);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, Ticket ticket)
        {
            var service = new TicketService();

            var ticketEditado = service.Update(id, ticket);

            if (ticketEditado == null)
            {
                return NotFound();
            }

            return Ok(ticketEditado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var service = new TicketService();

            var ticketEncontrado = service.Delete(id);

            if (ticketEncontrado == null)
            {
                return NotFound();
            }

            return Ok(new {mensagem = "Tarefa Deletada"});
        }
    }
}