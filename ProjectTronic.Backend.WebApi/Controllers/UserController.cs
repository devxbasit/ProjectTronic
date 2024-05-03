using Microsoft.AspNetCore.Mvc;
using ProjectTronic.Backend.Application.Services.IService;

namespace ProjectTronic.Backend.WebApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public UserController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var users = await _serviceManager.UserService.GetUsers(cancellationToken);
        return Ok(users);
    }

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUser(CancellationToken cancellationToken, int userId)
    {
        var user = await _serviceManager.UserService.GetUser(cancellationToken, userId);
        return Ok(user);
    }

    [HttpDelete("{userId:int}")]
    public async Task<IActionResult> DeleteUser(CancellationToken cancellationToken, int userId)
    {
        var users = await _serviceManager.UserService.DeleteUser(cancellationToken, userId);
        return Ok(users);
    }
}