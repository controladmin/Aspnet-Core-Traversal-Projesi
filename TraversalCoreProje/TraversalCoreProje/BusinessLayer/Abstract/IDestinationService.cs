using EntityLayer.Concreate; // Destination sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDestinationService:IGenericService<Destination>
    {
        /* tek değer çektiğimiz için list halinde değil sadece destination olarak tanımladık*/
        public Destination TGetDestinationWithGuide(int id);
        public List<Destination> TGetLast4Destinations();
    }
}
