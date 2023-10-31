using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    public class DefaultController : Controller
    {
        // index üzerine sağ click add view deyip view ekliyoruz fakat bu view hangi layout ile çalışacakse o layoutu belirtiyoruz
        public IActionResult Index()
        {
            return View();
        }
    }
}
