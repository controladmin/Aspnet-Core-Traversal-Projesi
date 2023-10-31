using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; // Expression sınıfını kullanmak için bu kütüphaneyi ekledik
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>
    {

        void insert(T t);
        void update(T t);
        void delete(T t);
        List<T> GetList();
        T GetByID(int id);
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);

    }
}
