using InfoSales.BusinessL.Interfaces;
using InfoSales.DataL;
using InfoSales.DomainL;
using Microsoft.Extensions.Configuration;

namespace InfoSales.BusinessL.Repositories
{
    public class ProductRepo : DbConnections<Product>, IProducts
    {
        public ProductRepo(IConfiguration config) : base(config) { }
    }
}
