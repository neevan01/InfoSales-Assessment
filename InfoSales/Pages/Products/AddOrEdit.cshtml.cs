using Dapper;
using InfoSales.BusinessL.Interfaces;
using InfoSales.DomainL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace InfoSales.Pages.Products
{
	[Authorize(Roles = "ADMIN,USERS")]
	public class AddOrEditModel : PageModel
    {
        private readonly IProducts ProdRepo;
        public AddOrEditModel(IProducts prodRepo)
        {
            ProdRepo = prodRepo;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public IActionResult OnGetAsync(int id = 0)
        {
            if (id == 0)
            {
                Product = new Product();
                return Page();
            }

            var product = GetProducts(id);
            if (product != null)
            {
                Product = product;
            }
            return Page();
        }

        private Product GetProducts(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@flag", "l");
            param.Add("@id", id);
            var pr = ProdRepo.GetFirstAsync("SpProducts", CommandType.StoredProcedure, param).Result;
            return pr;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@flag", Product.Id == 0 ? "i" : "u");
                param.Add("@id", Product.Id);
                param.Add("@title", Product.Title);
                param.Add("@rate", Product.Rate);
                param.Add("@status", Product.Status);
                await ProdRepo.ExecuteAsync("SpProducts", CommandType.StoredProcedure, param);
            }
            catch (Exception)
            {
            }
            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Login");
        }
    }
}
