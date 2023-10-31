using DTOLayer.DTOs.AppUserDTOs; // Sın(ıfını kullanabilmek için bu kütüphaneyi ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için bu kütüphaneyi ekledik burdan miras alıyor
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{

    /* 
      1.  AbstractValidator<AppUserRegisterDTO> sınıfını ekliyoruz parametre olarak DTOLayer altındaki class'ı veriyoruz
      2. yapıcı metot oluşturup RuleFor bilgilerini giriyoruz
     
     */
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {

        /* RuleFor'ları yazmak için cunstructor yapıcı metot oluşturuyoruz*/
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Alanı Boş Geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçilemez");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcıadı Alanı Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Kullanıcıadı 5 Karakterden Az Olamaz");
            RuleFor(x => x.Username).MaximumLength(30).WithMessage("Kullanıcıadı 30 Karakterden Fazla Olamaz");
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler Uyuşmuyor");
        }
    }
}
