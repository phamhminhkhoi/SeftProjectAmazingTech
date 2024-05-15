using System.Collections.Generic;
using System.Threading.Tasks;
using Company.BLL.Services;
using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _salaryService;
        private readonly IUserService   _userService;

        public SalaryController(ISalaryService salaryService, IUserService userService)
        {
            _salaryService = salaryService;
            _userService=userService;
        }

        [HttpGet]
        [Route("GetAllSalaryByAllUser")]
        public async Task<ActionResult<List<SalaryRequestDTO>>> GetAllSalariesAsync()
        {
            var salaries = await _salaryService.GetAllSalariesAsync();
            return Ok(salaries);
        }

        [HttpGet]
        [Route("GetAllSalaryByUsername")]
        public async Task<ActionResult<List<SalaryRequestDTO>>> GetAllSalariesAsyncOfUser(string username)
        {
            var user = await _userService.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            var salaries = await _salaryService.GetAllSalariesAsyncOfUser(user);
            return Ok(salaries);
        }

        [HttpGet]
        [Route("GetAllSalaryBySalaryID")]
        public async Task<ActionResult<SalaryRequestDTO>> GetSalaryByIdAsync(int salaryId)
        {
            var salary = await _salaryService.GetSalaryByIdAsync(salaryId);
            if (salary == null)
            {
                return NotFound();
            }
            return Ok(salary);
        }

        [HttpPost]
        [Route("user/create")]
        
        public async Task<ActionResult<SalaryRequestDTO>> CreateSalaryByUser(SalaryRequestDTO salaryRequest)
        {
            var createdSalary = await _salaryService.CreateSalaryAsyncByUser(salaryRequest.userid, salaryRequest);
            if (createdSalary == null)
                return BadRequest("User not found");

            return CreatedAtAction(nameof(CreateSalaryByUser), new { salaryId = createdSalary.SalaryId }, createdSalary);

        }


        [HttpPut]
        [Route("UpdateSalary")]
        public async Task<ActionResult<SalaryRequestDTO>> UpdateSalaryAsync(SalaryRequestDTO salaryRequest)
        {
            var updatedSalary = await _salaryService.UpdateSalaryAsync(salaryRequest);
            if (updatedSalary == null)
            {
                return NotFound();
            }
            return Ok(updatedSalary);
        }

        [HttpDelete]
        [Route("DelelteSalary")]
        public async Task<ActionResult> DeleteSalaryAsync(int salaryId)
        {
            var result = await _salaryService.DeleteSalaryAsync(salaryId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
