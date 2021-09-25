namespace ASP.NET_Core_The_Studio.Services.ElectronicBook
{
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

            //TODO: Check why some records are not saving into the database if you use method SaveChangesAsyn()
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

        public IEnumerable<T> GetAll<T>()
            => this.context
                .ElectronicBooks
                .ProjectTo<T>(this.mapper.ConfigurationProvider)
                .ToList();
        //TODO: Probably there is better approach  
        public async Task<IEnumerable<T>> GetAllByAuthor<T>(string authorName)
            => await this.context
            .ElectronicBooks
            .Where(x => x.Author.ToLower() == authorName)
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToListAsync();

        public Task<IEnumerable<T>> GetAllByCategory<T>()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAllCategoires<T>()
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
    }
}
