using AspNetCoreHero.ToastNotification; // Notification i�in ekledik
using BusinessLayer.Container; // ContainerExtansions metodunu kullanabilmek i�in bu k�t�phaneyi ekledik
using DataAccessLayer.Concreate; // Context s�n�f�n� kullanabilmek i�in bu k�t�phaneyi ekledik
using EntityLayer.Concreate;
using FluentValidation.AspNetCore;
using MediatR; // MediatR s�n�f�n� kullanabilmek i�in bu k�t�phaneyi ekledik
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;  // AuthorizationPolicyBuilder bu s�n�f� kullanabilmek i�in bu k�t�phaneyi ekledik
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization; // AuthorizeFilter bu s�n�f� kullanabilmek i�in bu k�t�phaneyi ekliyoruz
using Microsoft.AspNetCore.Mvc.Razor;  // LanguageViewLocationExpanderFormat kullanabilmek i�in ekledik
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization; // LocalizationOptions kullanabilmek i�in ekledik
using Microsoft.Extensions.Logging; // ClearProviders s�n�f�n� kullanabilmek i�in bu k�t�phaneyi ekledik
using System.Data;
using System.IO; // Directory s�n�f�n� kullanabilmek i�in bu k�t�phaneyi ekledik
using TraversalCoreProje.CQRS.Handlers.DestinationHandler; // GetAllDestinationQueryHandler s�n�f�n� kullanabilmek i�in bu k�t�phaneyi ekledik
using TraversalCoreProje.Models; // CustomIdentityValidator s�n�f�n� kullanabilmek i�in bu k�t�phaneyi ekledik model klas�r� i�inde bu s�n�f





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

            

            /* Controller alt�nda HomeController i�inde _logger ile atama yapaca��z loglar� tutmak i�in AddLoggin kodlar�n� ekledik*/
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
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider)  /* �ifremi unuttumda token g�ndermesi i�in ekledik*/
                .AddEntityFrameworkStores<Context>(); // bunu ekliyoruz

            /* apiden gelen istekleri almak i�in ekledik*/
            services.AddHttpClient();

            /* BusinesLayer Container i�indeki Extansions class i�inde static bir metottur*/
            services.ContainerExtansions();

            /* auto mapper �zelli�ini kullanabilmek i�in a�a��daki iki kodu ekliyoruz*/
            services.AddAutoMapper(typeof(Startup));

            /* BusniessLayer katman�nda Extansion class�nda CustomerValidator olu�truduk burada �a��r�yoruz*/
               services.CustomerValidator();


            /* */
            /* GetAllDestinationQueryHandler s�n�f�n� startup i�erisinde tan�ml�yoruz*/
            services.AddScoped<GetAllDestinationQueryHandler>();

            /* GetDestinationByIdQueryHandler s�n�f�n� startup i�erisinde tan�ml�yoruz*/
            services.AddScoped<GetDestinationByIdQueryHandler>();

            /* CreateDestinationCommandHandler s�n�f�n� startup i�inde tan�ml�yoruz*/
            services.AddScoped<CreateDestinationCommandHandler>();

            /* RemoveDestinationCommandHandler s�n�f�n� startup i�inde tan�ml�yoruz*/
            services.AddScoped<RemoveDestinationCommandHandler>();

            /* UpdateDestinationCommandHandler s�n�f�n� startup i�inde tan�ml�yoruz*/
            services.AddScoped<UpdateDestinationCommandHandler>();


            /* MediatR s�n�f�n� startup i�ine ekliyoruz handler i�in tek tek tan�mlama yap�yoruduk burada tek tek tan�mlama yapmaya gerek kalmayacak*/
            services.AddMediatR(typeof(Startup));


            services.AddControllersWithViews().AddFluentValidation();


            // bunu ekliyoruz
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });


            /* �oklu dile deste�i i�in bilgileri Resources klas�r� i�inde ara diyoruz*/
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "Resources";
            });

            // bunu ekliyoruz �oklu dil deste�i i�in
            /* NToastNotify 7.0.0 versiyonunu ekliyoruz NuGet k�t�phanesinden ve AddNToastNotify k�sm�n� ekliyoruz a�a��daki gibi*/
            services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization().AddNToastNotifyToastr(new NToastNotify.ToastrOptions()
            {
                ProgressBar=true,
                PositionClass=NToastNotify.ToastPositions.TopCenter,
                PreventDuplicates=true,
                CloseButton=true,
                TimeOut=3000

            });

            /* Kullan�c� login olmadan giri� yapm�� ise SignIn sayfas�na y�nlendirsin diye ekledik bu kodu giri� yapmas� i�in*/
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/SignIn/";
            });

            /* oturum kapatmak i�in bu servisi ekliyoruz*/
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            {
                x.LogoutPath = "/Login/SignIn/";
            });


            /* Notification bilgilendirmesi i�in ekledik  AspNetCoreHero.ToastNotification; k�t�phane ad�*/
            //services.AddNotyf(config =>
            //{
            //    config.DurationInSeconds = 10;
            //    config.IsDismissable = true;
            //    config.Position = NotyfPosition.TopCenter;
            //});

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /* Configure metodu i�ine ILoggerFactory interface'ni ekliyoruz*/
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory)
        {
            /* Bu kodlar� loglar� tutaca��m�z yolu ve dosyay� belirtmek i�in yazd�k*/
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log1.txt"); /* bu yol i�inde txt dosyas�nda loglar� tutuyor*/


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

            /* kendi hata sayfam�za y�nlendirme yapmas� i�in bu kodu ekledik*/
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","? code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication(); // Bunu ekliyoruz
            app.UseRouting();

           

            app.UseAuthorization();

            /* buraya desteklenen dilleri dizi olarak giriyoruz*/
            var suppurtedCultures = new[] { "en", "fr", "es", "tr", "gr","de"};
            /* site aya�a kalkt���nda hangi dil ile aya�a kals�n onu belirtiyoruz*/
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(suppurtedCultures[3]).AddSupportedCultures(suppurtedCultures).AddSupportedUICultures(suppurtedCultures);
            app.UseRequestLocalization(localizationOptions);
            /* Son */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            /* bu ifadeyi areas klas�r� alt�ndaki mvc area elementinden koplay�p buraya ekledik*/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            /* bu ifadeyi areas klas�r� alt�ndaki admin area elementinden koplay�p buraya ekledik*/
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
