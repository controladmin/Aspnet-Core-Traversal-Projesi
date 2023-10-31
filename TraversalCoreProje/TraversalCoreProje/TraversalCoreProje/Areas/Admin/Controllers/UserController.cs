using BusinessLayer.Abstract;// IAppUserService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Abstract; // IAppUserDal interface'ni kullanabilmek için bu kütüphaneyi ekliyoruz
using EntityLayer.Concreate; // AppUser sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification interface'ni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models; // UserRegisterViewModel sınıfını kullanabilmek için bu kütühaneyi ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appuserService;
        private readonly IReservationService _reservationService;
        private readonly IToastNotification _toastNotification;
        private readonly UserManager<AppUser> _userMenager;

        public UserController(IAppUserService appuserService, IReservationService reservationService, IToastNotification toastNotification, UserManager<AppUser> userMenager)
        {
            _appuserService = appuserService;
            _reservationService = reservationService;
            _toastNotification = toastNotification;
            _userMenager = userMenager;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _appuserService.GetList();
            return View(values);
        }

        [Route("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var values = _appuserService.GetById(id);
            _appuserService.TDelete(values);
            _toastNotification.AddWarningToastMessage("Kullanıcı Silindi");
            return RedirectToAction("Index");
        }

        [Route("UpdateUser/{id}")]
        [HttpGet]
        public IActionResult UpdateUser(int id)
        {
            var values = _appuserService.GetById(id);
            return View(values);
        }

        [Route("UpdateUser/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserRegisterViewModel user)
        {
            AppUser _appUser = new AppUser()
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Mail,
                UserName = user.Username
            };
            if (user.Password == user.ConfirmPassword)
            {
                /* şifre arka planda hashlenerek gönderileceği için böyle aldık*/
                var result = await _userMenager.CreateAsync(_appUser, user.Password);
                if (result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("Kullanıcı Güncellendi");
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        _toastNotification.AddErrorToastMessage("Kullanıcı Güncellenemedi");
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(user);
        }

        public IActionResult CommentUser(int id)
        {
            _appuserService.GetList();
            return View();
        }

        [Route("ReservationUser/{id}")]
        public IActionResult ReservationUser(int id)
        {
           var values= _reservationService.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
