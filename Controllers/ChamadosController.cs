using Microsoft.AspNetCore.Mvc;

namespace SistemaChamados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChamadosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API de chamados funcionando!");
        }
    }
}