using Supermarket.APi_new.Persistence.Contexts;

namespace Supermarket.APi_new.Persistence.Repositories
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
