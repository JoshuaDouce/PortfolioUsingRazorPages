﻿using PortfolioWithRazorPages.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Services
{
    public interface IBlogPostsService
    {
        Task SaveAsync(BlogPost blogPost);
        Task DeleteAsync(long id);
        Task<BlogPost> FindAsync(long id);
        Task<BlogPost[]> GetAllAsync(int? count = null, int? page = null);
        IQueryable<BlogPost> GetAll(int? count = null, int? page = null);

    }
}
