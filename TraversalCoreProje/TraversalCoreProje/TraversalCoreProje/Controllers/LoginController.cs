using EntityLayer.Concreate; // AppUser sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization; // [AllowAnonymous] kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Identity; // UserMenager sınıfını kullanabilmek için ekledik bu kütüphaneyi
using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification interface'ni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TraversalCoreProje.Models; // UserRegisterViewModel sınıfını kullanabilmek için bu kütühaneyi ekledik

namespace TraversalCoreProje.Controllers
{
    /*buraya herhalukarda erişim sağlanması için altında bulunan metot class yada kendisinin üstü olan bütün kodları
     geçerli bütün kurallardan muaf ediyor tanımlı olmayan kullanıcılarda erişmesine izin veriyor*/
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly UserManager<AppUser> _userMenager;
        private readonly SignInManager<AppUser> _signInMenager;
        private readonly IToastNotification _toastNotification;

        public LoginController(UserManager<AppUser> userMenager, SignInManager<AppUser> signInMenager, IToastNotification toastNotification)
        {
            _userMenager = userMenager;
            _signInMenager = signInMenager;
            _toastNotification = toastNotification;
        }

        [HttpGet]

        /*sağ click add view diyoruz bu view partial olmayacak ve herhangi bir layout kullanmayacak kendi başına olacak*/
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        /* Model klasörü altında class tanımladık bu isimde kayıt işlemlerini kontrol etmek için*/
        public async Task<IActionResult> SignUp(UserRegisterViewModel p) 
        {
            AppUser _appUser = new AppUser()
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                UserName = p.Username
            };
            if(p.Password==p.ConfirmPassword)
            {
                /* şifre arka planda hashlenerek gönderileceği için böyle aldık*/
                var result = await _userMenager.CreateAsync(_appUser, p.Password); 
                if(result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("Üyelik İşlemi Gerçekleştirildi");
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        _toastNotification.AddErrorToastMessage("Üyelik İşlemi Gerçekleştirelemedi");
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        /*sağ click add view diyoruz bu view partial olmayacak ve herhangi bir layout kullanmayacak kendi başına olacak*/
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        /* Model klasörü altında class tanımladık bu isimde login işlemlerini kontrol etmek için*/
        public async Task <IActionResult> SignIn(UserSignInViewModel p)
        {

            if(ModelState.IsValid)
            {
                /*false şifre hatırlansın mı diye true alanı ise şifre belli sayıda girilince bloke olsun mu diye gelen parametrelerdir*/
                var result = await _signInMenager.PasswordSignInAsync(p.Username,p.Password,false,true);
                if(result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("Hoş Geldiniz");
                    return RedirectToAction("Index","Profile",new {area="Member" });
                }
                else
                {
                    //_toastNotification.AddErrorToastMessage("Giriş Sağlanamadı Tekrar Deneyiniz");
                    return RedirectToAction("SignIn","Login");
                }
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn","Login");
        }
    }
}
