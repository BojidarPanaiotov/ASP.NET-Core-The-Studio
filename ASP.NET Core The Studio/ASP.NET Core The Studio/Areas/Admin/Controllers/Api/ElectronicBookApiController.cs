namespace ASP.NET_Core_The_Studio.Areas.Admin.Controllers.Api
{
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using static ASP.NET_Core_The_Studio.Areas.Admin.AdminConstants;

    [Route("api/electronicBooks")]
    [ApiController]
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
        [Authorize(Roles = AdministratorRoleName)]
        public IEnumerable<BookRarity> GetCategories()
            => this.db.BookRarities.ToList();
        [HttpGet]
        [Route("books")]
        [Authorize]
        public IEnumerable<ElectronicBook> GetElectronicBooks()
            => this.db.ElectronicBooks.ToList();
        [HttpGet]
        [Route("test")]
        public void Test(string common,string rare,string antique,string @event,string limited)
        {

        }

    }
}
