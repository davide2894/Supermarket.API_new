using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.APi_new.Domain.Models;
using Supermarket.APi_new.Domain.Repositories;
using Supermarket.APi_new.Persistence.Contexts;
using Supermarket.APi_new.Persistence.Repositories;

namespace Supermarket.API_new.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}