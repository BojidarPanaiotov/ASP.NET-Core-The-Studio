namespace ASP.NET_Core_The_Studio.Areas.Admin.Models
{
    using ASP.NET_Core_The_Studio.Models.ViewModels;
    using System.Collections.Generic;
    public class ElectronicBookViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; init; }
        public decimal Price { get; set; }
        public string BookRarityName { get; set; }
        public string CopySold { get; set; }
        public int Pages { get; set; }
        public List<GenerViewModel> Geners { get; init; }
    }
}
