namespace ASP.NET_Core_The_Studio.Models.Feedbacks
{
    using System.ComponentModel.DataAnnotations;

    using static ASP.NET_Core_The_Studio.Data.EntitiesConstants.ApplicationUser;
    using static ASP.NET_Core_The_Studio.Data.EntitiesConstants.Feedback;

    public class FeedbackFormModel
    {
        [Required]
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength)]
        public string Username { get; init; }

        [Required]
        [EmailAddress]
        public string Sender { get; init; }

        [Required]
        [StringLength(SubjectMaxLength, MinimumLength = SubjectMinLength)]
        public string Subject { get; init; }

        [Required]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
        public string Content { get; init; }
    }
}
