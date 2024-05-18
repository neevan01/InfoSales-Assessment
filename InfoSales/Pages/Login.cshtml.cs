using InfoSales.DomainL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Dapper;
using InfoSales.BusinessL.Repositories;
using InfoSales.BusinessL.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace InfoSales.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IUsers UserRepo;
        public LoginModel(IUsers userRepo)
        {
            UserRepo = userRepo;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User Input { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var user = Input.Username ?? "";            
            if(string.IsNullOrEmpty(user.Trim()) )
            {
                ModelState.AddModelError(string.Empty, "Enter the username.");
                return Page();
            }
            var pw = Input.Password ?? "";
            if (string.IsNullOrEmpty(pw.Trim()))
            {
                ModelState.AddModelError(string.Empty, "Enter the passsword.");
                return Page();
            }
            var encodedPw = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(pw));
            DynamicParameters param = new DynamicParameters();
            param.Add("uname", user);
            param.Add("flag", "login");
            var userFromDb = await UserRepo.GetFirstAsync("SpUser", System.Data.CommandType.StoredProcedure, param);
            if (userFromDb != null)
            {
                if (userFromDb.Password == encodedPw)
                {
                    HttpContext.Session.SetString("Username", Input.Username);
                    HttpContext.Session.SetString("Role", "users".ToUpper());
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, Input.Username),
                        new Claim(ClaimTypes.Role, "users".ToUpper())};
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);
                    return RedirectToPage("/Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password is incorrect.");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Username or password is incorrect.");
            }
            return Page();
        }
    }
}
