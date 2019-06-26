using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PortfolioWithRazorPages.Pages
{
    public class ContactModel : PageModel
    {
        [Required]
        [BindProperty]
        public string Name { get; set; }
        [Required]
        [BindProperty]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [BindProperty]
        [MinLength(50)]
        public string Message { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost() {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            SendMail();

            return Page();
        }

        private void SendMail()
        {
            using (var message = new MailMessage(Email, "Joshuadouce@gmail.com"))
            {
                message.To.Add(new MailAddress("Joshuadouce@gmail.com"));
                message.From = new MailAddress(Email, Name);
                message.Subject = "From Portfolio";
                message.Body = Message;

                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("test@gmail.com", "supersecret");
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Send(message);
                }
            }
        }
    }
}