using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; // Expression sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> GetList();
        T GetById(int id);

       // List<T> GetByFilter(Expression<Func<T, bool>> filter);
          
    }
}
