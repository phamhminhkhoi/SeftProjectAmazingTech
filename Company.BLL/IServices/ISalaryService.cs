using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.BLL.Services
{
    public interface ISalaryService
    {
        Task<List<SalaryRequestDTO>> GetAllSalariesAsync();
        Task<List<SalaryRequestDTO>> GetAllSalariesAsyncOfUser(User user);
        Task<SalaryRequestDTO> GetSalaryByIdAsync(int salaryId);
        public Task<SalaryRequestDTO> CreateSalaryAsyncByUser(string userId, SalaryRequestDTO salaryRequest);
        Task<SalaryRequestDTO> UpdateSalaryAsync(SalaryRequestDTO salaryRequest);
        Task<bool> DeleteSalaryAsync(int salaryId);
    }
}
