using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework1.API.DTO;
using Homework1.API.Extensions;
using Homework1.API.Filters;
using Homework1.Core.Repositories;
using Homework1.Core.Services;
using Homework1.Core.UnitOfWork;
using Homework1.Data;
using Homework1.Data.Repositories;
using Homework1.Data.UnitOfWorks;
using Homework1.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Homework1.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService,ProductService>();

            services.AddDbContext<HomeworkDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration["ConnectionStrings:SqlServer"].ToString(), o =>
                        o.MigrationsAssembly("Homework1.Data"));
            });


            services.AddScoped<IUnitOfWork, UnitOfWork>(); //DI

            services.AddControllers(o => { o.Filters.Add(new ValidationFilter()); });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Homework1.API", Version = "v1" });
            });

            // custom filter yazdik =>  default olarak gelen exception handling mekanizmasini kapattik
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Homework1.API v1"));
            }

            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}