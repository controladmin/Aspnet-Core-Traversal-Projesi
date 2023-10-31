using EntityLayer.Concreate; // Guide sınıfını kullanabilmek için bu kütüphaneyi ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        /* cunstructor tanımlıyoruz*/
        public GuideValidator()
        {

            /* bunu kullanabilmek için GuideController içinde çağırmamız gerek*/
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Rehber Adını Giriniz!!!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Rehber Açıklamasını Giriniz!!!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Rehber Resmini Yükleyiniz!!!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Rehber Adı 30 Karakteri Geçemez!!!");
            RuleFor(x => x.Name).MinimumLength(1).WithMessage("Rehber Adı 1 Karakterden Az Olamaz!!!");
        }
    }
}
