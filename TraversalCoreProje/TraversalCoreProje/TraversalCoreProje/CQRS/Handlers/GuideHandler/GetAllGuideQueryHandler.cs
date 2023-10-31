using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi ekledik
using MediatR; // IRequesthandler interface'ni kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.EntityFrameworkCore; // AsNoTracking() metodunu kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Queries.GuideQuery; // GetAllGuideQuery sınıfını kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.CQRS.Results.GuideResult; // GetAllGuideQueryResult sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.CQRS.Handlers.GuideHandler
{
    public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideID=x.GuidID,
                Name=x.Name,
                Description=x.Description,
                Image=x.Image

            }).AsNoTracking().ToListAsync();
        }
    }
}
