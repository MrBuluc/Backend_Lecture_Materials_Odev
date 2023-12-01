using Resend;
using YetGenAkbankJump.Domain.Identity;
using YetGenAkbankJump.Shared.Services;

namespace YetGenAkbankJump.IdentityMVC.Services
{
    public class EmailService : IEmailService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IResend _resend;

        public EmailService(IWebHostEnvironment environment, IResend resend)
        {
            _environment = environment;
            _resend = resend;
        }

        public async Task PrepareAndSendVerifyEmail(string token, string email)
        {
            await EmailSendAsync(email, "Bülüç Klein - E-Posta Doğrulama", 
                await PrepareVerifyEmail(token, email));
        }

        public async Task<string> PrepareVerifyEmail(string token, string email)
        {
            return (await System.IO.File.ReadAllTextAsync(Path.Combine(
                _environment.WebRootPath, "email-templates", "verify-email.html")))
                .Replace("{{Title}}", "Bülüç Klein - E-Posta Doğrulama")
                .Replace("{{Description}}", "Bülüç Klein uygulamamıza hoş geldiniz. E-posta adresinizi doğrulmak için lütfen aşağıdaki \"Onayla\" butonuna tıklayınız.")
                .Replace("{{ButtonLink}}", $"https://localhost:7206/Auth/VerifyEmail?email={email}&token={token}")
                .Replace("{{ButtonText}}", "Onayla");
        }

        public async Task EmailSendAsync(string to, string subject, string htmlBody)
        {
            await _resend.EmailSendAsync(new EmailMessage()
            {
                From = "hkcblc@gmail.com",
                To = to,
                Subject = subject,
                HtmlBody = htmlBody
            });
        }
    }
}
