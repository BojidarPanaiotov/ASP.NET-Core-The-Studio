namespace ASP.NET_Core_The_Studio.Services.Services.Rarity
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using ASP.NET_Core_The_Studio.Data;

    public class RarityService : IRarityService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public RarityService(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<T> GetAll<T>()
            => this.context.BookRarities
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToList();

        public T GetById<T>(string id)
            => this.context.BookRarities
            .Where(g => g.Id == id)
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();

        public T GetByName<T>(string name)
        => this.context.BookRarities
            .Where(g => g.Name == name)
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();
    }
}
