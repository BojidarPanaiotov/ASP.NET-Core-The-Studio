namespace ASP.NET_Core_The_Studio.Areas.Admin.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ASP.NET_Core_The_Studio.Data.Entities;

    using static Data.EntitiesConstants.ElectronicBook;

    public class ElectronicBookFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(AuthorNameMaxLength, MinimumLength = AuthorNameMinLength)]
        public string Author { get; init; }

        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        public BookRarity BookRarity { get; set; }

        public string BookRarityId { get; set; }

        public List<BookRarity> Categories { get; init; }
    }
}
