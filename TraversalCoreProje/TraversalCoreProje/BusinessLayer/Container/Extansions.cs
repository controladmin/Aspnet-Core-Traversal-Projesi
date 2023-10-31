using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUOW; // IAccountService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using BusinessLayer.Concreate;
using BusinessLayer.Concreate.ConcreateUOW; // AccountMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork; // IUnitOfWorkDal inteface'ni kullanabilmek için bu kütüphaneyi ekledik
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.ContactDTOs;
using FluentValidation; // IValidator interface'ni kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.Extensions.DependencyInjection; // IServiceCollection interface'ni eklemek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Extansions
    {
        public static void ContainerExtansions(this IServiceCollection services)
        {

            /* startup kısmında çağırıyoruz this anahtar sözcüğünü metodu ....Menager m=new ....Menager8(EF...Dal()) şeklinde
             nesne türetmeden kullanabilmek için bu şekilde yaptık
            */
            services.AddScoped<ICommentService, CommentMenager>();
            services.AddScoped<ICommentDal, EFCommentDal>();

            services.AddScoped<IDestinationService, DestinationMenager>();
            services.AddScoped<IDestinationDal, EFDestinationDal>();

            services.AddScoped<IAppUserService, AppUserMenager>();
            services.AddScoped<IAppUserDal, EFAppUserDal>();

            services.AddScoped<IReservationService, ReservationMenager>();
            services.AddScoped<IReservationDal, EFReservationDal>();

            services.AddScoped<IGuideService, GuideMenager>();
            services.AddScoped<IGuideDal, EFGuideDal>();

            services.AddScoped<IContactUsService, ContactUsMenager>();
            services.AddScoped<IContactUsDal, EFContactUsDal>();

            services.AddScoped<IAnnouncementService, AnnouncementMenager>();
            services.AddScoped<IAnnouncementDal, EFAnnouncementDal>();

            services.AddScoped<IExcelService, ExcelMenager>();
            services.AddScoped<IPdfService, PdfMenager>();

            services.AddScoped<IAccountService, AccountMenager>();
            services.AddScoped<IAccountDal, EFAccountDal>();

            services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();
        }

        
        /* startup içerisinde çağırıyoruz bu metodu static tanımladık sadece metot adı ile çağıralım diye
          validator çalışması için oluşturulan validationları buraya eklememiz gerek
         */
        public static void CustomerValidator(this IServiceCollection services)
        {
            /* oluşturulan DTO'ları startup içine ekliyoruz*/
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementAddValidator>();
            services.AddTransient<IValidator<SendMesajDTO>, ContactUsValidator>();
        }
    }
}
