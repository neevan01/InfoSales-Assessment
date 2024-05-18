using Dapper;
using InfoSales.DomainL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

namespace InfoSales.Pages.Transaction
{
	[Authorize(Roles = "ADMIN,USERS")]
	public class AddOrEditModel : PageModel
    {
        private readonly Data.ApplicationDbContext Context;

        public AddOrEditModel(Data.ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id = 0)
        {
            if (id == 0)
            {
                Transactions = new Transactions();
            }
            else
            {
                var transactions = await Context.Transactions.Include(p => p.Product).FirstOrDefaultAsync(m => m.TransactionId == id);
                Transactions = transactions;
            }

            ViewData["CustomerId"] = new SelectList(Context.Customers.Where(p => p.Status), "Id", "Name");
            ViewData["ProductId"] = new SelectList(Context.Products.Where(p => p.Status), "Id", "Title");

            return Page();
        }

        [BindProperty]
        public Transactions Transactions { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                if (Transactions.TransactionId == 0)
                {
                    Context.Add(Transactions);
                }
                else
                {
                    Context.UpdateRange(Transactions);
                }
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
            }

            return RedirectToPage("./Index");
        }


        public async Task<IActionResult> OnPostRateByProduct(string? pId)
        {
            var trans = await Context.Products
                .Where(p => p.Id == Convert.ToInt32(pId))
                .Select(p => new
                {
                    p.Rate
                }).FirstOrDefaultAsync();
            return new JsonResult(trans);
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Login");
        }
    }
}
