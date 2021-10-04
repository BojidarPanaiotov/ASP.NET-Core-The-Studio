namespace ASP.NET_Core_The_Studio.Data.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ASP.NET_Core_The_Studio.Data.Entities;

    using static ASP.NET_Core_The_Studio.Data.EntitiesConstants.Comment;

    public class Reply
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; init; }

        public int Likes { get; init; }

        public string ApplicationUserId { get; init; }

        public ApplicationUser ApplicationUser { get; init; }

        public string CommentId { get; init; }

        public Comment Comment { get; init; }
    }
}
