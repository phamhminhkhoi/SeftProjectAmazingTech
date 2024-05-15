using AutoMapper;
using Company.DAL.DTO.Request;
using Company.DAL.Entities;
using Company.DAL.IRepository;
using Company.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.BLL.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ISalaryRepository _salaryRepository;
        private readonly IUserRepository _userRepository;   
        private readonly IMapper _mapper;

        public SalaryService(ISalaryRepository salaryRepository, IMapper mapper, IUserRepository userRepository)
        {
            _salaryRepository = salaryRepository;
            _mapper = mapper;
            _userRepository=userRepository;
        }

        public async Task<List<SalaryRequestDTO>> GetAllSalariesAsync()
        {
            var salaries = await _salaryRepository.GetAllSalariesAsync();
            return _mapper.Map<List<SalaryRequestDTO>>(salaries);
        }

        public async Task<List<SalaryRequestDTO>> GetAllSalariesAsyncOfUser(User user)
        {
            var salaries = await _salaryRepository.GetAllSalariesAsyncOfUser(user);
            return _mapper.Map<List<SalaryRequestDTO>>(salaries);
        }

        public async Task<SalaryRequestDTO> GetSalaryByIdAsync(int salaryId)
        {
            var salary = await _salaryRepository.GetSalaryByIdAsync(salaryId);
            return _mapper.Map<SalaryRequestDTO>(salary);
        }

        public async Task<SalaryRequestDTO> CreateSalaryAsyncByUser(string userId, SalaryRequestDTO salaryRequest)
        {
            var user = await _userRepository.GetUserByUserIDAsync(userId);
            if (user == null)
                return null;

            salaryRequest.userid = userId;
            var salary = _mapper.Map<Salary>(salaryRequest);
            salary.TotalSalary = salaryRequest.ConstractSalary - (salaryRequest.DaysOff * 300000);
            await _salaryRepository.CreateSalaryAsyncByUser(salary.UserId.ToString(), salary);

            return _mapper.Map<SalaryRequestDTO>(salary);
        }


        public async Task<SalaryRequestDTO> UpdateSalaryAsync(SalaryRequestDTO salaryRequest)
        {
            var salary = _mapper.Map<Salary>(salaryRequest);
            SalaryRequestDTO salaryRQ = new SalaryRequestDTO();
            salaryRQ.ConstractSalary = salary.ConstractSalary;
            salaryRQ.DaysOff = salary.DaysOff;
            salaryRQ.PayDate = salary.PayDate;
            salaryRQ.TotalSalary = salary.TotalSalary;
            var updatedSalary = await _salaryRepository.UpdateSalaryAsync(salaryRQ);
            return _mapper.Map<SalaryRequestDTO>(updatedSalary);
        }

        public async Task<bool> DeleteSalaryAsync(int salaryId)
        {
            return await _salaryRepository.DeleteSalaryAsync(salaryId);
        }
    }
}
