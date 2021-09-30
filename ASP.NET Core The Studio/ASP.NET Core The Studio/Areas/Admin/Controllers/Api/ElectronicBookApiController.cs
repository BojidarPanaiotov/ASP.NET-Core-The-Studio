namespace ASP.NET_Core_The_Studio.Areas.Admin.Controllers.Api
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Areas.Admin.Models.Books;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models.Enums;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [Route("api/electronic-books")]
    [ApiController]
    public class ElectronicBookApiController : ControllerBase
    {
        private readonly IElectronicBookService electronicBookService;
        private readonly IMapper mapper;

        public ElectronicBookApiController(IElectronicBookService electronicBookService,
            IMapper mapper)
        {
            this.electronicBookService = electronicBookService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("book-rarity")]
        public IEnumerable<BookRarityApiModel> GetCategories()
            => this.electronicBookService.GetAllRarities<BookRarityApiModel>();

        [HttpGet]
        [Route("books")]
        public IEnumerable<ElectronicBookApiModel> GetElectronicBooks()
            => this.electronicBookService.GetAllElectronicBooks<ElectronicBookApiModel>();

        [HttpGet]
        [Route("filtered-by-search-term-gener-category-rarity")]
        public IEnumerable<ElectronicBookServiceModel> Test(
            [FromQuery] string searchTermTitle,
            [FromQuery] int sorting,
            [FromQuery] string[] rarities,
            [FromQuery] string[] geners)
        {
            //TODO: Return API model not service
            var bookSort = (BookSort)sorting;

            var books = this.electronicBookService
                .GetElectronicBooksByFilters(bookSort, searchTermTitle, rarities, geners)
                .ToList();

            BookLogger(books);
            Console.Clear();

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
