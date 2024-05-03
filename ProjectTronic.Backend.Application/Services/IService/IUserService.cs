using ProjectTronic.Backend.Application.Dto;

namespace ProjectTronic.Backend.Application.Services.IService;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken);
}