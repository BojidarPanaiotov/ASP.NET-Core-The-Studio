namespace ASP.NET_Core_The_Studio.Models
{
    using ASP.NET_Core_The_Studio.Data.Entities;
    using System.Collections.Generic;
    public class ElectronicBookQueryModel
    {
        public List<BookRarity> BookRarities { get; init; }
        public List<ElectronicBook> ElectronicBooks { get; init; }
        public List<Gener> Geners { get; init; }
    }
}
