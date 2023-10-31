using EntityLayer.Concreate; // Guide sınıfını kullanmak için bu kütüphaneyi ekliyoruz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{

    // Burada Guide ilgili işlemleri yapmak için interface oluşturduk insert etme
   public interface IGuideDal:IGenericDal<Guide>
    {
        /* Guide içindeki status durumunu true ve false yapmak için hazırlandı*/
        void ChangeToTrueByGuide(int id);
        void ChangeToFalseByGuide(int id);

    }
}
