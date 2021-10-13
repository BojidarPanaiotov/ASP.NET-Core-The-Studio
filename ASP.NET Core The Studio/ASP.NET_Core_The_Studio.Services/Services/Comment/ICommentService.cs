namespace ASP.NET_Core_The_Studio.Services.Services.Comment
{
    public interface ICommentService
    {
        void Add(string bookId, string content, string userId);
    }
}
