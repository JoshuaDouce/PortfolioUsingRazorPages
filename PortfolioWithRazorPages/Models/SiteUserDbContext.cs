using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Models
{
    public class SiteUserDbContext : DbContext
    {
        public DbSet<SiteUser> SiteUsers { get; set; }

        public SiteUserDbContext(DbContextOptions<SiteUserDbContext> options) : base(options)
        {
            this.EnsureSeedData();
        }
    }
}
