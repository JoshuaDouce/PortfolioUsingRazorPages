using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWithRazorPages.Models;
using PortfolioWithRazorPages.Services;

namespace PortfolioWithRazorPages.Pages.Admin
{
    public class AddEditBlogPostModel : PageModel
    {
        [FromRoute]
        public long? Id { get; set; }
        public bool IsNewBlogPost {
            get {
                return Id == null;
            }
        }
        [BindProperty]
        public BlogPost BlogPost { get; set; }
        public IFormFile Image { get; set; }
        public IBlogPostsService BlogPostsService { get; }

        public AddEditBlogPostModel(IBlogPostsService blogPostsService)
        {
            BlogPostsService = blogPostsService;
        }

        public async Task OnGetAsync()
        {
            BlogPost = await BlogPostsService.FindAsync(Id.GetValueOrDefault()) ?? new BlogPost();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var blogPost = await BlogPostsService.FindAsync(Id.GetValueOrDefault()) ?? new BlogPost();

            blogPost.Title = BlogPost.Title;
            blogPost.Body = BlogPost.Body;
            blogPost.CreationDate = IsNewBlogPost ? DateTime.Now : blogPost.CreationDate;

            if (Image != null)
            {
                using (var stream = new MemoryStream())
                {
                    await Image.CopyToAsync(stream);
                    blogPost.Image = stream.ToArray();
                    blogPost.ImageContentType = Image.ContentType;
                }
            }
            await BlogPostsService.SaveAsync(blogPost);
            return RedirectToPage("/Blog", new { id = blogPost.Id });
        }

        public async Task<IActionResult> OnPostDelete()
        {
            await BlogPostsService.DeleteAsync(Id.Value);
            return RedirectToPage("/Index");
        }
    }
}