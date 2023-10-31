using BusinessLayer.Concreate; // 
using DataAccessLayer.EntityFramework; //
using EntityLayer.Concreate; // AppUser sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Identity; // UserMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc; // IViewComponentResult bu interface'ni kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.MemberDashboard
{
    public class _ProfileInformation:ViewComponent
    {

        private readonly UserManager<AppUser> _userMenager;

        public _ProfileInformation(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            ViewBag.MemberName = values.Name + " " + values.Surname;
            ViewBag.MemberPhone = values.PhoneNumber;
            ViewBag.MemberMail = values.Email;
            return View();
        }
    }
}
