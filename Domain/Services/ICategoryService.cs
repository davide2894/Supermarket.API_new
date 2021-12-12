using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API_new.Domain.Models;
using Supermarket.API_new.Domain.Services.Communication;

namespace Supermarket.API_new.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
        //create method that saves a category in the db
        // so in browser, you save a category, but the returned type should be CategoryResponse
        Task<CategoryResponse> SaveAsync(Category category);
        Task<CategoryResponse> UpdateAsync(int id, Category category);
        Task<CategoryResponse> DeleteAsync(int id);
    }
}