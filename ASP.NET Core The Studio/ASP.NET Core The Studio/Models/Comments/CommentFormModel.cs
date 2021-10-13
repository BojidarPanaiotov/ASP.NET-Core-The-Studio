namespace ASP.NET_Core_The_Studio.Models.Comments
{
    using System.ComponentModel.DataAnnotations;

    using static ASP.NET_Core_The_Studio.Data.EntitiesConstants.Comment;

    public class CommentFormModel
    {
        [Required]
        public string BookId { get; init; }

        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        [Required]
        public string Content { get; init; }
    }
}
