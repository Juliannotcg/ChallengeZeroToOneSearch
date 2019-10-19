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

            CreateMap<ProductViewModel, RegisterProductCommand>()
                .ConstructUsing(c => new RegisterProductCommand(c.Id, c.Name, c.Price, c.CategoryId));
        }
    }
}