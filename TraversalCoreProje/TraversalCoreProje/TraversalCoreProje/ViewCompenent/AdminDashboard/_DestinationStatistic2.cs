﻿using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.AdminDashboard
{
    public class _DestinationStatistic2:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
