using BusinessLayer.Concreate; // guideMenager sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFGuideDal sınıfını kullanabilmek için ekledik
using Microsoft.AspNetCore.Authorization; //  [AllowAnonymous] kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideMenager guideMenager = new GuideMenager(new EFGuideDal());
        public IActionResult Index()
        {
            var values = guideMenager.GetList();
            return View(values);
        }
    }
}
