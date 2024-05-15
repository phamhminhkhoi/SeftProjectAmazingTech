using Company.BLL.IServices;
using Company.BLL.Services;
using Company.DAL.Data;
using Company.DAL.DTO.Request;
using Company.DAL.DTO.Respone;
using Company.DAL.Entities;
using Company.DAL.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequestDTO request)
        {
            try
            {
                var response = await _authenticationService.RegisterAsync(request);
                return CreatedAtAction(nameof(Register), response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Authenticate(LoginRequestDTO request)
        {
            try
            {
                var response = await _authenticationService.AuthenticateAsync(request);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
