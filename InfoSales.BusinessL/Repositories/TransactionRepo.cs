using InfoSales.BusinessL.Interfaces;
using InfoSales.DataL;
using InfoSales.DomainL;
using Microsoft.Extensions.Configuration;

namespace InfoSales.BusinessL.Repositories
{
    public class TransactionRepo : DbConnections<Transactions>, ITransactions
    {
        public TransactionRepo(IConfiguration config) : base(config) { }
    }
}
