using DataAccessLayer.Concreate; // COntext sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Queries.DestinationQuery; // GetDestinationByIdQuery bu sınıfı kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.CQRS.Results.DestinationResults; // GetDestinationByIdQueryResult bu sınıfı kullanabilmek için bu kütüphaneyi ekledik


namespace TraversalCoreProje.CQRS.Handlers.DestinationHandler
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.ID);
            return new GetDestinationByIdQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price,
                Capacity=values.Capacity
            };
        }


    }
}
