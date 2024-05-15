using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.DAL.IRepository
{
    public interface ISalaryRepository
    {
        Task<List<Salary>> GetAllSalariesAsync();
        Task<List<Salary>> GetAllSalariesAsyncOfUser(User user);
        Task<Salary> GetSalaryByIdAsync(int salaryId);
        public Task CreateSalaryAsyncByUser(string userId, Salary salary);
        Task<Salary> UpdateSalaryAsync(SalaryRequestDTO salaryRequest);
        Task<bool> DeleteSalaryAsync(int salaryId);
    }
}
