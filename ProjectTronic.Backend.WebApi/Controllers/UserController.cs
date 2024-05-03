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
        try
        {
            var users = await _serviceManager.UserService.GetUsers(cancellationToken);
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}