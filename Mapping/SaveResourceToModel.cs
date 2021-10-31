using AutoMapper;
using Supermarket.API_new.Domain.Models;
using Supermarket.API_new.Resources;

namespace Supermarket.API_new.Mapping
{
    public class SaveResourceToModel : Profile
    {
        public SaveResourceToModel() 
        {
            CreateMap<SaveCategoryResource, Category>();
        }

    }
}