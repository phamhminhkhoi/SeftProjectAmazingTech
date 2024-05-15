using Company.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.IRepository
{
    public interface IApplicationRepository
    {
        Task<List<Application>> GetAllApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(int id);
        Task<Application> AddApplicationAsync(Application application);
        Task<Application> UpdateApplicationAsync(Application application);
        Task DeleteApplicationAsync(int id);
    }
}
