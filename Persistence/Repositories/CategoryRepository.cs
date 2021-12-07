using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.API_new.Domain.Models;
using Supermarket.API_new.Domain.Repositories;
using Supermarket.API_new.Persistence.Contexts;
using Supermarket.API_new.Persistence.Repositories;

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

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }
    }
}