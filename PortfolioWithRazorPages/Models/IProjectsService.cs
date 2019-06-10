using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Models
{
    public interface IProjectsService
    {
        Task SaveAsync(Project project);
        Task DeleteAsync(long id);
        Task<Project> FindAsync(long id);
        Task<Project[]> GetAllAsync();
    }
}
