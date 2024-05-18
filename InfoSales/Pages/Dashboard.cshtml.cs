using Dapper;
using InfoSales.BusinessL.Interfaces;
using InfoSales.DomainL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace InfoSales.Pages
{
    [Authorize(Roles = "ADMIN,USERS")]
    public class DashboardModel : PageModel
    {
        private readonly IDashboardVM DashRepo;
        private readonly ITransactions TransRepo;

        public DashboardModel(IDashboardVM dashRepo, ITransactions transRepo)
        {
            DashRepo = dashRepo;
            TransRepo = transRepo;
        }

        [BindProperty]
        public DashboardVM CountData { get; set; }
        [BindProperty]
        public List<RecentTrans> RecentSales { get; set; }
        public void OnGet()
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("flag", "count");

            CountData = DashRepo.GetFirstAsync("SpDashboard", CommandType.StoredProcedure, param).Result;

            param = new DynamicParameters();
            param.Add("flag", "sales");
            var salesTrend = TransRepo.GetListAsync("SpDashboard", CommandType.StoredProcedure, param).Result.ToList();
            ViewData["SalesTrend"] = salesTrend.OrderBy(s=>s.TransactionDate)
                .Select(x => new SalesTrend()
                {
                    Date = x.TransactionDate.ToShortDateString(),
                    Amount = x.TotalAmount
                }).ToList();

            param = new DynamicParameters();
            param.Add("flag", "recent");
            var recentTransaction = TransRepo.GetListAsync("SpDashboard", CommandType.StoredProcedure, param).Result.ToList();
            RecentSales = recentTransaction.Select(x => new RecentTrans()
            {
                Date = x.TransactionDate,
                Amount = x.TotalAmount,
                Title = x.ProductTitle
            }).ToList();
            
            param = new DynamicParameters();
            param.Add("flag", "byProduct");
            var salesByProduct = TransRepo.GetListAsync("SpDashboard", CommandType.StoredProcedure, param).Result.ToList();
            ViewData["ByProduct"] = salesByProduct.Select(x => new SalesByProduct()
            {
                Amount = x.TotalAmount,
                Product = x.ProductTitle
            }).ToList();
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToPage("/Login");
        }
    }

    public class RecentTrans
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
    }

    public class SalesByProduct
    {
        public string Product { get; set; }
        public decimal Amount { get; set; }
    }

    public class SalesTrend
    {
        public string Date { get; set; }
        public decimal Amount { get; set; }
    }
}
