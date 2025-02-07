using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NLayer.API.Filters;
using NLayer.CoreLayer.Services;

namespace NLayer.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService, IHttpContextAccessor contextAccessor)
        {
            _categoryService = categoryService;
            _contextAccessor = contextAccessor;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            //// Mevcut HTTP isteği için HttpContext nesnesini al
            //HttpContext httpContext = _contextAccessor.HttpContext;

            //// İstek bilgilerini kullanarak bazı özelliklere eriş
            //string clientIpAddress = httpContext.Connection.RemoteIpAddress.ToString();
            //string userAgent = httpContext.Request.Headers["User-Agent"];
            //string requestPath = httpContext.Request.Path;
            //string requestMethod = httpContext.Request.Method;
            //var requestHeaders = httpContext.Request.Headers;

            //HttpRequest request = _contextAccessor.HttpContext.Request;


            //string scheme = request.Scheme;         // http veya https
            //string host = request.Host.Host;        // örn. localhost
            //int? port = request.Host.Port;           // örn. 7072
            //string pathBase = request.PathBase;     // örn. /api
            //string path = request.Path;             // örn. /categories
            //string queryString = request.QueryString.ToString();  // örn. ?param1=value1&param2=value2

            //string fullUrl = $"{scheme}://{host}:{port}{pathBase}{path}{queryString}";





            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }
    }
}
