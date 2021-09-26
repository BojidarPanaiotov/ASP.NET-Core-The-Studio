namespace ASP.NET_Core_The_Studio.Services.EmailSender
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Text;

    public class EmailSender
    {
        public static void SendEmail()
        {
            string to = "izroda4@gmail.com"; //To address    
            string from = "izroda4@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;

            using SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            {
                client.Credentials = new NetworkCredential(from, "maikati123");
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
