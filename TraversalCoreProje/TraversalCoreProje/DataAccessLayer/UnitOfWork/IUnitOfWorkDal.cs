using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWorkDal
    {
        /* Unit Of Work Context sınıfında SaveChanges() metodunu işlem sonunda kullanmamak için bu şekilde bir işlem yaptık
         BU interface'İ UnitOfWork class'da çağırdık 
         */
        void Save();
    }
}
