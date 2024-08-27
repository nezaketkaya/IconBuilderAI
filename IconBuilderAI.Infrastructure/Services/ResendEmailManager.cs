using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.Application.Common.Models.Emails;
using Resend;

namespace IconBuilderAI.Infrastructure.Services
{
    public class ResendEmailManager : IEmailService
    {
        private readonly IResend _resend;

        public ResendEmailManager(IResend resend)
        {
            _resend = resend;
        }

        private const string ApiBaseUrl = "http://localhost:5041/api/";
        public Task SendEmailVerificationAsync(EmailSendEmailVerificationDto emailDto, CancellationToken cancellationToken)
        {
            var link = $"{ApiBaseUrl}UsersAuth/VerifyEmail?email={emailDto.Email}&token={emailDto.Token}";

            var message = new EmailMessage();
            message.From = "onboarding@resend.dev";
            message.To.Add(emailDto.Email);
            message.Subject = "Email Verification | IconBuilderAI";
            message.HtmlBody = $"<div><a href=\"{link}\" target=\"_blank\"><strong>Greetings<strong> 👋🏻 from .NET</a></div>";
            
            return _resend.EmailSendAsync(message, cancellationToken);
        }
    }
}
