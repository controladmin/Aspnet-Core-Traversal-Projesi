using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; // Expression sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public interface IGenericUOWDal<T> where T:class
    {

        void insert(T t);
        void update(T t);
        void MultiUpdate(List<T> t); // Aynı anda birden fazla kaydı güncelleyebileceğiz
        T GetById(int id);
     
    }
}
