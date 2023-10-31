using DataAccessLayer.Abstract; // IAccountDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // COntext sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Repository; // GenericUOWRepository sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Account sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFAccountDal:GenericUOWRepository<Account>,IAccountDal
    {
        /* Generic UOWRepository'de tanımlanan contstructor yapıyı base ile buraya entegre etmiş olduk */
        public EFAccountDal(Context context):base(context)
        {

        }
    }
}
