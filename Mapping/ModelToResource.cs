using AutoMapper;
using Supermarket.API_new.Domain.Models;
using Supermarket.API_new.Resources;
using Supermarket.API_new.Extensions;

namespace Supermarket.API_new.Mapping
{
    public class ModelToResource : Profile
    {
        public ModelToResource()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>()
                .ForMember(src => src.UnitOfMeasurement,
                    opt => opt.MapFrom(src => src.UnitOfMeasurement.ToDescriptionString()));
        }
    }
}