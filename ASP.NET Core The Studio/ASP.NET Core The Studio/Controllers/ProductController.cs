namespace ASP.NET_Core_The_Studio.Controllers
{
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using Microsoft.AspNetCore.Mvc;
    public class ProductController : Controller
    {
        private readonly IElectronicBookService electronicBookService;
        public ProductController(IElectronicBookService electronicBookService)
        {
            this.electronicBookService = electronicBookService;
        }
        public IActionResult Index()
        {
            return View(this.electronicBookService.GetAll<ElectronicBook>());
        }
    }
}
