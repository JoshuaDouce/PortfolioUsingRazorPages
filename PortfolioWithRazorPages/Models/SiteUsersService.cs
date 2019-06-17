using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Models
{
    public class SiteUsersService : ISiteUsersService
    {
        private readonly PortfolioDbContext _dbContext;

        public SiteUsersService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task DeleteAsync(long id)
        {
            _dbContext.SiteUsers.Remove(new SiteUser { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public Task<SiteUser> FindAsync(long id)
        {
            return _dbContext.SiteUsers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<SiteUser> FindAsyncByEmail(string email)
        {
            return _dbContext.SiteUsers.FirstOrDefaultAsync(x => x.Email == email);
        }

        public IQueryable<SiteUser> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _dbContext.SiteUsers
                    .Skip(actualCount * page.GetValueOrDefault(0))
                    .Take(actualCount);
        }

        public Task<SiteUser[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(SiteUser siteUser)
        {
            var isNew = siteUser.Id == default;

            _dbContext.Entry(siteUser).State = isNew ? EntityState.Added : EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}
