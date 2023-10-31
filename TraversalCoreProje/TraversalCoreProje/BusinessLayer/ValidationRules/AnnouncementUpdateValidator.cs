using DTOLayer.DTOs.AnnouncementDTOs; // AnnouncementUpdateDTO sınıfını kullanabilmek için bu kütüphaneyi ekledik
using FluentValidation; // AbstractValidator sınıfını kullanabilmek için bu kütüphaneyi ekledik
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    /* update işlemleri için AnnouncementUpdateDTO sınıfını yazdık validete kontroller için*/
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Alanı Boş Geçilemez!!!");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez!!!");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık Alanı En Az 5 Karakter Olmak Zorundadır!!!");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Açıklama Alanı En Az 5 Karakter Olmak Zorundadır!!!");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Başlık Alanı En Fazla Karakter 50 Olmak Zorundadır!!!");
            RuleFor(x => x.Content).MaximumLength(1000).WithMessage("Başlık Alanı En Fazla 1000 Karakter Olmak Zorundadır!!!");
        }
    }
}
