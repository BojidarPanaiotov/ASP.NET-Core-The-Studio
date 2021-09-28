namespace ASP.NET_Core_The_Studio.Areas.Admin.Controllers.Api
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static ASP.NET_Core_The_Studio.Areas.Admin.AdminConstants;

    [Route("api/electronicBooks")]
    [ApiController]
    public class ElectronicBookApiController : ControllerBase
    {
        private readonly IElectronicBookService electronicBookService;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext db;

        public ElectronicBookApiController(
            IElectronicBookService electronicBookService,
            IMapper mapper,
            ApplicationDbContext db)
        {
            this.electronicBookService = electronicBookService;
            this.mapper = mapper;
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
        public IEnumerable<ElectronicBookViewModel> Test(
            [FromQuery] string searchTerm,
            [FromQuery] string[] rarities,
            [FromQuery] string[] geners)
        {
            //TODO: Think for optimazed query to check all book with those geners (Use Intersec(),Any(),All())
            //TODO: Introduce service for this and then make it as query not as a physical collection
            //TODO: Fix cycle loading ...
            //query 
            var res = this.db.ElectronicBooks
                .Include(eb => eb.BookRarity)
                .Include(user => user.ElectronicBookGener)
                .ThenInclude(ElectronicBookGener => ElectronicBookGener.Gener)
                .Where(eb => rarities.Contains(eb.BookRarity.Name.ToLower()) || !rarities.Any())
                .Where(eb => eb.ElectronicBookGener.Any(x => geners.Contains(x.Gener.Name)) || !geners.Any())
                .ProjectTo<ElectronicBookViewModel>(this.mapper.ConfigurationProvider)
                .ToList();

            BookLogger(res);

            return res;
        }
        private static void BookLogger(List<ElectronicBookViewModel> books)
        {
            foreach (var book in books)
            {
                //You must host the server not with IIS 
                Console.WriteLine($"Title: {book.Title}\r\n" +
                    $"Geners: {string.Join(',', book.Geners.Select(x => x.Name).ToList())}\r\n" +
                    $"Rarity: {book.BookRarityName}\r\n" +
                    $"{new string('-', 30)}");
            }
            Console.Clear();
        }
    }
}
