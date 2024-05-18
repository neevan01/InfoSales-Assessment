using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSales.Data;
using InfoSales.DomainL;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace InfoSales.Pages.Customers
{
    [Authorize(Roles = "ADMIN,USERS")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext Context;

        public IndexModel(ApplicationDbContext context)
        {
            Context = context;
        }

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync(string SearchString = "")
        {
            if (Context.Customers != null)
            {
                var param = new SqlParameter[] {
                    new SqlParameter("flag", "l")
                };
                Customer = await Context.Customers.FromSqlRaw("EXEC SpCustomers @flag", param).ToListAsync();
                if (!string.IsNullOrEmpty(SearchString))
                {
                    Customer = Customer.Where(s => s.Name.Contains(SearchString)).ToList();
                }
            }
        }

        public async Task<IActionResult> OnPostDeleteCustomer(int? id)
        {
            if (id == null || Context.Customers == null)
            {
                return NotFound();
            }
            var param = new SqlParameter[] {
                    new SqlParameter("@flag", "l"),
                    new SqlParameter("@id", id)
                };
            var customer = await Context.Customers.FromSqlRaw("EXEC SpCustomers @flag, @id", param).ToListAsync();

            if (customer != null)
            {
                param = new SqlParameter[] {
                    new SqlParameter("flag", "d"),
                    new SqlParameter("id", id)
                };
                Context.Database.ExecuteSqlRaw("EXEC SpCustomers @flag, @id", param);
            }
            return RedirectToPage("/Customers/Index");
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Login");
        }

    }
}
