using BlogApp.Business.Exceptions.Category;
using BlogApp.Business.Exceptions.Common;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace BlogApp.API.Utilis
{
    public static class GlobalExceptionHandler
    {
        public static void UseException(this WebApplication app)
        {
            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;


                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Error is IBaseException ex)
                    {
                        context.Response.StatusCode = ex.StatusCode;
                        await context.Response.WriteAsJsonAsync(new 
                        {
                        

                            StatusCode=StatusCodes.Status404NotFound,
                            Message = ex.ErrorMessage
                        });
                    }

                    if (exceptionHandlerPathFeature?.Path == "/")
                    {
                        await context.Response.WriteAsync(" Page: Home.");
                    }
                });
            });
        }
    }
}
