using AspNetCoreHero.ToastNotification.Abstractions; // INotyfService kullanabilmek için ekledik
using AutoMapper; // IMapper interface'ni kullanabilmek için bu kütüphaneyi ekledik
using BusinessLayer.Abstract;  // IAnnouncementService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using BusinessLayer.ValidationRules;
using DTOLayer.DTOs; // AnnouncementAddDTO sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DTOLayer.DTOs.AnnouncementDTOs; // AnnouncementListDTO sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Announcement sınıfını kullanabilmek için bu kütüphaneyi ekledik
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification interfaceni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Announcement")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        //private readonly INotyfService _notfy;
        private readonly IToastNotification _nToastNotify;
        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper, IToastNotification nToastNotify)
        {
            _announcementService = announcementService;
            _mapper = mapper;
            _nToastNotify = nToastNotify;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            ///* view her değeri değilde istedğimiz değerleri göndermek için bu şekilde kodları yazdık*/
            //List<Announcement> announcement = _announcementService.GetList();

            ///* Areas altında Admin klasarü içindeki Model klasöründe bu classı oluşturduk listede list parametresi olarak ekledik*/
            //List<AnnouncementListViewModel> model = new List<AnnouncementListViewModel>();
            //foreach(var item in announcement)
            //{
            //    AnnouncementListViewModel annListModel = new AnnouncementListViewModel();
            //    annListModel.ID = item.AnnouncementID;
            //    annListModel.Title = item.Title;
            //    annListModel.Content = item.Title;
            //    model.Add(annListModel);
            //}

            /* mapper GetList ile gelen değerleri AnnouncementListDTO class içerisindeki propertylere atıyor Mappin klasörü altında MappinProfile diye 
               class oluşturup mapping işlemini sağladık
             
             */

            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.GetList());
            return View(values);
        }

        [Route("AddAnnouncement")]
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [Route("AddAnnouncement")]
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            //AnnouncementValidator validationRules = new AnnouncementValidator();
            //ValidationResult result = validationRules.Validate(model);

            /* ModelState ile validation kontrollerini sağlıyoruz validation şartları doğru ise true değil ise false döner*/
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                    
                });
                //_notfy.Success("Duyuru Eklendi",3);
                _nToastNotify.AddSuccessToastMessage("Duyuru Eklendi");
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Route("DeleteAnnouncement/{id}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.GetById(id);
            _announcementService.TDelete(values);
            _nToastNotify.AddWarningToastMessage("Duyuru Silindi");
            return RedirectToAction("Index");
        }

        [Route("UpdateAnnouncement/{id}")]
        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.GetById(id));
            return View(values);
        }

        [Route("UpdateAnnouncement/{id}")]
        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO model)
        {
            if (ModelState.IsValid)
            {

                _announcementService.TUpdate(new Announcement
                {
                    AnnouncementID = model.AnnouncementID,
                    Title = model.Title,
                    Content = model.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });
                //_notfy.Success("Duyuru Güncellendi",3,"green","fa fa-gear");
                //_notfy.Success("Duyuru Güncellendi", 3);
                ;_nToastNotify.AddSuccessToastMessage("Duyuru Güncellendi");
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}
