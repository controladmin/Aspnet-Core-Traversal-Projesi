using BusinessLayer.Abstract; // IDestinationService interfece'ni kullanmak için bu kütüphaneyi eliyoruz
using DataAccessLayer.Abstract; // IDestinationDal interfece'ni kullanmak için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Destination sınıfını kullanmak için bu kütüphaneyi ekliyoruz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class DestinationMenager:IDestinationService
    {
        IDestinationDal _destinationDal;

        // yapıcı metot oluşturduk parametre olarak IDestinationDal alacak
            public DestinationMenager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public Destination GetById(int id)
        {
            return _destinationDal.GetByID(id);
        }

        public List<Destination> GetList()
        {
           return _destinationDal.GetList();
        }

        public void TAdd(Destination t)
        {
            _destinationDal.insert(t);
        }

        public void TDelete(Destination t)
        {
            _destinationDal.delete(t);
        }

        public Destination TGetDestinationWithGuide(int id)
        {
            return _destinationDal.GetDestinationWithGuide(id);
        }

        public List<Destination> TGetLast4Destinations()
        {
            return _destinationDal.GetLast4Destinations();
        }

        public void TUpdate(Destination t)
        {
            _destinationDal.update(t);
        }
    }
}
