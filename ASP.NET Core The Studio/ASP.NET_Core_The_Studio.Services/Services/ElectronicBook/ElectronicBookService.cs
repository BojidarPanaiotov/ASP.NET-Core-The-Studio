namespace ASP.NET_Core_The_Studio.Services.ElectronicBook
{
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models.Enums;
    using ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _ElectronicBook = Data.Entities.ElectronicBook;

    public class ElectronicBookService : IElectronicBookService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public ElectronicBookService(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<T> GetAllElectronicBooks<T>()
            => this.context.ElectronicBooks
                       .ProjectTo<T>(this.mapper.ConfigurationProvider)
                       .ToList();

        public IEnumerable<T> GetElectronicBooksWithGeners<T>()
            => this.context
                .ElectronicBooks
                .Include(user => user.ElectronicBookGener)
                .ThenInclude(ElectronicBookGener => ElectronicBookGener.Gener)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();

        public IEnumerable<T> GetAllElectronicBooksByAuthor<T>(string authorName)
            => this.context
            .ElectronicBooks
            .Where(x => x.Author.ToLower() == authorName)
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToList();

        public IEnumerable<T> GetAllRarities<T>()
            => this.context
            .BookRarities
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToList();

        public IEnumerable<T> GetAllGeners<T>()
            => this.context
            .Geners
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToList();

        public ElectronicBookServiceModel GetById(string id)
            => this.context.ElectronicBooks
            .Where(eb => eb.Id == id)
            .ProjectTo<ElectronicBookServiceModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();

        public ElectronicBookServiceModel GetByTitle(string title)
            => this.context.ElectronicBooks
            .Where(eb => eb.Title.ToLower() == title.ToLower())
            .ProjectTo<ElectronicBookServiceModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();

        public ElectronicBookServiceModel GetByAuthor(string authorName)
            => this.context.ElectronicBooks
            .Where(eb => eb.Author.ToLower() == authorName.ToLower())
            .ProjectTo<ElectronicBookServiceModel>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();

        public void Create(string title,
            string author,
            decimal price,
            byte[] coverImage,
            byte[] data,
            string bookRarityId,
            string description,
            string userId)
        {
            //TODO: Search for way to count the PDF file pages
            var electronicBook = new _ElectronicBook
            {
                UserId = userId,
                Author = author,
                Description = description,
                Pages = 0,
                Price = price,
                CopySold = 0,
                BookRarityId = bookRarityId,
                Title = title,
                CreatedOn = DateTime.Now,
                BookCoverImage = coverImage,
                Data = data
            };

            this.context.ElectronicBooks.Add(electronicBook);
            this.context.SaveChanges();
        }

        public void Update(ElectronicBookServiceModel eBookModel, string eBookId)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public void Details(string id)
        {
            throw new NotImplementedException();
        }

        public ListingElectronicBooksServiceModel GetElectronicBooksByFilters(BookSort sorting,
            string searchTermTitle,
            string[] rarities,
            string[] geners,
            int currentPage)
        {
            var query = this.context.ElectronicBooks
                .Include(eb => eb.BookRarity)
                .Include(user => user.ElectronicBookGener)
                .ThenInclude(ElectronicBookGener => ElectronicBookGener.Gener)
                .Where(eb => !rarities.Any() || rarities.Contains(eb.BookRarity.Name.ToLower()))
                .Where(eb => !geners.Any() || eb.ElectronicBookGener.Any(x => geners.Contains(x.Gener.Name)))
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTermTitle))
            {
                query = query.Where(eb => eb.Title.ToLower().Contains(searchTermTitle));
            }
            if (sorting != BookSort.None)
            {
                query = sorting switch
                {
                    BookSort.Price => query.OrderBy(x => x.Price),
                    BookSort.PriceDescending => query.OrderByDescending(x => x.Price),
                    BookSort.Date => query.OrderBy(x => x.CreatedOn),
                    BookSort.DateDescending => query.OrderByDescending(x => x.CreatedOn),
                    BookSort.Title => query.OrderBy(x => x.Title),
                    BookSort.TitleDescending => query.OrderByDescending(x => x.Title),
                    BookSort.None or _ => query.OrderBy(x => x.Id)
                };
            }

            var totalPages = query.Count();

            var books = query
                .Skip((currentPage - 1) * 8)
                .Take(ElectronicBookServiceModel.booksPerPage)
                .ProjectTo<ElectronicBookServiceModel>(this.mapper.ConfigurationProvider)
                .ToList();

            return new ListingElectronicBooksServiceModel
            {
                TotalPages = totalPages,
                Books = books
            };
        }
    }
}
