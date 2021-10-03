namespace ASP.NET_Core_The_Studio.Models
{
    using System.Collections.Generic;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;

    public class SearchQueryModel
    {
        public int TotalBooks { get; set; }

        public IEnumerable<BookRarityQueryModel> BookRarities { get; init; }

        public IEnumerable<ElectronicBookServiceModel> ElectronicBooks { get; init; }

        public IEnumerable<GenerQueryModel> Geners { get; init; }
    }
}
