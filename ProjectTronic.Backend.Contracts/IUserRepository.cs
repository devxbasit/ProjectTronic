using ProjectTronic.Backend.Core.Models;

namespace ProjectTronic.Backend.Contracts;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers(CancellationToken cancellationToken);
}