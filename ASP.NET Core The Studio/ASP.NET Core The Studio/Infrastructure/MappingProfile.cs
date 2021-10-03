namespace ASP.NET_Core_The_Studio.Infrastructure
{
    using System.Linq;
    using AutoMapper;
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Models;
    using ASP.NET_Core_The_Studio.Models.Api;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using ASP.NET_Core_The_Studio.Models.ViewModels;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ElectronicBook, ElectronicBookViewModel>();
            CreateMap<ElectronicBook, ElectronicBook>();
            CreateMap<ElectronicBook, ElectronicBookServiceModel>()
                .ForMember(x => x.Geners,
                opt => opt.MapFrom(
                    src => src.ElectronicBookGener.Select(x => new GenerServiceModel
                    {
                        Id = x.Gener.Id,
                        Name = x.Gener.Name
                    })));

            CreateMap<ElectronicBook, ElectronicBookApiModel>()
                .ForMember(x => x.Geners,
                opt => opt.MapFrom(
                    src => src.ElectronicBookGener.Select(x => new GenerApiModel
                    {
                        Id = x.Gener.Id,
                        Name = x.Gener.Name
                    }))); 

            CreateMap<ElectronicBook, ElectronicBookViewModel>()
                .ForMember(x => x.Geners,
                opt => opt.MapFrom(
                    src => src.ElectronicBookGener.Select(x => new GenerViewModel
                    {
                        Id = x.Gener.Id,
                        Name = x.Gener.Name
                    })));

            CreateMap<BookRarity, BookRarityQueryModel>();
            CreateMap<BookRarity, RarityApiModel>();

            CreateMap<Gener, GenerQueryModel>();
        }
    }
}
