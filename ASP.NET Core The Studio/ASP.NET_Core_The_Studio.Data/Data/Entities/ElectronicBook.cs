namespace ASP.NET_Core_The_Studio.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static ASP.NET_Core_The_Studio.Data.EntitiesConstants.ElectronicBook;
    //TODO: Add property for word count
    public class ElectronicBook : Product
    {
        [MaxLength(AuthorNameMaxLength)]
        public string Author { get; init; }

        public int Pages { get; set; }

        public int? CopySold { get; set; }

        public decimal Price { get; set; }
        public string BookRarityId { get; set; }

        public BookRarity BookRarity { get; set; }

        public byte[] BookCoverImage { get; set; }

        public byte[] Data { get; set; }
        public ICollection<ElectronicBookGener> ElectronicBookGener { get; init; }
        public ICollection<ElectronicBookApplicationUser> ApplicationUsers { get; init; }
    }
}
