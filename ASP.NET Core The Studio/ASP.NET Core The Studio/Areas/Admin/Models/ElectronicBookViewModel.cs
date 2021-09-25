namespace ASP.NET_Core_The_Studio.Areas.Admin.Models
{
    using ASP.NET_Core_The_Studio.Data.Entities;
    //TODO: Rewrite this view model and set validations!!!
    public class ElectronicBookViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Author { get; init; }

        public decimal Price { get; set; }

        public BookRarity BookRarity { get; set; }
        public string BookRarityId { get; set; }
    }
}
