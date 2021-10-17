using AutoMapper;
using Supermarket.APi_new.Domain.Models;
using Supermarket.APi_new.Resources;

namespace Supermarket.API_new.Mapping
{
    public class ModelToResource : Profile
    {
        public ModelToResource()
        {
            CreateMap<Category, CategoryResource>();
        }
    }
}