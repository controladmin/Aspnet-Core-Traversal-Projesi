using Microsoft.AspNetCore.Mvc;// ViewComponenti kullanabilmek için bu kütüphaneyi ekledik
using BusinessLayer.Concreate; // EFFeatureDal sınıfını kullanmak için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.EntityFramework;

namespace TraversalCoreProje.ViewCompenent.Default
{
    public class _Feature:ViewComponent
    {
        FeatureMenager featureMenager = new FeatureMenager(new EFFeatureDal());

        public IViewComponentResult Invoke()
        {
           // var values = featureMenager.GetList();
           // resimler aynı standart divlerde olmadığı için ViewBag'ler ile taşıyacağız
        
            return View();
        }
    }
}
