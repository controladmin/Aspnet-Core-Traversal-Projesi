using EntityLayer.Concreate; // ContactUs sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IContactUsDal:IGenericDal<ContactUs>
    {

        /* mesajlardaki bilgileri silmemek için falseyada true yapmak için hazırladık*/
        List<ContactUs> GetListContactUsByTrue();
        List<ContactUs> GetListContactUsByFalse();

        void ContactUsStatusChangeToFalse(int id);
    }
}
