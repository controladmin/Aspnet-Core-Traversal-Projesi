using BusinessLayer.Concreate; // GuideMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework; //EFGuideDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.MemberDashboard
{
    public class _RehberList:ViewComponent
    {
        GuideMenager guideMenager = new GuideMenager(new EFGuideDal());
        public IViewComponentResult Invoke()
        {
            var values = guideMenager.GetList();
                return View(values);
        }
    }
}
