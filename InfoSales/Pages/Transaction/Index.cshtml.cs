using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InfoSales.Data;
using InfoSales.DomainL;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace InfoSales.Pages.Transaction
{
	[Authorize(Roles = "ADMIN,USERS")]
	public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext Context;

        public IndexModel(ApplicationDbContext context)
        {
            Context = context;
        }

        public IList<Transactions> Transactions { get; set; } = default!;

        public SelectList? TransactedCustomers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CustName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FilterDate { get; set; }
        public async Task OnGetAsync()
        {
            if (Context.Transactions != null)
            {
                Transactions = await Context.Transactions.Where(p => p.Status)
                .Include(t => t.Customer)
                .Include(t => t.Product)
                .OrderByDescending(t => t.TransactionDate).ToListAsync();
            }

            IQueryable<string> customerQuery = Context.Customers.OrderBy(p => p.Name).Select(p => p.Name);
            if (DateTime.TryParse(FilterDate, out DateTime dateKey))
            {
                Transactions = Transactions.Where(t => t.TransactionDate.Date == dateKey.Date).ToList();
            }
            if (!string.IsNullOrEmpty(CustName))
            {
                Transactions = Transactions.Where(t => t.CustomerName.Contains(CustName)).ToList();
            }
            TransactedCustomers = new SelectList(await customerQuery.Distinct().ToListAsync());
        }

        public async Task<IActionResult> OnPostDeleteTransaction(int? id)
        {
            if (id == null || Context.Transactions == null)
            {
                return NotFound();
            }
            var transaction = await Context.Transactions.FindAsync(id);

            if (transaction != null)
            {
                transaction.Status = false;
                Context.Transactions.Update(transaction);
                await Context.SaveChangesAsync();
            }

            return RedirectToPage("/Transaction/Index");
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Login");
        }
    }
}
