using System.Data.SqlClient;
using Dapper;
using ProjectTronic.Backend.Contracts;
using ProjectTronic.Backend.Core.Models;

namespace ProjectTronic.Backend.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken)
    {
        try
        {
            using var conn = new SqlConnection(
                "Data Source = localhost,1433; Initial Catalog = ProjectTronic; Integrated Security = false; User Id = sa; Password = docker-147852369; TrustServerCertificate = true");
            const string sql = "SELECT * FROM [User];";
            var users = await conn.QueryAsync<User>(sql);
            return users;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}