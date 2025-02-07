using Microsoft.EntityFrameworkCore;
using NLayer.CoreLayer.Models;
using NLayer.CoreLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return await _context.Categories
                .Include(x => x.Products)
                .Where(x => x.Id == categoryId)
                .SingleOrDefaultAsync();
            //If there is more than one id singleOrDefault returns an Ex.
            //firstorDefault return id what it finds first
        }
    }
}
 