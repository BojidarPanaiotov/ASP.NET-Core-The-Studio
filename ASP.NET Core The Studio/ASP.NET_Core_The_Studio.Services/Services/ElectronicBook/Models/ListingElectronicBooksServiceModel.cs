namespace ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models
{
    using System.Collections.Generic;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;

    public class ListingElectronicBooksServiceModel
    {
        public const int booksPerPage = 8;

        public int TotalBooks { get; set; }

        public IEnumerable<ElectronicBookServiceModel> Books { get; set; }
    }
}
