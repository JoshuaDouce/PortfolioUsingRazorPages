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
    public class AddEditProjectModel : PageModel
    {
        [FromRoute]
        public long? Id { get; set; }
        public bool IsNewProject {
            get {
                return Id == null;
            }
        }
        [BindProperty]
        public Project Project { get; set; }
        [BindProperty]
        public IFormFile Image{ get; set; }
        public IProjectsService ProjectsService { get; }

        public AddEditProjectModel(IProjectsService projectsService)
        {
            ProjectsService = projectsService;
        }

        public async Task OnGetAsync()
        {
            Project = await ProjectsService.FindAsync(Id.GetValueOrDefault()) ?? new Project();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var project = await ProjectsService.FindAsync(Id.GetValueOrDefault()) ?? new Project();

            project.Name = Project.Name;
            project.ShortDescription = Project.ShortDescription;
            project.Body = Project.Body;
            if (Image != null)
            {
                using (var stream = new MemoryStream())
                {
                    await Image.CopyToAsync(stream);
                    project.Image = stream.ToArray();
                    project.ImageContentType = Image.ContentType;
                }
            }
            await ProjectsService.SaveAsync(project);
            return RedirectToPage("/Project", new { id = project.Id });
        }

        public async Task<IActionResult> OnPostDelete() {
            await ProjectsService.DeleteAsync(Id.Value);
            return RedirectToPage("/Index");
        }
    }
}