using DataAccessLayer.Abstract; // IContactDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.Repository; // GenericRepository sınıfını kullanabilmek için bu kütüphaneyi yükledik
using EntityLayer.Concreate; // Destination sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.EntityFrameworkCore; // Include sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public Destination GetDestinationWithGuide(int id)
        {
            using(Context c=new Context())
            {
                return c.Destinations.Where(x=>x.DestinationID==id).Include(x => x.Guide).FirstOrDefault();
            }
        }

        public List<Destination> GetLast4Destinations()
        {
            using(var context=new Context())
            {
                /* take 4 demek 4 tane veriyi getir demek sqlde top komutu gibi*/
                var values = context.Destinations.Take(4).OrderByDescending(x => x.DestinationID).ToList();
                return values;
            }
        }

    }
}
