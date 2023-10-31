using AspNetCoreHero.ToastNotification; // Notification için ekledik
using BusinessLayer.Container; // ContainerExtansions metodunu kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // Context sýnýfýný kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using FluentValidation.AspNetCore;
using MediatR; // MediatR sýnýfýný kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;  // AuthorizationPolicyBuilder bu sýnýfý kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization; // AuthorizeFilter bu sýnýfý kullanabilmek için bu kütüphaneyi ekliyoruz
using Microsoft.AspNetCore.Mvc.Razor;  // LanguageViewLocationExpanderFormat kullanabilmek için ekledik
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization; // LocalizationOptions kullanabilmek için ekledik
using Microsoft.Extensions.Logging; // ClearProviders sýnýfýný kullanabilmek için bu kütüphaneyi ekledik
using System.Data;
using System.IO; // Directory sýnýfýný kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.CQRS.Handlers.DestinationHandler; // GetAllDestinationQueryHandler sýnýfýný kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.Models; // CustomIdentityValidator sýnýfýný kullanabilmek için bu kütüphaneyi ekledik model klasörü içinde bu sýnýf





namespace TraversalCoreProje
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

            

            /* Controller altýnda HomeController içinde _logger ile atama yapacaðýz loglarý tutmak için AddLoggin kodlarýný ekledik*/
            services.AddLogging(x =>
            {
                x.ClearProviders();
                x.SetMinimumLevel(LogLevel.Debug);
                x.AddDebug();
            });

            services.AddDbContext<Context>();  // bunu ekliyoruz
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<Context>()
                .AddErrorDescriber<CustomIdentityValidator>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)  /* þifremi unuttumda token göndermesi için ekledik*/
                .AddEntityFrameworkStores<Context>(); // bunu ekliyoruz

            /* apiden gelen istekleri almak için ekledik*/
            services.AddHttpClient();

            /* BusinesLayer Container içindeki Extansions class içinde static bir metottur*/
            services.ContainerExtansions();

            /* auto mapper özelliðini kullanabilmek için aþaðýdaki iki kodu ekliyoruz*/
            services.AddAutoMapper(typeof(Startup));

            /* BusniessLayer katmanýnda Extansion classýnda CustomerValidator oluþtruduk burada çaðýrýyoruz*/
               services.CustomerValidator();


            /* */
            /* GetAllDestinationQueryHandler sýnýfýný startup içerisinde tanýmlýyoruz*/
            services.AddScoped<GetAllDestinationQueryHandler>();

            /* GetDestinationByIdQueryHandler sýnýfýný startup içerisinde tanýmlýyoruz*/
            services.AddScoped<GetDestinationByIdQueryHandler>();

            /* CreateDestinationCommandHandler sýnýfýný startup içinde tanýmlýyoruz*/
            services.AddScoped<CreateDestinationCommandHandler>();

            /* RemoveDestinationCommandHandler sýnýfýný startup içinde tanýmlýyoruz*/
            services.AddScoped<RemoveDestinationCommandHandler>();

            /* UpdateDestinationCommandHandler sýnýfýný startup içinde tanýmlýyoruz*/
            services.AddScoped<UpdateDestinationCommandHandler>();


            /* MediatR sýnýfýný startup içine ekliyoruz handler için tek tek tanýmlama yapýyoruduk burada tek tek tanýmlama yapmaya gerek kalmayacak*/
            services.AddMediatR(typeof(Startup));


            services.AddControllersWithViews().AddFluentValidation();


            // bunu ekliyoruz
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });


            /* çoklu dile desteði için bilgileri Resources klasörü içinde ara diyoruz*/
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });

            // bunu ekliyoruz çoklu dil desteði için
            /* NToastNotify 7.0.0 versiyonunu ekliyoruz NuGet kütüphanesinden ve AddNToastNotify kýsmýný ekliyoruz aþaðýdaki gibi*/
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization().AddNToastNotifyToastr(new NToastNotify.ToastrOptions()
            {
                ProgressBar=true,
                PositionClass=NToastNotify.ToastPositions.TopCenter,
                PreventDuplicates=true,
                CloseButton=true,
                TimeOut=3000

            });

            /* Kullanýcý login olmadan giriþ yapmýþ ise SignIn sayfasýna yönlendirsin diye ekledik bu kodu giriþ yapmasý için*/
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn/";
            });

            /* oturum kapatmak için bu servisi ekliyoruz*/
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LogoutPath = "/Login/SignIn/";
            });


            /* Notification bilgilendirmesi için ekledik  AspNetCoreHero.ToastNotification; kütüphane adý*/
            //services.AddNotyf(config =>
            //{
            //    config.DurationInSeconds = 10;
            //    config.IsDismissable = true;
            //    config.Position = NotyfPosition.TopCenter;
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /* Configure metodu içine ILoggerFactory interface'ni ekliyoruz*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            /* Bu kodlarý loglarý tutacaðýmýz yolu ve dosyayý belirtmek için yazdýk*/
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt"); /* bu yol içinde txt dosyasýnda loglarý tutuyor*/


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            /* kendi hata sayfamýza yönlendirme yapmasý için bu kodu ekledik*/
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","? code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); // Bunu ekliyoruz
            app.UseRouting();

           

            app.UseAuthorization();

            /* buraya desteklenen dilleri dizi olarak giriyoruz*/
            var suppurtedCultures = new[] { "en", "fr", "es", "tr", "gr","de"};
            /* site ayaða kalktýðýnda hangi dil ile ayaða kalsýn onu belirtiyoruz*/
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppurtedCultures[3]).AddSupportedCultures(suppurtedCultures).AddSupportedUICultures(suppurtedCultures);
            app.UseRequestLocalization(localizationOptions);
            /* Son */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            /* bu ifadeyi areas klasörü altýndaki mvc area elementinden koplayýp buraya ekledik*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            /* bu ifadeyi areas klasörü altýndaki admin area elementinden koplayýp buraya ekledik*/
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //      name: "areas",
            //      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );
            //});


        }
    }
}
