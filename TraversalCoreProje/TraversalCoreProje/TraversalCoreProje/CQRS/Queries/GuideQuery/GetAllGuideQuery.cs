using MediatR; // IRequest interface'ni kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Results.GuideResult; // GetAllGuideQueryResul sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.CQRS.Queries.GuideQuery
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
