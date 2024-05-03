using AutoMapper;
using ProjectTronic.Backend.Application.Services.IService;
using ProjectTronic.Backend.Contracts;

namespace ProjectTronic.Backend.Application.Services;

public class ServiceManager : IServiceManager
{
    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _userService = new UserService(repositoryManager, mapper);
    }

    private IUserService _userService { get; }

    public IUserService UserService => _userService;
}