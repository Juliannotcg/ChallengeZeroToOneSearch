using AutoMapper;
using Challenge.Api.ViewModel;
using Challenge.Domain.Models;

namespace Challenge.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.Category, m => m.MapFrom(a => a.Category));
        }
    }
}