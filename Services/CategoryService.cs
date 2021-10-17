using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.APi_new.Domain.Models;
using Supermarket.APi_new.Domain.Repositories;
using Supermarket.APi_new.Domain.Services;

namespace Supermarket.APi_new.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            //use repository pattern to handle data acess to and from db
            return await _categoryRepository.ListAsync();
        }
    }
}