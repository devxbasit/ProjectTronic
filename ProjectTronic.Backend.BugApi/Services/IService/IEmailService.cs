namespace ProjectTronic.Backend.BugApi.Services.IService;

public interface IEmailService
{
    Task SendMail(string message, string destinationMail);
}