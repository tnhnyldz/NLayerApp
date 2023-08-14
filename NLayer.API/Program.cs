using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Filters;
using NLayer.API.Middlewares;
using NLayer.API.Modules;
using NLayer.CoreLayer.DTOs;
using NLayer.CoreLayer.Repositories;
using NLayer.CoreLayer.Services;
using NLayer.CoreLayer.UnýtOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWork;
using NLayer.Service.Mapping;
using NLayer.Service.Services;
using NLayer.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


//filter araya girecek
builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute()))
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    //apý tarafýnda bu default aktýftý kapattýk
    options.SuppressModelStateInvalidFilter = true;
});
//filter araya girecek


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapProfile));





builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"), option =>
      {
          //gets repository layer name
          option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
      });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
//module added
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

//MiddleWares
//uygulamaya bir rew gelirse aþama aþama middlewarelardan geçer.
//req ilk geldiðinde middleware kýsmýna girer bir de response oluþurken girer

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//kendý mýddlewareýmýz
app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();
