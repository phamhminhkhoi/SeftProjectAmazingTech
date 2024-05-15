using Company.DAL.DTO.Request;
using Company.DAL.DTO.Respone;
using Company.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.IServices
{
    public interface IAuthenticationService
    {
        public Task<AuthenticationResponseDTO> RegisterAsync(RegistrationRequestDTO request);
        public Task<AuthenticationResponseDTO> AuthenticateAsync(LoginRequestDTO request);
    }
}
