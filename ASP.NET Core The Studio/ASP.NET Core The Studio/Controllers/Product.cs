﻿namespace ASP.NET_Core_The_Studio.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class Product : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
