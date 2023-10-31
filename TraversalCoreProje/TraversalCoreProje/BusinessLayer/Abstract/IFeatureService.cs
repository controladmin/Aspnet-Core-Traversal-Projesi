using EntityLayer.Concreate; // Feature sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IFeatureService:IGenericService<Feature>
    {
    }
}
