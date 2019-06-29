using Microsoft.EntityFrameworkCore;
using PortfolioWithRazorPages.Data;
using PortfolioWithRazorPages.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly PortfolioDbContext _dbContext;
        public ProjectsService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task DeleteAsync(long id)
        {
            _dbContext.Projects.Remove(new Project { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public Task<Project> FindAsync(long id)
        {
            return _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Project> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _dbContext.Projects
                    .Skip(actualCount * page.GetValueOrDefault(0))
                    .Take(actualCount);
        }

        public Task<Project[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(Project project)
        {
            var isNew = project.Id == default;

            _dbContext.Entry(project).State = isNew ? EntityState.Added : EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}
