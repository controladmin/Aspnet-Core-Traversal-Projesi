using Microsoft.AspNetCore.Identity; // IdentityRole sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
   public  class AppRole:IdentityRole<int>
    {

        //NutGet kısmından identity paketlerini yüklüyoruz kullanıcı rollerini belirleyeceğiz

    }
}
