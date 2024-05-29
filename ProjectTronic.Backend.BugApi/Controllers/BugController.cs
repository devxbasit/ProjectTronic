using Hangfire;
using Microsoft.AspNetCore.Mvc;
using ProjectTronic.Backend.BugApi.Models;
using ProjectTronic.Backend.BugApi.Services.IService;

namespace ProjectTronic.Backend.BugApi.Controllers;

[Route("api/v1/bug")]
[ApiController]
public class BugController : ControllerBase
{
    private readonly IEmailService _emailService;

    public BugController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public IActionResult AddBug([FromBody] Email email)
    {
        // fire & forget job
        //var jobId = BackgroundJob.Enqueue<IEmailService>(x => x.SendMail(email.Message, email.ToEmail));
        var jobId = BackgroundJob.Enqueue(() => _emailService.SendMail(email.Message, email.ToEmail));

        //Delayed
        var delayJobId =
            BackgroundJob.Schedule<IEmailService>(x => x.SendMail(email.Message, email.ToEmail),
                TimeSpan.FromSeconds(10));

        // Continuation Jobs
        BackgroundJob.ContinueJobWith(delayJobId, () => Console.WriteLine("Continuation Job In Action"));


        //recurring 
        RecurringJob.AddOrUpdate("JobId",
            () => Console.WriteLine("Recurring Job In Action"),
            Cron.Minutely);
        return Ok($"JobId: {jobId}");
    }
}