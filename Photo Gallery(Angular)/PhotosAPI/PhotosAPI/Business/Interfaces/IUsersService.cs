using PhotosAPI.DTO.Auth;
using PhotosAPI.DTO.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace PhotosAPI.Business.Interfaces
{
    public interface IUsersService
    {
        Task AddUser(RegisterDto photo);
        Task DeleteUser(int id);
        Task UpdateUser(UserDto photo);
        Task<UserDto> Get(int id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<JwtResponse> Login(LoginDto model);
    }
}
