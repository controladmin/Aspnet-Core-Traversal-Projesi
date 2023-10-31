using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Guide sınıfını kullanabilmek için bu kütüphaneyi ekledik
using MediatR; // IRequestHandler interface'ni kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commends.GuideCommand; // CreateGuideCommand sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.CQRS.Handlers.GuideHandler
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name=request.Name,
                Description=request.Description,
                Status=true,
                Image=request.Image

            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
