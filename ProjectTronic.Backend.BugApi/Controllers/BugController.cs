using Hangfire;
using Microsoft.AspNetCore.Mvc;
using ProjectTronic.Backend.BugApi.Models;
using ProjectTronic.Backend.BugApi.Services.IService;

namespace ProjectTronic.Backend.BugApi.Controllers;

[Route("api/v1/bug")]
[ApiController]
public class BugController : ControllerBase
{
    public BugController()
    {
    }

    [HttpPost]
    public IActionResult AddBug([FromBody] Email email)
    {
        // fire & forget job
        var jobId = BackgroundJob.Enqueue<IEmailService>(x => x.SendMail(email.Message, email.ToEmail));

        return Ok($"JobId: {jobId}");
    }
}