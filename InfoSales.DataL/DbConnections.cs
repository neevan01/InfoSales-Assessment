using Dapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace InfoSales.DataL
{
    public class DbConnections<T> : IConnection<T> where T : class
    {
        //implementation of the interface IConfiguration
        private readonly IConfiguration Config;
        public DbConnections(IConfiguration config)
        {
            Config = config;
        }

        private IDbConnection OpenCon()
        {
            var con = GetDbConnection();
            con.Open();
            return con;
        }

        public void Dispose()
        {
            GetDbConnection().Close();
        }

        public async Task ExecuteAsync(string query, CommandType type, DynamicParameters? param = null)
        {
            IDbConnection con = OpenCon();
            await con.ExecuteAsync(query, param, commandType: type);
        }

        public Task<IEnumerable<T>> FilterAsync(string query, CommandType type, DynamicParameters? param = null)
        {
            //to filter 
            throw new NotImplementedException();
        }

        public IDbConnection GetDbConnection()
        {
            return new SqlConnection(Config.GetConnectionString("MyConn"));
        }

        public async Task<T> GetFirstAsync(string query, CommandType type, DynamicParameters? param = null)
        {
            IDbConnection con = OpenCon();
            return await SqlMapper.QueryFirstOrDefaultAsync<T>(con, query, param, commandType: type);
        }

        public async Task<IEnumerable<T>> GetListAsync(string query, CommandType type, DynamicParameters? param = null)
        {
            IDbConnection con = OpenCon();
            return await SqlMapper.QueryAsync<T>(con, query, param, commandType: type);
        }

        public Task<int> DeleteAsyncReturn(string query, CommandType type, DynamicParameters? param = null)
        {
            throw new NotImplementedException();
        }
    }
}
