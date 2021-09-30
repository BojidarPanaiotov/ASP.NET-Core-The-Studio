namespace ASP.NET_Core_The_Studio.Services.ElectronicBook.Models
{
    using ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models;
    using System;
    using System.Collections.Generic;

    public class ElectronicBookServiceModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }
        public string Author { get; init; }

        public int Pages { get; set; }

        public int? CopySold { get; set; }

        public decimal Price { get; set; }

        public string BookRarityName { get; set; }

        public ICollection<GenerServiceModel> Geners { get; set; }
    }
}
