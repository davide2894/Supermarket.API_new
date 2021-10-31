using Supermarket.API_new.Persistence.Contexts;

namespace Supermarket.API_new.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
