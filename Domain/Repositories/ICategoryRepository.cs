using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API_new.Domain.Models;

namespace Supermarket.API_new.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}