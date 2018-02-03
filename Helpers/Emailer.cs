using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;

namespace Utilities.Helpers
{
    public class Emailer
    {
        private readonly string SmtpServerAddress;

        public Emailer()
        {
            if (ConfigurationManager.AppSettings["Utilities_SmtpRelay"] == null ||
                ConfigurationManager.AppSettings["Utilities_SmtpRelay"].Equals("[SMTP_SERVER]"))
            {
                throw new ConfigurationErrorsException("Error: <appSettings /> key Utilities_SmtpRelay must be defined.");
            }

            SmtpServerAddress = ConfigurationManager.AppSettings["Utilities_SmtpRelay"];
        }

        public void SendEmail(string to, string from, string subject, string body, bool bodyAsHtml = false)
        {
            SendEmail(new List<string> { to }, from, subject, body, bodyAsHtml);
        }
        public void SendEmail(List<string> tos, string from, string subject, string body, bool bodyAsHtml = false)
        {
            SendEmail(tos, from, null, null, subject, body, bodyAsHtml);
        }
        public void SendEmail(List<string> tos, string from, List<string> ccList, string subject, string body, bool bodyAsHtml = false)
        {
            SendEmail(tos, from, ccList, null, subject, body, bodyAsHtml);
        }
        public void SendEmail(List<string> tos, string from, List<string> ccList, List<string> bccList, string subject, string body, bool bodyAsHtml = false)
        {
            MailMessageBuilder mailMessageBuilder = new MailMessageBuilder();

            mailMessageBuilder.AddTos(tos);
            mailMessageBuilder.AddCCs(ccList);
            mailMessageBuilder.AddBCCs(bccList);
            mailMessageBuilder.SetFrom(from);

            mailMessageBuilder.SetSubject(subject);
            mailMessageBuilder.SetBody(body);
            mailMessageBuilder.SetBodyAsHtml(bodyAsHtml);

            using (var mailMessage = mailMessageBuilder.Build())
            {
                SendEmail(mailMessage);
            }
        }

        public void SendEmail(MailMessage mail)
        {
            using (var client = new SmtpClient(SmtpServerAddress))
            {
                client.Send(mail);
            }
        }

    }

    public class MailMessageBuilder
    {
        private MailMessage _mailMessage;

        public MailMessageBuilder()
        {
            _mailMessage = new MailMessage();
        }
        public MailMessage Build()
        {
            return _mailMessage;
        }

        public void AddTos(List<string> tos)
        {
            if (tos != null)
            {
                foreach (var to in tos)
                {
                    _mailMessage.To.Add(new MailAddress(to));
                }
            }
        }

        public void AddCCs(List<string> ccList)
        {
            if (ccList != null)
            {
                foreach (var cc in ccList)
                {
                    _mailMessage.CC.Add(new MailAddress(cc));
                }
            }
        }

        public void AddBCCs(List<string> bccList)
        {


            if (bccList != null)
            {
                foreach (var bcc in bccList)
                {
                    _mailMessage.Bcc.Add(new MailAddress(bcc));
                }
            }
        }

        public void SetFrom(string from)
        {
            _mailMessage.From = new MailAddress(from);
        }
        public void SetSubject(string subject)
        {
            _mailMessage.Subject = subject;
        }
        public void SetBody(string body)
        {
            _mailMessage.Body = body;
        }
        public void SetBodyAsHtml(bool bodyAsHtml)
        {
            _mailMessage.IsBodyHtml = bodyAsHtml;
        }
    }
}