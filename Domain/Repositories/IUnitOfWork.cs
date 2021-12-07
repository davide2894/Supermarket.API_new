using System.Collections.Generic;
using System.Threading.Tasks;

namespace Supermarket.API_new.Domain.Repositories
{
    public interface IUnitOfWOrk
    {
        Task CompleteAsync();
    }
}