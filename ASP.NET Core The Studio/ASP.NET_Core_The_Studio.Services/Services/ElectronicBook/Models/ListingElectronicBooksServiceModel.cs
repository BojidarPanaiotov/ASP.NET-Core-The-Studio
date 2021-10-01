namespace ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models
{
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using System.Collections.Generic;

    public class ListingElectronicBooksServiceModel
    {
        public int TotalPages { get; set; }

        public IEnumerable<ElectronicBookServiceModel> Books { get; set; }
    }
}
