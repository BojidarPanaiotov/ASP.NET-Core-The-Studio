namespace ASP.NET_Core_The_Studio.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using static ASP.NET_Core_The_Studio.Data.EntitiesConstants.Product;

    public abstract class Product
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public string UserId { get; init; }
        public ApplicationUser User { get; init; }
    }
}
