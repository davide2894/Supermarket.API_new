using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.APi_new.Domain.Models;

namespace Supermarket.APi_new.Domain.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> ListAsync();
    }
}