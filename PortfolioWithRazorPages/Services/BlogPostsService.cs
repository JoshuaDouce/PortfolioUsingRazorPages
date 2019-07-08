using Microsoft.EntityFrameworkCore;
using PortfolioWithRazorPages.Data;
using PortfolioWithRazorPages.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Services
{
    public class BlogPostsService : IBlogPostsService
    {
        private readonly PortfolioDbContext _dbContext;

        public BlogPostsService(PortfolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteAsync(long id)
        {
            _dbContext.BlogPosts.Remove(new BlogPost { Id = id });
            await _dbContext.SaveChangesAsync();
        }

        public Task<BlogPost> FindAsync(long id)
        {
            return _dbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<BlogPost> GetAll(int? count = null, int? page = null)
        {
            var actualCount = count.GetValueOrDefault(10);

            return _dbContext.BlogPosts
                    .Skip(actualCount * page.GetValueOrDefault(0))
                    .Take(actualCount);
        }

        public Task<BlogPost[]> GetAllAsync(int? count = null, int? page = null)
        {
            return GetAll(count, page).ToArrayAsync();
        }

        public async Task SaveAsync(BlogPost blogPost)
        {
            var isNew = blogPost.Id == default(long);

            _dbContext.Entry(blogPost).State = isNew ? EntityState.Added : EntityState.Modified;

            await _dbContext.SaveChangesAsync();
        }
    }
}
