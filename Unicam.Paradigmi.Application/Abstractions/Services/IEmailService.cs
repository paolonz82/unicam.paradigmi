namespace Unicam.Paradigmi.Application.Abstractions.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string body);
    }
}
