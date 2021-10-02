namespace ASP.NET_Core_The_Studio.Services.Services.Gener
{
    using ASP.NET_Core_The_Studio.Data;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.Collections.Generic;
    using System.Linq;

    public class GenerService : IGenerService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenerService(ApplicationDbContext context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<T> GetAll<T>()
            => this.context.Geners
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .ToList();

        public T GetById<T>(string id)
            => this.context.Geners
            .Where(g => g.Id == id)
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();

        public T GetByName<T>(string name)
        => this.context.Geners
            .Where(g => g.Name == name)
            .ProjectTo<T>(this.mapper.ConfigurationProvider)
            .FirstOrDefault();
    }
}
