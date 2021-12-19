using Supermarket.API_new.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API_new.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> ListAsync();
    }
}
