using Microsoft.AspNetCore.Mvc;
using ProjectTronic.Backend.Application.Services.IService;

namespace ProjectTronic.Backend.WebApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        try
        {
            var users = await _userService.GetUsers(cancellationToken);
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}