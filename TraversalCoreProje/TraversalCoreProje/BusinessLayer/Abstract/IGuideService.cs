using EntityLayer.Concreate; // Guide sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGuideService:IGenericService<Guide>
    {
        /* Guide içindeki status durumunu true ve false yapmak için hazırlandı*/
        void TChangeToTrueByGuide(int id);
        void TChangeToFalseByGuide(int id);

    }
}
