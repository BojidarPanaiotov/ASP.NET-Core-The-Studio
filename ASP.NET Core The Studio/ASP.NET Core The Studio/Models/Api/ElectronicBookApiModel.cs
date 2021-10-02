namespace ASP.NET_Core_The_Studio.Models.Api
{
    using System;
    using System.Collections.Generic;
    public class ElectronicBookApiModel
    {
        public string Title { get; set; }
        public string Author { get; init; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Pages { get; set; }
        public int CopySold { get; set; }
        public string BookRarityName { get; set; }
        public ICollection<GenerApiModel> Geners { get; init; }
    }
}
