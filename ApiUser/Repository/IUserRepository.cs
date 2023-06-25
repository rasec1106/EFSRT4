using ApiUser.DTOs;
using ApiUser.Models;

namespace ApiUser.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsers(int page, int size);
        Task<User> GetUserById(int id);
        Task<ResponseDto> CreateUser(User user);
        Task<ResponseDto> UpdateUser(User user);
        Task<ResponseDto> DeleteUser(int id);
        Task<ResponseDto> Login(string username, string password);
    }
}
