using DataAccessLayer.Abstract; //IGuide interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // COntext sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Repository; // GenericRepository sınıfını kulanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Guide sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFGuideDal : GenericRepository<Guide>, IGuideDal
    {
        public void ChangeToFalseByGuide(int id)
        {
            Context c = new Context();
            var values = c.Guides.Find(id);
            values.Status = false;
            c.Update(values);
            c.SaveChanges();
            
        }

        public void ChangeToTrueByGuide(int id)
        {
            Context c = new Context();
            var values = c.Guides.Find(id);
            values.Status = true;
            c.Update(values);
            c.SaveChanges();
        }
    }
}
