using ProjectTronic.Backend.Application.Dto;

namespace ProjectTronic.Backend.Application.Services.IService;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken);
    Task<UserDto> GetUser(CancellationToken cancellationToken, int userId);
    Task<Boolean> DeleteUser(CancellationToken cancellationToken, int userId);


}