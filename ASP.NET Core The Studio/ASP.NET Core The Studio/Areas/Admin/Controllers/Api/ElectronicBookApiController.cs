namespace ASP.NET_Core_The_Studio.Areas.Admin.Controllers.Api
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Areas.Admin.Models.Books;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
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
        [Route("test")]
        public IEnumerable<ElectronicBookViewModel> Test(
            [FromQuery] string searchTermTitle,
            [FromQuery] string[] rarities,
            [FromQuery] string[] geners)
        {
            var books = this.electronicBookService
                .GetElectronicBooksByFilters<ElectronicBookViewModel>(searchTermTitle, rarities, geners)
                .ToList();

            BookLogger(books);

            return books;
        }
        private static void BookLogger(List<ElectronicBookViewModel> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}\r\n" +
                    $"Geners: {string.Join(',', book.Geners.Select(x => x.Name).ToList())}\r\n" +
                    $"Rarity: {book.BookRarityName}\r\n" +
                    $"{new string('-', 30)}");
            }
            Console.Clear();
        }
    }
}
