namespace ASP.NET_Core_The_Studio.Services.ElectronicBook
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Data;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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
        public async Task Create(string title,
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

            await this.context.ElectronicBooks.AddAsync(electronicBook);
            this.context.SaveChanges();
        }

        public async Task Delete(string id)
        {
            var electronicBook = await this.context
                .ElectronicBooks
                .FirstOrDefaultAsync(x => x.Id == id);

            this.context.Remove(electronicBook);
            await this.context.SaveChangesAsync();
        }

        public ElectronicBookDetailsServiceModel Details(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAllElectronicBooksWithGeners<T>()
            => this.context
                .ElectronicBooks
                .Include(user => user.ElectronicBookGener)
                .ThenInclude(ElectronicBookGener => ElectronicBookGener.Gener)
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        public IEnumerable<T> GetAllElectronicBooks<T>()
            => this.context
                .ElectronicBooks
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        public async Task<IEnumerable<T>> GetAllElectronicBooksByAuthor<T>(string authorName)
            => await this.context
            .ElectronicBooks
            .Where(x => x.Author.ToLower() == authorName)
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToListAsync();

        public Task<IEnumerable<T>> GetAllByCategory<T>()
        {
            throw new System.NotImplementedException();
        }

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

        public ElectronicBookServiceModel GetByAuthor(string authorName)
        {
            throw new System.NotImplementedException();
        }

        public ElectronicBookServiceModel GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public ElectronicBookServiceModel GetByTitle(string title)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(ElectronicBookServiceModel eBookModel, string eBookId)
        {
            throw new System.NotImplementedException();
        }

        public List<ElectronicBookViewModel> GetElectronicBooksByFilters(BookSort sorting, string searchTermTitle, string[] rarities, string[] geners)
        {
            //TODO: Think for optimazed query to check all book with those geners (Use Intersec(),Any(),All())
            //TODO: Introduce service for this and then make it as query not as a physical collection

            var query = this.context.ElectronicBooks
                .Include(eb => eb.BookRarity)
                .Include(user => user.ElectronicBookGener)
                .ThenInclude(ElectronicBookGener => ElectronicBookGener.Gener)
                .AsQueryable();

            query = query.Where(eb => rarities.Contains(eb.BookRarity.Name.ToLower()) || !rarities.Any());
            query = query.Where(eb => eb.ElectronicBookGener.Any(x => geners.Contains(x.Gener.Name)) || !geners.Any());

            if (!string.IsNullOrEmpty(searchTermTitle))
            {
                query = query.Where(eb => eb.Title.ToLower().Contains(searchTermTitle));
            }

            query = sorting switch
            {
                BookSort.Price => query.OrderBy(x => x.Price),
                BookSort.PriceDescending => query.OrderByDescending(x => x.Price),
                BookSort.Date => query.OrderBy(x => x.CreatedOn),
                BookSort.DateDescending => query.OrderByDescending(x => x.CreatedOn),
                BookSort.Title => query.OrderBy(x => x.Title),
                BookSort.TitleDescending => query.OrderByDescending(x => x.Title),
                BookSort.All or _ => query.OrderBy(x => x.Id)
            };

            return query.ProjectTo<ElectronicBookViewModel>(this.mapper.ConfigurationProvider).ToList();
        }
    }
}
