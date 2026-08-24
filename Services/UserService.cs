using SistemaChamados.DTOs;
using SistemaChamados.Models;
using SistemaChamados.Repositories;

namespace SistemaChamados.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<User>> GetAll()
        {
            var users = await _repository.GetAllRepository();

            return users;
        }
        public async Task<User?> GetById(int id)
        {
            var userExist = await _repository.GetByIdRepository(id);

            return userExist;
        }

        public async Task<User> CreateUser(CreateUserRequest request)
        {
            var departmentExist = await _repository
                .DepartmentExist(request.DepartmentId);

            var emailExist = await _repository.EmailExist(request.Email);


            if (departmentExist == false)
            {
                throw new InvalidOperationException(
                    "O departamento não existe.");
            }

            if (emailExist != null )
            {
                throw new InvalidOperationException(
                "O email já está em uso.");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                DepartmentId = request.DepartmentId,
            };

            return await _repository.CreateUserRepository(user);
        }


        public async Task<User?> Update(int id, UpdateUserRequest request)
        {
            var departmentExist = await _repository.DepartmentExist(request.DepartmentId);

            var userExist = await _repository.UserExist(id);

            var emailExist = await _repository.EmailExist(request.Email);

            if (departmentExist == false)
            {
                throw new InvalidOperationException(
                    "Departamento não existe.");
            }

            if (userExist == false)
            {
                throw new InvalidOperationException(
                    "O usuário não existe.");
            }

            if (emailExist != null && emailExist.Id != id)
            {
                throw new InvalidOperationException(
                "O email não pode ser atualizado porque já está em uso.");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                DepartmentId = request.DepartmentId,
            };

            var userUpdate = await _repository.Update(id, user);

            return userUpdate;
        }


        public async Task<User?> Delete(int id)
        {
            var userExist = await _repository.UserExist(id);

            if (userExist == null)
            {
                throw new InvalidOperationException("Usuários não existe.");
            }

            var user = await _repository.Delete(id);

            return user;
        }
    }
}
