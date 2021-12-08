using System.Threading.Tasks;
using Supermarket.API_new.Domain.Repositories;
using Supermarket.API_new.Persistence.Contexts;
namespace Supermarket.API_new.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}