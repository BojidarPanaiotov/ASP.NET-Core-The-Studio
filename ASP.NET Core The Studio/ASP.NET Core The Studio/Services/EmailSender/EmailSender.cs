namespace ASP.NET_Core_The_Studio.Services.EmailSender
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    public class EmailSender : IEmailSender
    {
        private const string sender = "psihasal@gmail.com";
        private const string senderPassword = "123ludmezo123zombie123";

        public void SendEmail(string receiver, string subject, string content)
        {
            string to = "psihasal@gmail.com"; //To address    
            string from = sender; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            using SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            {
                client.Credentials = new NetworkCredential(from, senderPassword);
                client.EnableSsl = true;
            }
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
