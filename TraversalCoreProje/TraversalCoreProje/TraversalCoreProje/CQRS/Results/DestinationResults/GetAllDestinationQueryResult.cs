using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {

        /* burası Destination'a ait propertyleri tutacak */
        public int ID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capasity { get; set; }
    }
}
