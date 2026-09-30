using Microsoft.EntityFrameworkCore;

using ProyectoNApi.Context;
using ProyectoNApi.Models.Dtos;

namespace ProyectoNApi.Services
{
    public interface IUserService
    {
        Task<UserDto?> GetUserById(int id);
    }
    
    public class UserService : IUserService
    {
        private readonly ProyectoNContext _context;

        public UserService(ProyectoNContext context)
        {
            _context = context;
        }


        public async Task<UserDto?> GetUserById(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return null;
            }

            var userDto = new UserDto
            {
                Dni = user.Dni,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                PhotoUrl = user.PhotoUrl
            };
            return userDto;
        }
    }
}