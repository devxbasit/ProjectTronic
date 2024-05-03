using AutoMapper;
using ProjectTronic.Backend.Application.Dto;
using ProjectTronic.Backend.Application.Services.IService;
using ProjectTronic.Backend.Contracts;

namespace ProjectTronic.Backend.Application.Services;

public class UserService : IUserService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            var user = await _repositoryManager.UserRepository.GetAllUsers(cancellationToken);
            var userDto = _mapper.Map<IEnumerable<UserDto>>(user);
            return userDto;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}