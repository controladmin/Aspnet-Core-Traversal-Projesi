using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi ekliyoruz
using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.Default
{
    public class _Statistic:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            // ViewBag controller üzerinden view tarafına veri çekmek için kullanılır
            using var c = new Context();
                ViewBag.v1 = c.Destinations.Count();
                ViewBag.v2 = c.Guides.Count();
                ViewBag.v3 = "300";
            return View();
        }
    }
}
