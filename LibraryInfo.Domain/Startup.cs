using System.Collections.Generic;
using LibraryInfo.API.Entities;
using LibraryInfo.API.Models;
using LibraryInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LibraryInfo.Domain
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));

            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryInfoDB;Trusted_connection=True;";

            services.AddDbContext<LibraryInfoContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ILibraryInfoRepository, LibraryInfoRepository>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }
            app.UseStatusCodePages();
            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CityWithoutLibrariesDto, City>();
                cfg.CreateMap<Library, LibraryDto>();
                cfg.CreateMap<City, CityWithoutLibrariesDto>();
                cfg.CreateMap<Library, LibraryForCreationDto>();
                cfg.CreateMap<City, CityForCreationDto>();
                cfg.CreateMap<LibraryForCreationDto, Library>();
                cfg.CreateMap<CityForCreationDto, City>();

            });
        }
    }
}
