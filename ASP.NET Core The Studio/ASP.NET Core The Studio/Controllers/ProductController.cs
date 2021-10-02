namespace ASP.NET_Core_The_Studio.Controllers
{
    using ASP.NET_Core_The_Studio.Models;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.Services.Gener;
    using ASP.NET_Core_The_Studio.Services.Services.Rarity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    public class ProductController : Controller
    {
        private readonly IElectronicBookService electronicBookService;
        private readonly IRarityService rarityService;
        private readonly IGenerService generService;
        public ProductController(IElectronicBookService electronicBookService,
            IRarityService rarityService,
            IGenerService generService)
        {
            this.electronicBookService = electronicBookService;
            this.rarityService = rarityService;
            this.generService = generService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var electronicBooks = this.electronicBookService.GetAll<ElectronicBookQueryModel>().ToList();

            var result = new SearchQueryModel()
            {
                TotalBooks = electronicBooks.Count,
                BookRarities = this.rarityService.GetAll<BookRarityQueryModel>().ToList(),
                ElectronicBooks = electronicBooks.Take(8).ToList(),
                Geners = this.generService.GetAll<GenerQueryModel>().OrderBy(x => x.Name).ToList()
            };

            return View(result);
        }
        [HttpGet]
        public IActionResult Details(string eBookId)
        {
            var serviceBookModel = this.electronicBookService.GetById<ElectronicBookServiceModel>(eBookId);

            return View(serviceBookModel);
        }
    }
}
