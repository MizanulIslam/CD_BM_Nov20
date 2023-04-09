using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using BM_Blazor_Nov20.Models;
using BM_Blazor_Nov20.Data;
using BM_Models;

namespace BM_Blazor_Nov20.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ClientListDbContext _clientListDbContext;

        public ConfirmEmailModel(UserManager<ApplicationUser> userManager,
             ClientListDbContext clientListDbContext)
        {
            _userManager = userManager;
            _clientListDbContext = clientListDbContext;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            StatusMessage = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            if (result.Succeeded)
            {
               // Client client;
                Client client = _clientListDbContext.Clients.Where(x => x.UserName == user.UserName).FirstOrDefault();
                if (client != null)
                {
                    client.ExtraColumn1 = "EmailConfirmed";
                    _clientListDbContext.Update(client);
                    await _clientListDbContext.SaveChangesAsync();

                }
               
               
            }
            return Page();
        }
    }
}
