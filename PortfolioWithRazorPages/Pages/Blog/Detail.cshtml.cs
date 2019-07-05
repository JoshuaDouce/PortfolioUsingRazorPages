using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWithRazorPages.Services;

namespace PortfolioWithRazorPages.Pages.Blog
{
    public class DetailModel : PageModel
    {
        private IBlogPostsService BlogPostsService;
        public DetailModel(IBlogPostsService blogPostsService)
        {
            BlogPostsService = blogPostsService;
        }
        public async Task<IActionResult> OnGet(long id)
        {
            var x = await BlogPostsService.FindAsync(id);

            if (x != null)
            {
                return Page();
            }

            return RedirectToPage("/Error");
        }
    }
}