using Microsoft.AspNetCore.Identity.UI.Services;

namespace WorkoutTrackingApp.Utilities
{
    public class DumbEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            
            return Task.CompletedTask;
        }
    }
}
