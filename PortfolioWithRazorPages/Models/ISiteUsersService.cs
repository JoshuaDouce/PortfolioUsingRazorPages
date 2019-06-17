using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Models
{
    public interface ISiteUsersService
    {
        Task SaveAsync(SiteUser siteUser);
        Task DeleteAsync(long id);
        Task<SiteUser> FindAsync(long id);
        Task<SiteUser> FindAsyncByEmail(string email);
        Task<SiteUser[]> GetAllAsync(int? count = null, int? page = null);
        IQueryable<SiteUser> GetAll(int? count = null, int? page = null);
    }
}
