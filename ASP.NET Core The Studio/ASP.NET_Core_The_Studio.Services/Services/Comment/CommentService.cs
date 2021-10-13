namespace ASP.NET_Core_The_Studio.Services.Services.Comment
{
    using ASP.NET_Core_The_Studio.Data;
    using _Comment = Data.Data.Entities.Comment;

    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext context) => this.context = context;

        public void Add(string bookId, string content, string userId)
        {
            var comment = new _Comment
            {
                ElectronicBookId = bookId,
                Content = content,
                ApplicationUserId = userId,          
            };

            this.context.Comments.Add(comment);
            this.context.SaveChanges();
        }
    }
}
