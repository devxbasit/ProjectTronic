using Microsoft.Data.SqlClient;
using ProjectTronic.Backend.Core.Services.IService;

namespace ProjectTronic.Backend.Core.Services;

public class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly string _connectionString;

    public SqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqlConnection Create()
    {
        return new SqlConnection(_connectionString);
    }
}