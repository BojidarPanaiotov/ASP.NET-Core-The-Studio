namespace ASP.NET_Core_The_Studio.Areas.Admin.Controllers.Api
{
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/electronicBooks")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ElectronicBookApiController : ControllerBase
    {
        private readonly IElectronicBookService electronicBookService;
        private readonly ApplicationDbContext db;

        public ElectronicBookApiController(IElectronicBookService electronicBookService, ApplicationDbContext db)
        {
            this.electronicBookService = electronicBookService;
            this.db = db;
        }

        [HttpGet]
        [Route("categories")]
        public IEnumerable<BookRarity> GetCategories()
            => this.db.BookRarities.ToList();
    }
}
