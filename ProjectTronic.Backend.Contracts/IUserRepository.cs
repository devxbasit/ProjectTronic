using ProjectTronic.Backend.Core.Models;

namespace ProjectTronic.Backend.Contracts;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);
    Task<User?> GetUser(CancellationToken cancellationToken, int userId);
    Task<Boolean> DeleteUser(CancellationToken cancellationToken, int userId);
}