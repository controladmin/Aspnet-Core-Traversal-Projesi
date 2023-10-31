using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi ekledik
using MediatR; // IRequestHandler interface'Ni kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Queries.GuideQuery; // GetGuideByIdQuery sınıfını kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.CQRS.Results.GuideResult; // GetGuideByIdQueryResult sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.CQRS.Handlers.GuideHandler
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {

        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context)
        {
            this._context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.ID);
            return new GetGuideByIdQueryResult
            {
                GuideID = values.GuidID,
                Description = values.Description,
                Name=values.Name

            };
        }
    }
}
