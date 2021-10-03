namespace ASP.NET_Core_The_Studio.Models
{
    using System.Collections.Generic;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;

    public class SearchQueryModel
    {
        public int TotalBooks { get; set; }

        public List<BookRarityQueryModel> BookRarities { get; init; }

        public List<ElectronicBookQueryModel> ElectronicBooks { get; init; }

        public List<GenerQueryModel> Geners { get; init; }
    }
}
