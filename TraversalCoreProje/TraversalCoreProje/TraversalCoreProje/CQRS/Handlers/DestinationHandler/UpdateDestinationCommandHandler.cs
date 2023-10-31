using DataAccessLayer.Concreate; // COntext sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commends.DestinationCommand; // (UpdateDestinationCommand sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandler
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;
public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationID);
            values.City = command.City;
            values.Capacity = command.Capacity;
            values.Price = command.Price;
            values.DayNight = command.DayNight;
            _context.SaveChanges();
        }

    }
}
