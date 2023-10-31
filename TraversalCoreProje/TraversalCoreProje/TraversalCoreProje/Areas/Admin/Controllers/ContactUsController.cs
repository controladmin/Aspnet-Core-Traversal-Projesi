using BusinessLayer.Abstract; // interface'ni kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ContactUs")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactusService;
        private readonly IToastNotification _toastNotification;

        public ContactUsController(IContactUsService contactusService, IToastNotification toastNotification)
        {
            _contactusService = contactusService;
            _toastNotification = toastNotification;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _contactusService.TGetListContactUsByTrue();
            return View(values);
        }
        [Route("DeleteContact/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactusService.GetById(id);
            _contactusService.TDelete(values);
            _toastNotification.AddWarningToastMessage("Mesaj Silindi");
            return RedirectToAction("Index");
        }
    }
}
