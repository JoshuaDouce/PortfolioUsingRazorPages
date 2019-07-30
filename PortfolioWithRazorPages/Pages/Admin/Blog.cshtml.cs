using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWithRazorPages.Services;

namespace PortfolioWithRazorPages.Pages.Admin
{
    public class BlogModel : PageModel
    {
        public IBlogPostsService BlogPostsService { get; }

        public BlogModel(IBlogPostsService blogPostsService)
        {
            BlogPostsService = blogPostsService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostDelete(long Id) {
            await BlogPostsService.DeleteAsync(Id);
            return RedirectToPage("/Admin/Blog");
        }
    }
}