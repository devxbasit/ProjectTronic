using Microsoft.Data.SqlClient;
using ProjectTronic.Backend.Contracts;
using ProjectTronic.Backend.Core.Services.IService;

namespace ProjectTronic.Backend.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly SqlConnection _conn;

    public RepositoryManager(ISqlConnectionFactory sqlConnectionFactory)
    {
        _conn = sqlConnectionFactory.Create();
        _userRepository = new UserRepository(_conn);
    }

    private UserRepository _userRepository { get; set; }
    public IUserRepository UserRepository => _userRepository;
}