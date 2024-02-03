using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Access;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }
    public async Task<IEnumerable<T>> LoadData<T, U>(string procedure, U parameters, string connId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connId));
        return await connection.QueryAsync<T>(procedure, parameters, commandType: CommandType.StoredProcedure);
    }
    public async Task SaveData<T>(string procedure, T parameters, string connId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connId));
        await connection.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
    }
}
