using BusinessLayer.Abstract; // IAboutServie interface'ni kullanabilmek için bu kütüphaneyi ekliyoruz
using DataAccessLayer.Abstract; // IAboutDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AboutMenager : IAboutService
    {

        IAboutDal _aboutDal;

        // Yapıcı Metot oluşturduk bu class'ı çağırınca yapıcı metot çalışacak parametre göndereceğiz
        public AboutMenager(IAboutDal aboutdal)
        {
            _aboutDal = aboutdal;
        }

        public About GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
          return  _aboutDal.GetList();
        }

        public void TAdd(About t)
        {
            _aboutDal.insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.delete(t);
        }

        public void TUpdate(About t)
        {
            _aboutDal.update(t);
        }
    }
}
