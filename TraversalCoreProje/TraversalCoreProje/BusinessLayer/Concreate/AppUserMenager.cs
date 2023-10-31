using BusinessLayer.Abstract; // IAppUserService interface'i kullanabilmek için u kütüphaneyi ekledik
using DataAccessLayer.Abstract; // IAppUserDal inteface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AppUserMenager : IAppUserService
    {
        IAppUserDal _appuserDal;

        public AppUserMenager(IAppUserDal appuserDal)
        {
            _appuserDal = appuserDal;
        }

        public AppUser GetById(int id)
        {
          return  _appuserDal.GetByID(id);
        }

        public List<AppUser> GetList()
        {
            return _appuserDal.GetList();
        }

        public void TAdd(AppUser t)
        {
            _appuserDal.insert(t);
        }

        public void TDelete(AppUser t)
        {
            _appuserDal.delete(t);
        }

        public void TUpdate(AppUser t)
        {
            _appuserDal.update(t);
        }
    }
}
