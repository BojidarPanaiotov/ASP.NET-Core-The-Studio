namespace ASP.NET_Core_The_Studio.Infrastructure
{
    using ASP.NET_Core_The_Studio.Areas.Admin.Models;
    using ASP.NET_Core_The_Studio.Data.Entities;
    using ASP.NET_Core_The_Studio.Models;
    using ASP.NET_Core_The_Studio.Models.SearchQueryModels;
    using ASP.NET_Core_The_Studio.Models.ViewModels;
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ElectronicBook, ElectronicBookViewModel>();
            CreateMap<ElectronicBook, ElectronicBook>();
            CreateMap<BookRarity, BookRarityQueryModel>();
            CreateMap<Gener, GenerQueryModel>();
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
        }
    }
}
