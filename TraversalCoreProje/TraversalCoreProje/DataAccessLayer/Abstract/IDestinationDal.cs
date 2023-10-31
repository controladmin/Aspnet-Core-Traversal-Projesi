using EntityLayer.Concreate; // Destination sınıfını kullanmak için bu kütüphaneyi ekliyoruz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal:IGenericDal<Destination>
    {

        /* tek değer çektiğimiz için list halinde değil sadece destination olarak tanımladık*/
        public Destination GetDestinationWithGuide(int id);
        public List<Destination> GetLast4Destinations();
    }
}
