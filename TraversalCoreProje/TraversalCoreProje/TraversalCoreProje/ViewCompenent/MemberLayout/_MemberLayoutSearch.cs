using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanmak için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.MemberLayout
{
    public class _MemberLayoutSearch:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
