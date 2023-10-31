using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.CQRS.Results.GuideResult
{
    public class GetGuideByIdQueryResult
    {
        public int GuideID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
