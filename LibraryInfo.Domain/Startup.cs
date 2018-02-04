using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryInfo.API.Entities;
using LibraryInfo.API.Models;
using LibraryInfo.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                cfg.CreateMap<List<CityWithoutLibrariesDto>, List<City>>();
            });
        }
    }
}
