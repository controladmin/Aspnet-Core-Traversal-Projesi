using DataAccessLayer.Concreate; // COntext sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.EntityFrameworkCore; // AsNoTracking metodunu kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Results.DestinationResults;  // GetAllDestinationQueryResult bu sınıfı kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandler
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;
         public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        /* AsNoTracking() = entityler üzerinde işlemler sürekli izlenir SaveChanges() metodu bu işlemleri veri tabanına yansıtır bu şekilde değişiklk entity 
         üzerinde kalıcı hale gelir  fakat herzaman kalıcı değişiklik yapmayız sadece okumaya dayalı işlemlerde yaparız sadece okunabilir işlemler için
        AsNoTracking() metodu kullanılır bu metot kullanıldığında entity üzerinde değişiklik var mı yok mu kontrol edilmez*/
        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                ID = x.DestinationID,
                Capasity = x.Capacity,
                City = x.City,
                Price = x.Price,
                DayNight = x.DayNight
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
