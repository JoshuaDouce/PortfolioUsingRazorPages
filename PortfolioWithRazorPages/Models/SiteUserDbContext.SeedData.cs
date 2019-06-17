using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWithRazorPages.Models
{
    public static class SiteUserDbContextSeedData
    {
        static object synchlock = new object();
        static volatile bool seeded = false;

        public static void EnsureSeedData(this SiteUserDbContext context)
        {
            if (!seeded && context.SiteUsers.Count() == 0)
            {
                lock (synchlock)
                {
                    if (!seeded)
                    {
                        var users = GenerateUsers();
                        context.SiteUsers.AddRange(users);
                        context.SaveChanges();
                        seeded = true;
                    }
                }
            }
        }

        private static SiteUser[] GenerateUsers()
        {
            return new SiteUser[] {
                new SiteUser{
                    Email = "Test@Test.com",
                    Password = "Password"
                }
            };
        }
    }
}
