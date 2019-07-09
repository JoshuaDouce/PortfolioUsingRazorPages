using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioWithRazorPages.Models;

[assembly: HostingStartup(typeof(PortfolioWithRazorPages.Areas.Identity.IdentityHostingStartup))]
namespace PortfolioWithRazorPages.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<IdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("IdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>()
                     .AddRoles<IdentityRole>()
                     .AddEntityFrameworkStores<IdentityDbContext>();
            });
        }
    }
}