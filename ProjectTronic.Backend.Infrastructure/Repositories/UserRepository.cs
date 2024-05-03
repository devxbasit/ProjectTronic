using System.Data.SqlClient;
using Dapper;
using ProjectTronic.Backend.Contracts;
using ProjectTronic.Backend.Core.Models;
using ISqlConnectionFactory = ProjectTronic.Backend.Core.Services.IService.ISqlConnectionFactory;

namespace ProjectTronic.Backend.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private SqlConnection _conn;

    public UserRepository(SqlConnection sqlConnection)
    {
        _conn = sqlConnection;
    }

    public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
    {
        try
        {
            const string sql = "SELECT * FROM [User];";
            var users = await _conn.QueryAsync<User>(sql);
            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}