using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için bu kütphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.AdminDashboard
{

    /* Views altında shared altında Components klasörü altına _DashboardBanner adında klasör açarız içine partial Defaul adında bir view ekleriz */
    public class _DashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
