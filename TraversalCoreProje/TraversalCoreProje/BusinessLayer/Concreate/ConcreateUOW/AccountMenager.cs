using BusinessLayer.Abstract.AbstractUOW; // IAccountService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Abstract; // IAccountDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.UnitOfWork; // IUnitOfWorkDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate.ConcreateUOW
{
    public class AccountMenager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUnitOfWorkDal _unitofworkDal;

        public AccountMenager(IAccountDal accountDal, IUnitOfWorkDal unitofworkDal)
        {
            _accountDal = accountDal;
            _unitofworkDal = unitofworkDal;
        }

        public Account TGetById(int id)
        {
          return  _accountDal.GetById(id);
        }

        public void Tinsert(Account t)
        {
            _accountDal.insert(t);
            _unitofworkDal.Save(); // SveChange() metodunu interface içinden çağırıyoruz 
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
           _unitofworkDal.Save();
        }

        public void Tupdate(Account t)
        {
            _accountDal.update(t);
            _unitofworkDal.Save();

        }
    }
}
