using System.Threading.Tasks;
using AutoMapper;
using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Company.DAL.IRepository;
using System.Collections.Generic;
using Company.DAL.Data;

namespace Company.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CompanyManagementContext _context;
        private readonly IMapper _mapper;

        public UserRepository(CompanyManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(string username)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (userEntity != null)
            {
                _context.Users.Remove(userEntity);
                await _context.SaveChangesAsync();
            }
            return userEntity;
        }

        public async Task<User> GetUserByUserIDAsync(string userID)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == userID);
        }
    }
}
