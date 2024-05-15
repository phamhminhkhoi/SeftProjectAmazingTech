using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.BLL.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<User> GetUserByUsernameAsync(string username);
        public Task<User> UpdateUserAsync(UserUpdateRequestDTO user);
        public Task<User> DeleteUserAsync(string username);
        public Task<User> GetUserByIDAsync(string id);
    }
}
