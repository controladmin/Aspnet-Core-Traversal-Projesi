using BusinessLayer.Abstract; // IGuideService interface'Ni kullanabilmek için bu kütüphaneyi ekledik
using BusinessLayer.ValidationRules; // GuideValidator sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Guide sınıfını kullanabilmek için bu kütüphaneyi ekledik
using FluentValidation.Results; // ValidationResult sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;
        private readonly IToastNotification _toastNotification;

        public GuideController(IGuideService guideService, IToastNotification toastNotification)
        {
            _guideService = guideService;
            _toastNotification = toastNotification;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.GetList();
            return View(values);
        }

        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if(result.IsValid)
            {
                _guideService.TAdd(guide);
                _toastNotification.AddSuccessToastMessage("Rehber Sisteme Eklendi");
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                _toastNotification.AddErrorToastMessage("Rehber Sisteme Eklenemedi");
                return View();
            }
           
        }

        [Route("UpdateGuide/{id}")]
        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var values = _guideService.GetById(id);
            return View(values);
        }

        [Route("UpdateGuide/{id}")]
        [HttpPost]
        public IActionResult UpdateGuide(Guide guide)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(guide);
            if (result.IsValid)
            {
                _guideService.TUpdate(guide);
                _toastNotification.AddSuccessToastMessage("Rehber Güncellendi");
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                _toastNotification.AddErrorToastMessage("Rehber Güncellenemedi");
                return View();
            }
        }


        [Route("DeleteGuide/{id}")]
        public IActionResult DeleteGuide(int id)
        {
            var values = _guideService.GetById(id);
            _guideService.TDelete(values);
            _toastNotification.AddWarningToastMessage("Rehber Sistemden Silindi");
            return RedirectToAction("Index");
        }

        [Route("ChangeToFalse/{id}")]
        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            _toastNotification.AddAlertToastMessage("Durum Pasif Edildi");
            return RedirectToAction("Index", "Guide", new { area = "Admin" }); /* Bu atamayı yapmaz isek sayfa yönlenmez çünkü area içinde*/
        }

        [Route("ChangeToTrue/{id}")]
        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            _toastNotification.AddAlertToastMessage("Durum Aktif Edildi");
            return RedirectToAction("Index", "Guide", new { area = "Admin" }); /* Bu atamayı yapmaz isek sayfa yönlenmez çünkü area içinde*/

        }
       
    }
}
