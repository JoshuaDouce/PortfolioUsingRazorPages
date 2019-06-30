using Microsoft.EntityFrameworkCore;
using PortfolioWithRazorPages.Models;

namespace PortfolioWithRazorPages.Data
{
    public class PortfolioDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
