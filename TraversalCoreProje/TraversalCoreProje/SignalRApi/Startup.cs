using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // UseSqlServer kullanabilmek i�in ekledik
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SignalRApi.DAL; // Context s�n�f�n� kullanabilmek i�in ekledik
using SignalRApi.Hubs; // VisitorHub s�n�f�n� kullanmak i�in ekledik
using SignalRApi.Model; // VisitorService S�n�f�n� kullanabilmek i�in ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi
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
            /* SignalR VisitorService s�n�f�n� ekledik ve alt�ndaki kodlar� ekliyoruz*/
            services.AddScoped<VisitorService>();
            services.AddSignalR();
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder =>
             {
                 builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
             }));
            /* SignalR son*/

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SignalRApi", Version = "v1" });
            });

            /* SignalR i�in connection ba�lant�s� i�in yaz�yoruz*/
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration["DefaultConnection"]);
            });
            /* SignalR son*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SignalRApi v1"));
            }

            app.UseRouting();
            app.UseAuthorization();

            /* yukar�da olu�turulan CorsPolicy'i burada �a��r�yoruz*/
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /* SignalR'deki VisitorHub i�in ekledik*/
                endpoints.MapHub<VisitorHub>("/VisitorHub");
            });
        }
    }
}
