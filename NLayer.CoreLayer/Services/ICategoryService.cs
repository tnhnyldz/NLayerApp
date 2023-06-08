using NLayer.CoreLayer.DTOs;
using NLayer.CoreLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.CoreLayer.Services
{
    public interface ICategoryService:IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithProductsDTO>> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
