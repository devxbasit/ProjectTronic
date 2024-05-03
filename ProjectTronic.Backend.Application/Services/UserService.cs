using AutoMapper;
using ProjectTronic.Backend.Application.Dto;
using ProjectTronic.Backend.Application.Services.IService;
using ProjectTronic.Backend.Contracts;

namespace ProjectTronic.Backend.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetAllUsers(cancellationToken);
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