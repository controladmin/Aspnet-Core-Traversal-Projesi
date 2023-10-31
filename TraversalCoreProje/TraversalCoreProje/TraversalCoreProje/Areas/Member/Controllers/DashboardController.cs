using EntityLayer.Concreate; // AppUser sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Identity; // UserMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userMenager;

        public DashboardController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = values.Name + " " + values.Surname;
            ViewBag.UserImage = values.ImageUr;
            return View();
        }
        public async Task<IActionResult> MemberDashboard()
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserName = values.Name + " " + values.Surname;
            ViewBag.UserImage = values.ImageUr;
            return View();
        }
    }
}
