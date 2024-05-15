
using Company.DAL.Data;
using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using Company.DAL.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly CompanyManagementContext _context;
        

        public AuthenticationRepository(CompanyManagementContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User> AddUserAsync(User user)
        {
            var result = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        
    }
}
