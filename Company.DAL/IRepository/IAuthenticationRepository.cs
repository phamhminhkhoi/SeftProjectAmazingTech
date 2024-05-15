using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.IRepository
{
    public interface IAuthenticationRepository
    {
        public Task<User> GetUserByUsernameAsync(string username);

        public Task<User> AddUserAsync(User user);

        
    }
}
