using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.CQRS.Commends.DestinationCommand
{
    public class RemoveDestinationCommand
    {
        public RemoveDestinationCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
