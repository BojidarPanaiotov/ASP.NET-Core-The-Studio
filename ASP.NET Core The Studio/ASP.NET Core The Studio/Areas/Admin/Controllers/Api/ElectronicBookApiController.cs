namespace ASP.NET_Core_The_Studio.Areas.Admin.Controllers.Api
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<ElectronicBook> Test(
            [FromQuery] string searchTerm,
            [FromQuery] string[] rarities,
            [FromQuery] string[] geners)
        {
            //TODO: Think for optimazed query to check all book with those geners (Use Intersec(),Any(),All())
            //TODO: Introduce service for this and then make it as query not as a physical collection
            var res = this.db.ElectronicBooks
                .Include(eb => eb.BookRarity)
                .Include(user => user.ElectronicBookGener)
                .ThenInclude(ElectronicBookGener => ElectronicBookGener.Gener)
                .Where(eb => rarities.Contains(eb.BookRarity.Name.ToLower()))
                .ToList();
                

            //foreach (var item in res)
            //{
            //    System.Console.WriteLine($"Title:{item.Title} - Rarity:{item.BookRarity.Name}");
            //}
            //;
            //System.Console.Clear();

            return res;
        }
    }
}
