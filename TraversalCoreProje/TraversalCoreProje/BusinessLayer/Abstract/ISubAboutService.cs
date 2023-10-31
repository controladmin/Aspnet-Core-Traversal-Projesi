using EntityLayer.Concreate; // SubAbout sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISubAboutService:IGenericService<SubAbout>
    {
    }
}
