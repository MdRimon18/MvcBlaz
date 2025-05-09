using GarmentsERP.Model;
using GarmentsERP.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace GarmentsERP
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

     
            // services.AddControllers()
            //.AddJsonOptions(options =>
            //{
            //     // options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            //     // options.JsonSerializerOptions.PropertyNamingPolicy = null;
            //     options.JsonSerializerOptions.AllowTrailingCommas = true;
            //});
            services.AddControllers();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options
                .WithOrigins("http://localhost:4200") 
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
             .AllowAnyOrigin()
             .AllowAnyHeader());
            });
            services.AddScoped<DapperRepository>();
            services.AddDbContext<GarmentERPContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
                //DbGmts
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           

            app.UseRouting();

            app.UseCors(options => options
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );
  
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            
        }
    }
}
