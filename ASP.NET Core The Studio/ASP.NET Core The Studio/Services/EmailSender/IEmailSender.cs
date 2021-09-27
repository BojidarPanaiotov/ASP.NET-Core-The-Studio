namespace ASP.NET_Core_The_Studio.Services.EmailSender
{
    public interface IEmailSender
    {
        bool Send(string receiver, string subject, string content);
    }
}
