namespace ASP.NET_Core_The_Studio.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using static Data.EntitiesConstants.ElectronicBook;
    //TODO: Add property for word count
    public class ElectronicBook : Product
    {
        [MaxLength(AuthorNameMaxLength)]
        public string Author { get; init; }

        [Range(MinPage,MaxPage)]
        public int Pages { get; set; }

        public int? CopySold { get; set; }

        [Range(typeof(decimal),MinPrice,MaxPrice)]
        public decimal Price { get; set; }
        public string BookRarityId { get; set; }

        public BookRarity BookRarity { get; set; }

        public byte[] BookCoverImage { get; set; }

        public byte[] Data { get; set; }
    }
}
