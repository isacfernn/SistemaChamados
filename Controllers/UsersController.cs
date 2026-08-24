using Microsoft.AspNetCore.Mvc;
using SistemaChamados.DTOs;
using SistemaChamados.Services;


namespace SistemaChamados.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _service;

        public UsersController(UserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAll();

            var response = users.Select(u => new UserResponse
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,

                Department = new DepartmentResponse
                {
                    Id = u.Department.Id,
                    Sector = u.Department.Sector
                },

                Tickets = u.Tickets.Select(u => new UserTicketResponse
                {
                    Id = u.Id,
                    Title = u.Title,
                    Description = u.Description,
                    Status = u.Status,
                    Priority = u.Priority
                }).ToList()
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            var response = new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,

                Department = new DepartmentResponse
                {
                    Id = user.Department.Id,
                    Sector = user.Department.Sector
                },

                Tickets = user.Tickets.Select(u => new UserTicketResponse
                {
                    Id = u.Id,
                    Title = u.Title,
                    Description = u.Description,
                    Status = u.Status,
                    Priority = u.Priority
                }).ToList()
            };

            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateUserRequest request)
        {
            var user = await _service.CreateUser(request);

            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserRequest request)
        {
            var user = await _service.Update(id, request);
            
            if (user == null)
            {
                return NotFound();
            }

            var respose = new UserResponse()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,

                Department = new DepartmentResponse()
                {
                    Id = user.Department.Id,
                    Sector = user.Department.Sector
                }
            };

            return Ok(respose);
        }


        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _service.Delete(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
