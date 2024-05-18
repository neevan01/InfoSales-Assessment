using InfoSales.BusinessL.Interfaces;
using InfoSales.DataL;
using InfoSales.DomainL;
using Microsoft.Extensions.Configuration;

namespace InfoSales.BusinessL.Repositories
{
    public class UserRepo : DbConnections<User>, IUsers
    {
        public UserRepo(IConfiguration config) : base(config) { }
    }
}
