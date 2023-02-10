using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using FilmowaBaza.API.Filters;
using Microsoft.AspNetCore.Builder;

namespace FilmowaBaza.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(o => {
                o.SwaggerDoc("v1.1", new OpenApiInfo { Title = "FilmowaBaza API", Version = "v1.1" });
                o.AddSecurityDefinition("Bearer", // Name of the security scheme
                    new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Description = "JWT Authorization header with the Bearer authentication scheme",
                        Type = SecuritySchemeType.ApiKey, //type scheme http for bearer authentication
                        In = ParameterLocation.Header,
                        BearerFormat = "JWT"
                    });
                o.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                        },
                        new List<string>()
                    }
                });
                o.OperationFilter<AuthOperationFilter>();
            });
        }
        public static void UseSwaggerExtension(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseSwagger();
            appBuilder.UseSwaggerUI();
        }
        public static void UseSwaggerUI(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1.1/swagger.json", "API V1.1");
                x.RoutePrefix = string.Empty;
            });
        }
    } 
}
