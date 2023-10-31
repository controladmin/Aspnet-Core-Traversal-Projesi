using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // UseSqlServer kullanabilmek için ekledik
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SignalRApi.DAL; // Context sýnýfýný kullanabilmek için ekledik
using SignalRApi.Hubs; // VisitorHub sýnýfýný kullanmak için ekledik
using SignalRApi.Model; // VisitorService Sýnýfýný kullanabilmek için ekledik
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
            /* SignalR VisitorService sýnýfýný ekledik ve altýndaki kodlarý ekliyoruz*/
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

            /* SignalR için connection baðlantýsý için yazýyoruz*/
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

            /* yukarýda oluþturulan CorsPolicy'i burada çaðýrýyoruz*/
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /* SignalR'deki VisitorHub için ekledik*/
                endpoints.MapHub<VisitorHub>("/VisitorHub");
            });
        }
    }
}
