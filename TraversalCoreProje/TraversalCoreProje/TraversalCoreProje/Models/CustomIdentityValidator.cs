using Microsoft.AspNetCore.Identity; // bu sınıfı kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Models
{

    /*burada SignUp sayfasında üyelik işlemlerinde bilgileri girereken gerekli bilgilerin türkçe görünmesi için yapıldı
     asp-validation-summary bilgisini içeren div bu class olmasaydı bu uyarları ingilizce verecekti
    daha sonra startup.cs classında eklentiler yapıyoruz
     */
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError()
            {
               
                Code = "PasswordTooShort",
                Description = $"Parola Minimum {length} karakter uzunluğunda olmalıdır"
                
            };
        }

        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {

                Code = "PasswordRequiresNonAlphanumeric",
                Description = $"Parola en az bir numeric karakter içermelidir"
            };

        }

        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {

                Code = "PasswordRequiresLower",
                Description = $"Parola en az bir küçük harf içermelidir [a-z]"
            };

        }

        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {

                Code = "PasswordRequiresUpper",
                Description = $"Parola en az bir büyük harf içermelidir [A-Z]"
            };

        }



    }
}
