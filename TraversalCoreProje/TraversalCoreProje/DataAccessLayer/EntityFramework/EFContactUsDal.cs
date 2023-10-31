using DataAccessLayer.Abstract; // IContactDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // COntext sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Repository; // GenericRepository sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // ContactUs sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFContactUsDal : GenericRepository<ContactUs>, IContactUsDal
    {
        public void ContactUsStatusChangeToFalse(int id)
        {
            throw new NotImplementedException();
        }

        public List<ContactUs> GetListContactUsByFalse()
        {
            using(var c=new Context())
            {
                var values = c.ContactUses.Where(x => x.Status == false).ToList();
                return values;
            }
        }

        public List<ContactUs> GetListContactUsByTrue()
        {
            using (var c = new Context())
            {
                var values = c.ContactUses.Where(x => x.Status == true).ToList();
                return values;
            }
        }
    }
}
