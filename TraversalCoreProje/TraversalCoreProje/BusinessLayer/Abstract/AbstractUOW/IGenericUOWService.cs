using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUOW
{
   public interface IGenericUOWService<T>
    {

        void Tinsert(T t);
        void Tupdate(T t);
        void TMultiUpdate(List<T> t); // Aynı anda birden fazla kaydı güncelleyebileceğiz
        T TGetById(int id);
    }
}
