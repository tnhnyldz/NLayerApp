using NLayer.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.CoreLayer.Repositories
{
    public interface IProductRepository : IGenericRepository<Product> 
    {
        Task<List<Product>> getProductsWithCategory();
    }
}
