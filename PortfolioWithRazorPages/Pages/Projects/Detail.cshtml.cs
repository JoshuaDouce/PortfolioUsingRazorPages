using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWithRazorPages.Services;

namespace PortfolioWithRazorPages.Pages.Projects
{
    public class DetailModel : PageModel
    {
        private IProjectsService ProjectsService;

        public DetailModel(IProjectsService projectsService)
        {
            ProjectsService = projectsService;
        }
        public async Task<IActionResult> OnGet(long id)
        {
            var x = await ProjectsService.FindAsync(id);

            if (x != null)
            {
                return Page();
            }

            return RedirectToPage("/Error");
        }
    }
}