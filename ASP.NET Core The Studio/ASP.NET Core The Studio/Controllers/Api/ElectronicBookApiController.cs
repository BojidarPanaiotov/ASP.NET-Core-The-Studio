namespace ASP.NET_Core_The_Studio.Controllers.Api
{
    using ASP.NET_Core_The_Studio.Models.Api;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models.Enums;
    using ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.Services.Rarity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/electronic-books")]
    [ApiController]
    public class ElectronicBookApiController : ControllerBase
    {
        private readonly IElectronicBookService electronicBookService;
        private readonly IRarityService rarityService;

        public ElectronicBookApiController(IElectronicBookService electronicBookService,
            IRarityService rarityService)
        {
            this.electronicBookService = electronicBookService;
            this.rarityService = rarityService;
        }

        [HttpGet]
        [Route("book-rarity")]
        public IEnumerable<RarityApiModel> GetRarities()
            => this.rarityService.GetAll<RarityApiModel>();

        [HttpGet]
        [Route("books")]
        public IEnumerable<ElectronicBookApiModel> GetElectronicBooks()
            => this.electronicBookService.GetAll<ElectronicBookApiModel>();

        [HttpGet]
        [Route("filtered-by-search-term-gener-category-rarity")]
        public ListingElectronicBooksServiceModel Test(
            [FromQuery] string searchTermTitle,
            [FromQuery] int sorting,
            [FromQuery] string[] rarities,
            [FromQuery] string[] geners,
            [FromQuery] int currentPage)
        {
            //TODO: Return API model not service
            var bookSort = (BookSort)sorting;

            var books = this.electronicBookService
                .GetElectronicBooksByFilters(bookSort, searchTermTitle, rarities, geners, currentPage);

            return books;
        }
        private static void BookLogger(List<ElectronicBookServiceModel> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}\r\n" +
                    $"Geners: {string.Join(',', book.Geners.Select(x => x.Name).ToList())}\r\n" +
                    $"Rarity: {book.BookRarityName}\r\n" +
                    $"Price: {book.Price}\r\n" +
                    $"{new string('-', 30)}");
            }
        }
    }
}
/*
   Api routes:
   api/electronic-books/book-rarity
   api/electronic-books/books
   api/electronic-books/filtered-by-search-term-gener-category-rarity TODO: Why is giving error? 
*/