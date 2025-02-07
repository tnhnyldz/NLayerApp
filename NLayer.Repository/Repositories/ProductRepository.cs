using Microsoft.EntityFrameworkCore;
using NLayer.CoreLayer.Models;
using NLayer.CoreLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> getProductsWithCategory()
        {
            //eager Loading
            return await _context.Products.Include(x=>x.Category).ToListAsync();
        }
    }
}
