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
    public class IndexModel : PageModel
    {
        public IList<Product> Products { get; set; } = default!;
        private readonly IProducts ProdRepo;
        public IndexModel(IProducts prodRepo)
        {
            ProdRepo = prodRepo;
        }

        public void OnGet(string SearchString = "")
        {
            Products = GetProducts() ?? new List<Product>();
            if (!string.IsNullOrEmpty(SearchString))
            {
                Products = Products.Where(s => s.Title.Contains(SearchString)).ToList();
            }
        }

        private IList<Product>? GetProducts(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@flag", "l");
            param.Add("@id", id);
            var pr = ProdRepo.GetListAsync("SpProducts", CommandType.StoredProcedure, param).Result.ToList();
            return pr;
        }


        public async Task<IActionResult> OnPostDeleteProduct(int? id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("flag", "d");
                param.Add("id", id);
                await ProdRepo.ExecuteAsync("SpProducts", CommandType.StoredProcedure, param);
            }
            catch (Exception) { }
            return RedirectToPage("/Products/Index");
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Login");
        }
    }
}
