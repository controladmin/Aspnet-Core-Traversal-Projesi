using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // [Required] ifadesini kullanabilmek için bu kütüphaneyi ekledik

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserLoginDTO
    {

        /* validation ile geleceği içn required alanlarını kapattık*/

        //[Required(ErrorMessage = "Username alanı boş geçilimez")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
