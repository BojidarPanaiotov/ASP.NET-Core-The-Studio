namespace ASP.NET_Core_The_Studio.Controllers
{
    using ASP.NET_Core_The_Studio.Models;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class ProductController : Controller
    {
        private readonly IElectronicBookService electronicBookService;
        private readonly IMapper mapper;
        public ProductController(IElectronicBookService electronicBookService,
            IMapper mapper)
        {
            this.electronicBookService = electronicBookService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var electronicBooks = this.electronicBookService.GetAllElectronicBooks<ElectronicBookQueryModel>().ToList();

            var result = new SearchQueryModel()
            {
                TotalBooks = electronicBooks.Count,
                BookRarities = this.electronicBookService.GetAllRarities<BookRarityQueryModel>().ToList(),
                ElectronicBooks = electronicBooks.Take(8).ToList(),
                Geners = this.electronicBookService.GetAllGeners<GenerQueryModel>().OrderBy(x => x.Name).ToList()
            };

            return View(result);
        }
        [HttpGet]
        public IActionResult Details(string eBookId)
        {
            var serviceBookModel = this.electronicBookService.GetById(eBookId);

            return View(serviceBookModel);
        }
    }
}
