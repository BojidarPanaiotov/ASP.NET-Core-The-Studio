namespace ASP.NET_Core_The_Studio.Models
{
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using System.Collections.Generic;
    public class SearchQueryModel
    {
        public List<BookRarityQueryModel> BookRarities { get; init; }
        public List<ElectronicBookQueryModel> ElectronicBooks { get; init; }
        public List<GenerQueryModel> Geners { get; init; }
        public string SearchTerm { get; set; }

    }
}
