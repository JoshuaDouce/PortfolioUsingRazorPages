using PortfolioWithRazorPages.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Services
{
    public interface IProjectsService
    {
        Task SaveAsync(Project project);
        Task DeleteAsync(long id);
        Task<Project> FindAsync(long id);
        Task<Project[]> GetAllAsync(int? count = null, int? page = null);
        IQueryable<Project> GetAll(int? count = null, int? page = null);
    }
}
