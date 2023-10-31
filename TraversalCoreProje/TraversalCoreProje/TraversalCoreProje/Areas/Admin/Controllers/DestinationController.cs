using BusinessLayer.Abstract; // IDestinationService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using BusinessLayer.Concreate; // DestinationMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework; // EFDestinationDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Destination sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification interfaceni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Destination")]
    public class DestinationController : Controller
    {

        //DestinationMenager destinationMenager = new DestinationMenager(new EFDestinationDal());

        private readonly IDestinationService _destinationService;
        private readonly IToastNotification _toastNotification;

        public DestinationController(IDestinationService destinationService, IToastNotification toastNotification)
        {
            _destinationService = destinationService;
            _toastNotification = toastNotification;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationService.GetList();
            return View(values);
        }

        [Route("AddDestination")]
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [Route("AddDestination")]
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            _toastNotification.AddSuccessToastMessage("Yeni Rota Eklendi");
            return RedirectToAction("Index");
        }

        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationService.GetById(id);
            _destinationService.TDelete(values);
            _toastNotification.AddWarningToastMessage("Rota Silindi");
            return RedirectToAction("Index");
        }

        [Route("UpdateDestination/{id}")]
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            /* get olunca verileri alıp view sayfasına aktarıyor sonra üzerinde işlemler yapıyoruz*/
            var values = _destinationService.GetById(id);
            return View(values);

        }
        [Route("UpdateDestination/{id}")]
        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            _destinationService.TUpdate(destination);
            _toastNotification.AddSuccessToastMessage("Rota Güncellendi");
            return RedirectToAction("Index");

        }

    }
}
