using AutoMapper;
using Challenge.Api.ViewModel;
using Challenge.Domain.Commands.CategoryCommands;
using Challenge.Domain.Commands.ProductCommands;

namespace Challenge.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, RegisterCategoryCommand>()
                .ConstructUsing(c => new RegisterCategoryCommand(c.Id, c.Name));

            CreateMap<ProductViewModel, ProductCommand>()
                .ForMember(dest => dest.CategoryId, m => m.MapFrom(a => a.Category));

            CreateMap<ProductViewModel, RemoveProductCommand>()
                .ForMember(dest => dest.Id, m => m.MapFrom(a => a.Id));

            CreateMap<AddOrUpdateProductViewModel, RegisterProductCommand>()
               .ForMember(dest => dest.CategoryId, m => m.MapFrom(a => a.CategoryId));
        }
    }
}