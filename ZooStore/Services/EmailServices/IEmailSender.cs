using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace ZooStore.Services.EmailServices
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfiguration)
        {
            _emailConfig = emailConfiguration;
        }
        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);
        }

        private void Send(MimeMessage emailMessage)
        {
            using(SmtpClient client = new())
            {
                try
                {
                    client.Connect(_emailConfig.SmptServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

                    client.Send(emailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            MimeMessage emailMessage = new();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(TextFormat.Text)
            {
                Text = message.Content
            };

            return emailMessage;

        }
    }
}
