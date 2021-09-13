using FilmowaBaza.API.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmowaBaza.API.Extensions
{
    public static class ExceptionsExtensions
    {
        public static void UseAppExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
