namespace ASP.NET_Core_The_Studio.Models.SearchQueryModels
{
    using System;
    using System.Collections.Generic;

    public class ElectronicBookQueryModel
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Author { get; init; }

        public int Pages { get; set; }

        public int? CopySold { get; set; }

        public decimal Price { get; set; }

        public string BookRarityName { get; set; }

        public List<GenerQueryModel> Geners { get; set; }
    }
}
