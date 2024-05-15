using AutoMapper;
using Company.DAL.Data;
using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using Company.DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.DAL.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly CompanyManagementContext _context;
        private readonly IMapper _mapper;

        public SalaryRepository(CompanyManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Salary>> GetAllSalariesAsync()
        {
            return await _context.Salarys.ToListAsync();
        }

        public async Task<List<Salary>> GetAllSalariesAsyncOfUser(User user)
        {
            var userWithSalaries = await _context.Users
                                                .Include(u => u.Salaries)
                                                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (userWithSalaries != null)
            {
                return userWithSalaries.Salaries.ToList();
            }
            else
            {
                return new List<Salary>();
            }
        }

        public async Task<Salary> GetSalaryByIdAsync(int salaryId)
        {
            return await _context.Salarys.FindAsync(salaryId);
        }

        public async Task CreateSalaryAsyncByUser(string userId, Salary salary)
        {
            salary.UserId = userId;
            _context.Salarys.Add(salary);
            await _context.SaveChangesAsync();
        }





        public async Task<Salary> UpdateSalaryAsync(SalaryRequestDTO salaryRequest)
        {
            var salary = _mapper.Map<Salary>(salaryRequest);
            _context.Entry(salary).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return salary;
        }

        public async Task<bool> DeleteSalaryAsync(int salaryId)
        {
            var salary = await _context.Salarys.FindAsync(salaryId);
            if (salary == null)
                return false;

            _context.Salarys.Remove(salary);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
