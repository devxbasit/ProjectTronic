using ProjectTronic.Backend.BugApi.Services.IService;

namespace ProjectTronic.Backend.BugApi.Services;

public class EmailService : IEmailService
{
    public async Task SendMail(string message, string destinationMail)
    {
        Console.WriteLine($"Sending email, message: {message} ToEmail: {destinationMail}");
        await Task.CompletedTask;
    }
}