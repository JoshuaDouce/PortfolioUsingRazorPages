using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioWithRazorPages.Models;
using PortfolioWithRazorPages.Services;

namespace PortfolioWithRazorPages.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        private readonly ISiteUsersService _siteUserService;

        public LoginModel(ISiteUsersService usersService)
        {
            _siteUserService = usersService;
        }

        public async Task<IActionResult> OnPost() {
            var siteUser = await _siteUserService.FindAsyncByEmail(EmailAddress);

            if (siteUser == null || siteUser.Password != Password)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var scheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var user = new ClaimsPrincipal(
                new ClaimsIdentity(
                    new[] { new Claim(ClaimTypes.Name, EmailAddress) }, scheme)
                );

            return SignIn(user, scheme);
        }
    }
}