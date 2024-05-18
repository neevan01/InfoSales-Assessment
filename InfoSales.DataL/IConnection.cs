using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSales.DataL
{
    public interface IConnection<T> : IDisposable where T : class
    {
        //interface with collection of the generally used oprations to reduce the code redundancy
        IDbConnection GetDbConnection();
        Task<T> GetFirstAsync(string query, CommandType type, DynamicParameters? param = null);
        Task<IEnumerable<T>> GetListAsync(string query, CommandType type, DynamicParameters? param = null);
        //deals with both add and delete
        Task ExecuteAsync(string query, CommandType type, DynamicParameters? param = null);
        //used when shomething is to returned after deleting
        Task<int> DeleteAsyncReturn(string query, CommandType type, DynamicParameters? param = null);
    }
}
