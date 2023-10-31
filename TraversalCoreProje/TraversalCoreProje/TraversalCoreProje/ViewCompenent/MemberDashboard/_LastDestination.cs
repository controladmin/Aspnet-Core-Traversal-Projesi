using BusinessLayer.Abstract; // IDestinationService interface'ni kullanabilmek için ekledik
using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.MemberDashboard
{
    public class _LastDestination:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _LastDestination(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetLast4Destinations();
            return View(values);
        }
    }
}
