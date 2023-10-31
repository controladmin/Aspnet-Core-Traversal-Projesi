using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için ekledik
using EntityLayer.Concreate;
using MediatR; // IRequestHandler interfaceni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks; // CancellationToken kullanabilmek için ekledik
using TraversalCoreProje.CQRS.Commends.GuideCommand; // UpdateGuideCommand kullanabilmek için ekledik

namespace TraversalCoreProje.CQRS.Handlers.GuideHandler
{
    public class UpdateGuideCommandHandler:IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true,
                Image = request.Image

            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
