using BusinessLayer.Concreate; // SubAboutMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework; // EFSubAboutDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.Default
{
    public class _SubAbout:ViewComponent
    {
        SubAboutMenager subAboutMenager = new SubAboutMenager(new EFSubAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = subAboutMenager.GetList();
            return View(values);
        }
    }
}
