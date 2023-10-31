using BusinessLayer.Abstract; // ISubAboutService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Abstract; // ISubAboutDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class SubAboutMenager:ISubAboutService
    {
        ISubAboutDal _subaboutDal;

        // yapıcı metot constructor oluşturduk
        public SubAboutMenager(ISubAboutDal subaboutDal)
        {
            _subaboutDal = subaboutDal;
        }
        public SubAbout GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<SubAbout> GetList()
        {
            return _subaboutDal.GetList();
        }

        public void TAdd(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(SubAbout t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SubAbout t)
        {
            throw new NotImplementedException();
        }
    }
}
