namespace ASP.NET_Core_The_Studio.Controllers
{
    using ASP.NET_Core_The_Studio.Models;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ProductController : Controller
    {
        private readonly IElectronicBookService electronicBookService;
        public ProductController(IElectronicBookService electronicBookService)
        {
            this.electronicBookService = electronicBookService;
        }
        public IActionResult Index()
        {
            var result = new SearchQueryModel()
            {
                BookRarities = this.electronicBookService.GetAllRarities<BookRarityQueryModel>().ToList(),
                ElectronicBooks = this.electronicBookService.GetAllElectronicBooks<ElectronicBookQueryModel>().ToList(),
                Geners = this.electronicBookService.GetAllGeners<GenerQueryModel>().OrderBy(x => x.Name).ToList()
            };

            return View(result);
        }
    }
}
