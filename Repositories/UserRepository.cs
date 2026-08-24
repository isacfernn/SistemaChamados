using Microsoft.EntityFrameworkCore;
using SistemaChamados.Data;
using SistemaChamados.Models;

namespace SistemaChamados.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllRepository()
        {
            return await _context.Users
                .AsNoTracking()
                .Include(d => d.Department)
                .Include(t => t.Tickets)
                .ToListAsync();
        }
        public async Task<User?> GetByIdRepository(int id)
        {
                 return await _context.Users
                .AsNoTracking()
                .Include(d => d.Department)
                .Include(t => t.Tickets)
                .FirstOrDefaultAsync(u => id == u.Id); ;
        }

        public async Task<User> CreateUserRepository(User user)
        {
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return user;
        }

        
        public async Task<User?> Update (int id, User user)
        {
            var userUpdated = await _context.Users
                .Include(d => d.Department)
                .Include(t => t.Tickets)
                .FirstOrDefaultAsync(u => u.Id == id)
                ;

            if (userUpdated == null) 
            {
                return null;
            }

            userUpdated.Name = user.Name;
            userUpdated.Email = user.Email;
            userUpdated.Password = user.Password;
            userUpdated.DepartmentId = user.DepartmentId;

            await _context.SaveChangesAsync();

            return userUpdated;
        }


        public async Task<User?> Delete(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            _context.Users.Remove(user);
            _context.SaveChanges();

            return user;
        }


        public async Task<bool> DepartmentExist(int id)
        {            
            return await _context.Departments
            .AnyAsync(d => d.Id == id);            
        }
        
        public async Task<User?> EmailExist(string email)
        {
            return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> UserExist(int id)
        {
            return await _context.Users
                .AnyAsync(d => d.Id == id);
        }

    }
}

