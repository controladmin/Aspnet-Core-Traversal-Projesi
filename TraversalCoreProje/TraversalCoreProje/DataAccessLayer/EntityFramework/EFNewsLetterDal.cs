using DataAccessLayer.Abstract; // INewsLetter interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Repository; // GenericRepository sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // NewsLetter sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFNewsLetterDal: GenericRepository<NewsLetter>, INewsLetterDal
    {
    }
}
