using Dapper;
using InfoSales.BusinessL.Interfaces;
using InfoSales.DomainL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InfoSales.Pages
{
    public class RegisterModel : PageModel
    {

        private readonly ILogger<RegisterModel> Logger;
        private readonly IUsers UserRepo;

        public RegisterModel(IUsers userRepo, ILogger<RegisterModel> logger)
        {
            UserRepo = userRepo;
            Logger = logger;
        }

        [BindProperty]
        public User Input { get; set; }

        public string ReturnUrl { get; set; } = default!;

        public void OnGetAsync(string returnUrl = "")
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("flag", "i");
                param.Add("uname", Input.Username);
                var pw = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(Input.Password));
                param.Add("pw", pw);
                param.Add("email", Input.Email);
                param.Add("phone", Input.Phone);
                param.Add("status", Input.Status);
                var result = await UserRepo.GetFirstAsync("SpUser", System.Data.CommandType.StoredProcedure, param);

                if (result.Result == "SUCCESS")
                {
                    Logger.LogInformation("User created a new account with password.");

                    return LocalRedirect("/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, result.Result);
                }
            }
            return Page();
        }
    }
}
