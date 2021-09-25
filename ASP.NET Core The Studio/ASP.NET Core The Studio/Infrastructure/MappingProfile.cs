namespace ASP.NET_Core_The_Studio.Infrastructure
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using AutoMapper;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ElectronicBook, ElectronicBookViewModel>();
            CreateMap<ElectronicBook, ElectronicBook>();
            CreateMap<BookRarity, BookRarity>();
            CreateMap<Gener, Gener>();
        }
    }
}
