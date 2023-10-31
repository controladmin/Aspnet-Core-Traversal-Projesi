using EntityLayer.Concreate; // ContactUs sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContactUsService:IGenericService<ContactUs>
    {

        /* mesajlardaki bilgileri silmemek için falseyada true yapmak için hazırladık*/
        List<ContactUs> TGetListContactUsByTrue();
        List<ContactUs> TGetListContactUsByFalse();

        void TContactUsStatusChangeToFalse(int id);
    }
}
