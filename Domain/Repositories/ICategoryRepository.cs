using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.APi_new.Domain.Models;

namespace Supermarket.APi_new.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}