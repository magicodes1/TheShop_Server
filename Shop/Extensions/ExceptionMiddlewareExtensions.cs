using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Shop.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Shop.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {

                    int code = (int) HttpStatusCode.InternalServerError;

                    context.Response.ContentType = "application/json";


                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();


                    var exception = exceptionHandlerPathFeature?.Error;

                    if (exception is BadRequestException)
                    {
                        code = (int) HttpStatusCode.BadRequest;
                    }
                    else if (exception is NotFoundException)
                    {
                        code = (int) HttpStatusCode.NotFound;
                    }
                    else if(exception is UnAuthenticationException)
                    {
                        code = (int) HttpStatusCode.Unauthorized;
                    }
                    else if(exception is ForbiddenException)
                    {
                        code = (int) HttpStatusCode.Forbidden;
                    }

                    context.Response.StatusCode = code;

                    var errorResponse = new ErrorDetail(exception, code,DateTime.UtcNow);

                    await context.Response.WriteAsync(errorResponse.ToString());
                });
            });
        }
    }
}
