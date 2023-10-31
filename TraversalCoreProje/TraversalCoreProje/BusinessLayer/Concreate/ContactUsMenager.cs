using BusinessLayer.Abstract; // IContactUsService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Abstract; // IContactUsDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ContactUsMenager : IContactUsService
    {

        IContactUsDal _contactusDal;

        public ContactUsMenager(IContactUsDal contactusDal)
        {
            _contactusDal = contactusDal;
        }

        public ContactUs GetById(int id)
        {
            return _contactusDal.GetByID(id);
        }

        public List<ContactUs> GetList()
        {
            return _contactusDal.GetList();
        }

        public void TAdd(ContactUs t)
        {
            _contactusDal.insert(t);
        }

        public void TContactUsStatusChangeToFalse(int id)
        {
            
        }

        public void TDelete(ContactUs t)
        {
            _contactusDal.delete(t);
        }

        public List<ContactUs> TGetListContactUsByFalse()
        {
          return  _contactusDal.GetListContactUsByFalse();
        }

        public List<ContactUs> TGetListContactUsByTrue()
        {
            return _contactusDal.GetListContactUsByTrue();
        }

        public void TUpdate(ContactUs t)
        {
            _contactusDal.update(t);
        }
    }
}
