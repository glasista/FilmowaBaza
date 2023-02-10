using Autofac;
using MediatR;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FilmowaBaza.Domain;
using FilmowaBaza.Domain.Modules;
using FilmowaBaza.API.Extensions;
using FilmowaBaza.Infrastructure.Services.Interfaces;
using FilmowaBaza.Infrastructure.Modules;
using FilmowaBaza.API.Filters;
using System;
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace FilmowaBaza.API
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            // In ASP.NET Core 3.0 `env` will be an IWebHostingEnvironment, not IHostingEnvironment.
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policyBuilder =>
                    {
                        policyBuilder
                            .SetIsOriginAllowed(origin => true)
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddControllers(options =>{
                options.Filters.Add(typeof(ValidationFilter));
            });

            services.AddMediatR(typeof(IService));
            services.AddJwtAuthentication(Configuration);
            services.AddSwagger();
            
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseCors();
            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            app.UseAppExceptionHandler();

            app.UseAuthentication();
            app.UseAuthorization();
            //app.UseSwagger(options =>
            //{
            //    options.SerializeAsV2= true;
            //});
            //app.UseSwaggerUI(o =>
            //{
            //    o.SwaggerEndpoint("/swagger/v1.1/swagger.json", "FilmowaBaza API V1");
            //    o.RoutePrefix = string.Empty;
            //});
            app.UseSwaggerExtension();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServicesModule());
        }
    }
}
