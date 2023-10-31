using DTOLayer.DTOs.ContactDTOs; // SendMesajDTO sınıfını kullanabilmek için ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class ContactUsValidator:AbstractValidator<SendMesajDTO>
    {

        /* Mapping klasöründe MapProfile içine mapliyoruz */
        public ContactUsValidator()
        {
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez!!!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez!!!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez!!!");
            RuleFor(x => x.MesajBody).NotEmpty().WithMessage("Mesaj alanı boş geçilemez!!!");
            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu alanı 10 karakterden az olamaz!!!");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Konu alanı 100 karakterden fazla olamaz!!!");
            RuleFor(x => x.MesajBody).MaximumLength(1000).WithMessage("Mesaj alanı 1000 karakterden fazla olamaz!!!");
        }
    }
}
