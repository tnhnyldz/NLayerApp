using Microsoft.AspNetCore.Diagnostics;
using NLayer.CoreLayer.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        //IApplicationBuilder ınterfaceı ıcın extensıon metot yazıyoruz bunu ımp. eden tum classlarda kullanacagız
        //stratup 61
        //WebApplication IApplicationBuilder inherit eder
        public static void UseCustomException(this IApplicationBuilder app)
        {
            //normalde ex atılırsa bu mıddleware calısır ve kendı modelını doner
            //bız kendı ıstedıgımız modelı donecegız
            app.UseExceptionHandler(config =>
            {
                //sonlandırıcı mıddleware.Ex varsa doner
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    //Uygulamada fırlatılan hatayı aldık
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
