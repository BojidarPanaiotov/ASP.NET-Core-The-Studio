namespace ASP.NET_Core_The_Studio.Controllers
{
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using ASP.NET_Core_The_Studio.Models;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.Services.Gener;
    using ASP.NET_Core_The_Studio.Services.Services.Rarity;

    public class ProductController : Controller
    {
        private readonly IElectronicBookService electronicBookService;
        private readonly IRarityService rarityService;
        private readonly IGenerService generService;

        public ProductController(
            IElectronicBookService electronicBookService,
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
            var electronicBooks = this.electronicBookService.GetElectronicBooksByFilters();

            var result = new SearchQueryModel()
            {
                TotalBooks = electronicBooks.TotalBooks,
                BookRarities = this.rarityService.GetAll<BookRarityQueryModel>(),
                ElectronicBooks = electronicBooks.Books,
                Geners = this.generService.GetAll<GenerQueryModel>().OrderBy(x => x.Name)
            };

            return View(result);
        }

        [HttpGet]
        public IActionResult Details(string eBookId)
            => View(this.electronicBookService.GetById<ElectronicBookServiceModel>(eBookId));
    }
}
