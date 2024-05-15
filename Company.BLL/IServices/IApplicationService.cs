using Company.DAL.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.BLL.IServices
{
    public interface IApplicationService
    {
        Task<List<ApplicationDTO>> GetAllApplicationsAsync();
        Task<ApplicationDTO> GetApplicationByIdAsync(int id);
        Task AddApplicationAsync(string userId, ApplicationDTO applicationDTO);
        Task UpdateApplicationAsync(string userId, ApplicationDTO applicationDTO);
        Task DeleteApplicationAsync(int id);
    }
}
