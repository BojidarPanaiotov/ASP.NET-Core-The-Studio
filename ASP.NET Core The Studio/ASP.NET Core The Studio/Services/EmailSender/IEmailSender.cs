namespace ASP.NET_Core_The_Studio.Services.EmailSender
{
    public interface IEmailSender
    {
        void SendEmail(string receiver, string subject, string content);
    }
}
