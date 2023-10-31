using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Models
{
    public class VisitorViewModel
    {
        public int VisitorID { get; set; }
        [Required(ErrorMessage =("Ad Alanı Boş Geçilemez!!!"))]
        public string Name { get; set; }

        [Required(ErrorMessage =("Soyad Alanı Boş Geçilemez!!!"))]
        public string Surname { get; set; }

        [Required(ErrorMessage =("Şehir Alanı Boş Geçilemez!!!"))]
        public string City { get; set; }

        [Required(ErrorMessage =("Ülke Alanı Boş Geçilemez!!!"))]
        public string Country { get; set; }

        [Required(ErrorMessage =("Mail Alanı Boş Geçilemez!!!"))]
        public string Mail { get; set; }
    }
}
