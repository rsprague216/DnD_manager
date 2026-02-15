using DnD_Manager.Models;
using Microsoft.AspNetCore.Identity;

namespace DnD_Manager.Services;

public class StubEmailSender : IEmailSender<ApplicationUser>
{
    private readonly ILogger<StubEmailSender> _logger;

    public StubEmailSender(ILogger<StubEmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        _logger.LogInformation("Email confirmation for {Email}: {Link}", email, confirmationLink);
        return Task.CompletedTask;
    }

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        _logger.LogInformation("Password reset for {Email}: {Link}", email, resetLink);
        return Task.CompletedTask;
    }

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        _logger.LogInformation("Password reset code for {Email}: {Code}", email, resetCode);
        return Task.CompletedTask;
    }
}
