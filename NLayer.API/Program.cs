using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Filters;
using NLayer.API.Middlewares;
using NLayer.CoreLayer.DTOs;
using NLayer.CoreLayer.Repositories;
using NLayer.CoreLayer.Services;
using NLayer.CoreLayer.Un�tOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWork;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using NLayer.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


//filter araya girecek
builder.Services.AddControllers(options =>options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x=>x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    //ap� taraf�nda bu default akt�ft� kapatt�k
    options.SuppressModelStateInvalidFilter = true;
});
//filter araya girecek


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>(); 

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), option =>
      {
          //gets repository layer name
          option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
      });
});




//MiddleWares
//uygulamaya bir rew gelirse a�ama a�ama middlewarelardan ge�er.
//req ilk geldi�inde middleware k�sm�na girer bir de response olu�urken girer

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//kend� m�ddleware�m�z
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
