namespace ASP.NET_Core_The_Studio.Services.EmailSender
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    public class EmailSender : IEmailSender
    {
        private const string receiver = "psihasal@gmail.com";
        private const string receiverPassword = "123ludmezo123zombie123";

        public bool Send(string sender, string subject, string content)
        {
            string to = receiver; //To address    
            string from = receiver; //From address    
            MailMessage message = new MailMessage(from, to);

            message.Subject = subject;
            message.Body = content + Environment.NewLine + sender;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            using SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            {
                client.Credentials = new NetworkCredential(from, receiverPassword);
                client.EnableSsl = true;
            }
            try
            {
                client.Send(message);

                return true;
            }
            catch (Exception ex)
            {
                //TODO: save in log
                return false;
            }
        }
    }
}
