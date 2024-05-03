using ProjectTronic.Backend.Contracts;

namespace ProjectTronic.Backend.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    public RepositoryManager()
    {
        _userRepository = new UserRepository();
    }

    private UserRepository _userRepository { get; set; }
    public IUserRepository UserRepository => _userRepository;
}