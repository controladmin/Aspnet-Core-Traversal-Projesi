using DataAccessLayer.Abstract; // IAppUserDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Repository; // GenericRepository sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
      
    }
}
