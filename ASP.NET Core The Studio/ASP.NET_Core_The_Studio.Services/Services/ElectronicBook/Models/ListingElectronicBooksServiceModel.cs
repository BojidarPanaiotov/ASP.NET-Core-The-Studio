namespace ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models
{
    using System.Collections.Generic;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;

    public class ListingElectronicBooksServiceModel
    {
        public int TotalPages { get; set; }

        public IEnumerable<ElectronicBookServiceModel> Books { get; set; }
    }
}
