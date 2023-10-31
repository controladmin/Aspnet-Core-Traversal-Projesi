using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;  //  [Required] bu ifadeyi kullanabilmek için bu kütüphaneyi ekledik

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTO
    {

        /* required özellikleri validation ile getirilecek o yüzden kaldırdık*/

        //[Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }

        //[Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Username { get; set; }

        //[Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz")]
        public string Mail { get; set; }

        //[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }


        //[Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
        //[Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor!!!")]
        public string ConfirmPassword { get; set; }
    }
}
