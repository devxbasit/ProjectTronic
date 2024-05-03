using Dapper;
using Microsoft.Data.SqlClient;
using ProjectTronic.Backend.Contracts;
using ProjectTronic.Backend.Core.Models;

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

    public async Task<User?> GetUser(CancellationToken cancellationToken, int userId)
    {
        string sql = $"SELECT * FROM [User] WHERE UserId = {userId}";
        var users = await _conn.QueryAsync<User>(sql, cancellationToken);

        return users.FirstOrDefault();
    }

    public async Task<bool> DeleteUser(CancellationToken cancellationToken, int userId)
    {
        string sql = $"DELETE FROM [User] WHERE UserId = {userId}";
        int rowsAffected = await _conn.ExecuteAsync(sql, cancellationToken);
        return true;
    }
}