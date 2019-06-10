using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Models
{
    public class BlogPostsDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }

        public BlogPostsDbContext(DbContextOptions<BlogPostsDbContext> options) : base(options)
        {
            this.EnsureSeedData();
        }
    }
}
