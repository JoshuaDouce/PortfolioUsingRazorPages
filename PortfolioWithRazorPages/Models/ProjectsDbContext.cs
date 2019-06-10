using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Models
{
    public class ProjectsDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public ProjectsDbContext(DbContextOptions<ProjectsDbContext> options) : base(options)
        {
            this.EnsureSeedData();
        }
    }
}
