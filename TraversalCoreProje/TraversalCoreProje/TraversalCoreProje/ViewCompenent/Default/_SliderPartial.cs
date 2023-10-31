using Microsoft.AspNetCore.Mvc; // ViewComponent yapısını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.AnaSayfa
{

    // ViewComponent sınıfından miras alacak aspnet core ile gelmiş bir özelliktir
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
