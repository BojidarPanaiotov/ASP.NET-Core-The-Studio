namespace ASP.NET_Core_The_Studio.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using ASP.NET_Core_The_Studio.Services.Services.Comment;
    using ASP.NET_Core_The_Studio.Models.Comments;
    using ASP.NET_Core_The_Studio.Infrastructure.Extensions;

    public class CommentController : Controller
    {
        private readonly IElectronicBookService electronicBookService;
        private readonly ICommentService commentService;

        public CommentController(
            IElectronicBookService electronicBookService,
            ICommentService commentService)
        {
            this.electronicBookService = electronicBookService;
            this.commentService = commentService;
        }

        [Authorize]
        [HttpPost]
        public void Add([FromBody] CommentFormModel comment)
        {
            if (!(electronicBookService.IsExist(comment.BookId) && this.ModelState.IsValid))
            {
                return;
            }

            this.commentService.Add(comment.BookId, comment.Content, this.User.Id());
        }
    }
}
