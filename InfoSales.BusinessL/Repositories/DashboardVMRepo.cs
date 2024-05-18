using InfoSales.BusinessL.Interfaces;
using InfoSales.DataL;
using InfoSales.DomainL;
using Microsoft.Extensions.Configuration;

namespace InfoSales.BusinessL.Repositories
{
    public class DashboardVMRepo : DbConnections<DashboardVM>, IDashboardVM
    {
        public DashboardVMRepo(IConfiguration configuration) : base(configuration) { }
    }
}
