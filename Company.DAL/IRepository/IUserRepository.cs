using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.IRepository
{
    public interface IUserRepository
    {

        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByUserIDAsync(string userID);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> UpdateUserAsync(User user);
        Task<User> DeleteUserAsync(string username);
    }
}
