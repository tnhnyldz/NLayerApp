using AutoMapper;
using NLayer.CoreLayer.DTOs;
using NLayer.CoreLayer.Models;
using NLayer.CoreLayer.Repositories;
using NLayer.CoreLayer.Services;
using NLayer.CoreLayer.UnıtOfWorks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDTO>> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithProductsAsync(categoryId);
            var categoryDto =_mapper.Map<CategoryWithProductsDTO>(category);
            return CustomResponseDto<CategoryWithProductsDTO>.Success(200,categoryDto);
        }
    }
}
