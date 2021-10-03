namespace ASP.NET_Core_The_Studio.Areas.Admin.Controllers
{
    using System.Linq;
    using System.IO;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Infrastructure.Extensions;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook;
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;

    public class ElectronicBookController : AdminController
    {
        private readonly ApplicationDbContext context;
        private readonly IElectronicBookService electronicBookService;

        public ElectronicBookController(
            ApplicationDbContext context,
            IElectronicBookService electronicBookService)
        {
            this.context = context;
            this.electronicBookService = electronicBookService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
            => View(new ElectronicBookFormModel()
            {
                Categories = context.BookRarities.ToList()
            });

        [Authorize]
        [HttpPost]
        public IActionResult Create(
            ElectronicBookFormModel eBook,
            IFormFile bookData,
            IFormFile bookCoverImage)
        {
            //TODO: Restrict only for PDF files (or other book formats included)
            //TODO: Think for a way to get pages count from the book
            //TODO: Think for a way to get word count from the book
            using var ms = new MemoryStream();

            bookData.CopyTo(ms);
            var dataBytes = ms.ToArray();

            bookCoverImage.CopyTo(ms);
            var coverImageBytes = ms.ToArray();

            electronicBookService.Create(
                eBook.Title,
                eBook.Author,
                eBook.Price,
                coverImageBytes,
                dataBytes,
                eBook.BookRarityId,
                eBook.Description,
                this.User.Id());

            return RedirectToAction(
                nameof(ElectronicBookController.All),
                nameof(ElectronicBookController).Replace("Controller", ""));
        }

        [Authorize]
        [HttpGet]
        public IActionResult All()
            => View(this.electronicBookService.GetAllWithGeners<ElectronicBookViewModel>());


        [Authorize]
        [HttpGet]
        public FileStreamResult Download(string id)
        {
            var electronicBook = context.ElectronicBooks.Find(id);
            var stream = new MemoryStream(electronicBook.Data);

            return new FileStreamResult(stream, "application/pdf")
            {
                FileDownloadName = $"TheStudio_{electronicBook.Title}.pdf"
            };
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            this.electronicBookService.Delete(id);

            return RedirectToAction(
                nameof(ElectronicBookController.All),
                nameof(ElectronicBookController).Replace("Controller", ""));
        }
    }
}
