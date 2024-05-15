using AutoMapper;
using Company.BLL.IServices;
using Company.DAL.DTO.Request;
using Company.DAL.DTO.Respone;
using Company.DAL.Entities;
using Company.DAL.Enums;
using Company.DAL.IRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly TokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthenticationService(UserManager<User> userManager, IAuthenticationRepository authenticationRepository, TokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _authenticationRepository = authenticationRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponseDTO> RegisterAsync(RegistrationRequestDTO request)
        {

            var user = new User { UserName = request.Username, Email = request.Email, Role = Role.User };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                request.Password = "";
                return new AuthenticationResponseDTO
                {
                    Username = user.UserName,
                    Token = _tokenService.CreateToken(user)
                };
            }
            else
            {
                throw new Exception("Failed to register user.");
            }
        }

        public async Task<AuthenticationResponseDTO> AuthenticateAsync(LoginRequestDTO request)
        {

            var user = await _authenticationRepository.GetUserByUsernameAsync(request.Username);

            if (user == null)
            {
                throw new ArgumentException("User not found.");
                // hoặc return null hoặc lớp DTO chứa thông tin lỗi
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                throw new ArgumentException("Invalid password.");
            }

            return new AuthenticationResponseDTO
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

    }
}
