namespace ASP.NET_Core_The_Studio.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.EntitiesConstants.Product;
    public abstract class Product
    {
        [Required]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string UserId { get; init; }
        [Required]
        public ApplicationUser User { get; init; }
    }
}
