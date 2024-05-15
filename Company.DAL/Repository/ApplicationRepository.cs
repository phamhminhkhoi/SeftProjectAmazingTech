using Company.DAL.Data;
using Company.DAL.Entities;
using Company.DAL.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

public class ApplicationRepository : IApplicationRepository
{
    private readonly CompanyManagementContext _dbContext;

    public ApplicationRepository(CompanyManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Application>> GetAllApplicationsAsync()
    {
        return await _dbContext.Applications.ToListAsync();
    }

    public async Task<Application> GetApplicationByIdAsync(int id)
    {
        return await _dbContext.Applications.FirstOrDefaultAsync(a => a.ApplicationId == id);
    }

    public async Task AddApplicationAsync(Application application)
    {

        await _dbContext.Applications.AddAsync(application);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateApplicationAsync(Application application)
    {
        _dbContext.Entry(application).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteApplicationAsync(int id)
    {
        var application = await _dbContext.Applications.FindAsync(id);
        if (application != null)
        {
            _dbContext.Applications.Remove(application);
            await _dbContext.SaveChangesAsync();
        }
    }
}
