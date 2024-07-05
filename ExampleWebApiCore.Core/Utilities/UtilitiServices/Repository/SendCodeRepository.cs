using ExampleWebApiCore.Core.Utilities.UtilitiServices.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ExampleWebApiCore.Core.Utilities.UtilitiServices.Repository
{
    public class SendCodeRepository : ISendCodeRepository
    {
        private IConfiguration _configuration;
        public SendCodeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(string to, string subject, string body)
        {
            var server = _configuration.GetSection("mailService:Server").Value;
            var userNameEmail = _configuration.GetSection("mailService:UserName").Value;
            var passwordEmail = _configuration.GetSection("mailService:Password").Value;
            var subjectEmail = _configuration.GetSection("mailService:Subject").Value;
            var PortEmail = _configuration.GetSection("mailService:Port").Value;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(server);
            mail.From = new MailAddress(userNameEmail, subjectEmail);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpServer.Port = Convert.ToInt32(PortEmail);
            SmtpServer.Credentials = new System.Net.NetworkCredential(userNameEmail, passwordEmail);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        public Task SendSms(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
