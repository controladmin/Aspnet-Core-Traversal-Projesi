using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Destination sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commends.DestinationCommand; // CreateDestinationCommand sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandler
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new Destination
            {
                City=command.City,
                Capacity=command.Capasity,
                Price=command.Price,
                DayNight=command.DayNight,
                Status=true

            });
            _context.SaveChanges();
        }
    }
}
