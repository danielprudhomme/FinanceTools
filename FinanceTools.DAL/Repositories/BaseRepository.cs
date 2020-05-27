using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace FinanceTools.DAL.Repositories
{
    public class BaseRepository
    {
        protected readonly IConfiguration _configuration;

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected SqlConnection GetSqlConnection()
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            return new SqlConnection(connectionString);
        }

        protected async Task<IEnumerable<T>> Query<T>(string storedProcedureName, DynamicParameters queryParameters = null)
        {
            using (var connection = GetSqlConnection())
            {
                return await connection.QueryAsync<T>(storedProcedureName, queryParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        protected async Task Execute(string storedProcedureName, DynamicParameters queryParameters = null)
        {
            using (var connection = GetSqlConnection())
            {
                await connection.ExecuteAsync(storedProcedureName, queryParameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
