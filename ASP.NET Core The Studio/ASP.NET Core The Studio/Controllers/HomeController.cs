namespace ASP.NET_Core_The_Studio.Controllers
{
    using ASP.NET_Core_The_Studio.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
