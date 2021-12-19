using Supermarket.API_new.Domain.Models;
using Supermarket.API_new.Domain.Repositories;
using Supermarket.API_new.Persistence.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Supermarket.API_new.Persistence.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
