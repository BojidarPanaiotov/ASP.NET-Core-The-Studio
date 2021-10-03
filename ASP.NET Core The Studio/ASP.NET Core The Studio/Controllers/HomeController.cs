namespace ASP.NET_Core_The_Studio.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using ASP.NET_Core_The_Studio.Models;

    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult About() => View();

        [HttpGet]
        public IActionResult SendEmail() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
    }
}
