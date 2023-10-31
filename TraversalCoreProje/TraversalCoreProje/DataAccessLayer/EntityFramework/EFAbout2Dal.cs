using DataAccessLayer.Abstract; // About2Dal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Repository;// GenericRepository sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // About2 sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFABout2Dal: GenericRepository<About2>, IAbout2Dal
    {
    }
}
