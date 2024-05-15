using AutoMapper;
using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using Company.DAL.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task<User> UpdateUserAsync(UserUpdateRequestDTO user)
        {
            var userEntity = await _userRepository.GetUserByUsernameAsync(user.username);

            if (userEntity != null)
            {
                _mapper.Map(user, userEntity);
                

                await _userRepository.UpdateUserAsync(userEntity);
            }

            return userEntity;
        }




        public async Task<User> DeleteUserAsync(string username)
        {
            return await _userRepository.DeleteUserAsync(username);
        }

        public async Task<User> GetUserByIDAsync(string id)
        {
            return await _userRepository.GetUserByUserIDAsync(id);
        }
    }
}
