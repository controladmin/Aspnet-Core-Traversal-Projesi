using DataAccessLayer.Abstract; // SubAbout interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Repository; // GenericRepository sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // SubAbout sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
   public class EFSubAboutDal: GenericRepository<SubAbout>, ISubAboutDal
    {
    }
}
