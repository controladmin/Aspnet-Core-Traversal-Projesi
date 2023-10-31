using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Required] ifadesini kullanabilmek için bu kütüphaneyi ekledik
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="Username alanı boş geçilimez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }
    }
}
