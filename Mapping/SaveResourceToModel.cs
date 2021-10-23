using AutoMapper;
using Supermarket.APi_new.Domain.Models;
using Supermarket.APi_new.Resources;

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