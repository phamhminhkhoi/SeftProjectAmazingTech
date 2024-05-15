using AutoMapper;
using Company.BLL.IServices;
using Company.DAL.DTO.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public ApplicationController(IApplicationService applicationService, IMapper mapper)
        {
            _applicationService = applicationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplicationsAsync()
        {
            try
            {
                var applications = await _applicationService.GetAllApplicationsAsync();
                return Ok(applications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplicationByIdAsync(int id)
        {
            try
            {
                var application = await _applicationService.GetApplicationByIdAsync(id);
                if (application == null)
                {
                    return NotFound();
                }
                return Ok(application);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDTO>> CreateApplicationByUser(ApplicationDTO applicationRequest)
        {
            try
            {
                var createdApplication = await _applicationService.AddApplicationAsync(applicationRequest.UserId, applicationRequest);
                if (createdApplication == null)
                    return BadRequest("User not found");

                return CreatedAtAction(nameof(CreateApplicationByUser), new { applicationId = createdApplication.ApplicationId }, createdApplication);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicationAsync(int id, [FromBody] ApplicationDTO applicationRequestDTO)
        {
            try
            {
                var applicationDTO = _mapper.Map<ApplicationDTO>(applicationRequestDTO);
                // Retrieve user ID from your authentication mechanism, then pass it to the service
                string userId = "user123"; // Example user ID
                await _applicationService.UpdateApplicationAsync(userId, applicationDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplicationAsync(int id)
        {
            try
            {
                await _applicationService.DeleteApplicationAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
