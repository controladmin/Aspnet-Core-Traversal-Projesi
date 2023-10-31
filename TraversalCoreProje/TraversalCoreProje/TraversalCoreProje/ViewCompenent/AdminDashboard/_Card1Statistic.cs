using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.AdminDashboard
{
    public class _Card1Statistic:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.tursayisi = c.Destinations.Count();
            ViewBag.misafirsayisi = c.Users.Count();
            return View();
        }
    }
}
