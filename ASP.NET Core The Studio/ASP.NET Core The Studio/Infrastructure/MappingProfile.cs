namespace ASP.NET_Core_The_Studio.Infrastructure
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Areas.Admin.Models.Books;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Models;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using ASP.NET_Core_The_Studio.Models.ViewModels;
    using ASP.NET_Core_The_Studio.Services.ElectronicBook.Models;
    using ASP.NET_Core_The_Studio.Services.Services.ElectronicBook.Models;
    using AutoMapper;
    using System.Linq;
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
                    }))); ;

            CreateMap<ElectronicBook, ElectronicBookApiModel>()
                .ForMember(x => x.Geners,
                opt => opt.MapFrom(
                    src => src.ElectronicBookGener.Select(x => new BookGenerApiModel
                    {
                        Id = x.Gener.Id,
                        Name = x.Gener.Name
                    })));

            CreateMap<ElectronicBook, ElectronicBookQueryModel>()
                .ForMember(x => x.Geners,
                opt => opt.MapFrom(
                    src => src.ElectronicBookGener.Select(x => new GenerQueryModel
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
            CreateMap<BookRarity, BookRarityApiModel>();

            CreateMap<Gener, GenerQueryModel>();

        }
    }
}
