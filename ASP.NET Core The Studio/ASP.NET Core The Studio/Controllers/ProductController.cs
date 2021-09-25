namespace ASP.NET_Core_The_Studio.Controllers
{
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Models;
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
            return View(new ElectronicBookQueryModel() 
            {
                BookRarities = this.electronicBookService.GetAllCategoires<BookRarity>().ToList(),
                ElectronicBooks = this.electronicBookService.GetAll<ElectronicBook>().ToList(),
                Geners = this.electronicBookService.GetAllGeners<Gener>().OrderBy(x => x.Name).ToList()
            });
        }
    }
}
