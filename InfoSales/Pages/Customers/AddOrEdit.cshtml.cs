using InfoSales.Data;
using InfoSales.DomainL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace InfoSales.Pages.Customers
{
    [Authorize(Roles = "ADMIN,USERS")]
    public class AddOrEditModel : PageModel
    {
        //using the EF along with stored procedure 
        private readonly ApplicationDbContext Context;

        public AddOrEditModel(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || Context.Customers == null)
            {
                Customer = new Customer();
                return Page();
            }
            var param = new SqlParameter[] {
                    new SqlParameter("@flag", "l"),
                    new SqlParameter("@id", id)
                };
            var customer = await Context.Customers.FromSqlRaw("EXEC SpCustomers @flag, @id", param).ToListAsync();
            if (customer != null)
            {
                Customer = customer[0];
            }
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid || Context.Customers == null || Customer == null)
            {
                return Page();
            }
            try
            {
                var param = new SqlParameter[] {
                    new SqlParameter("@flag", Customer.Id == 0 ? "i" : "u"),
                    new SqlParameter("@id", Customer.Id),
                    new SqlParameter("@name", Customer.Name),
                    new SqlParameter("@address", Customer.Address),
                    new SqlParameter("@phone", Customer.Phone),
                    new SqlParameter("@status", Customer.Status),
                };
                Context.Database.ExecuteSqlRaw("EXEC SpCustomers @flag, @id, @name, @address, @phone, @status", param);
            }
            catch (Exception)
            {
                if (Customer.Id != 0 && !CustomerExists(Customer.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CustomerExists(int id)
        {
            return Context.Customers.FromSqlRaw("EXEC SpCustomers @flag, @id", new SqlParameter("@flag", "l"), new SqlParameter("@id", id)).ToListAsync().Result.Count > 0;
        }

        //logout action
        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Login");
        }
    }
}
