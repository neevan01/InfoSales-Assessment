using InfoSales.BusinessL.Interfaces;
using InfoSales.DataL;
using InfoSales.DomainL;
using Microsoft.Extensions.Configuration;

namespace InfoSales.BusinessL.Repositories
{
    public class CustomerRepo : DbConnections<Customer>, ICustomers
    {
        public CustomerRepo(IConfiguration config) : base(config) { }
    }
}
