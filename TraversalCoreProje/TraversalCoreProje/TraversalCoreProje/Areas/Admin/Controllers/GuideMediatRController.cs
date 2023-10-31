using BusinessLayer.Abstract;
using EntityLayer.Concreate;
using MediatR; // IMediator interface'ni kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using NToastNotify; // IToastNotification interfaceni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.CQRS.Commends.GuideCommand;  // CreateGuideCommand sınıfını kullanabilmek için bu kütüphaneyi ekledik
using TraversalCoreProje.CQRS.Queries.GuideQuery; // GetAllGuideQuery sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/GuideMediatR")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IGuideService _guideService;
        private readonly IToastNotification _toastNotification;
        public GuideMediatRController(IMediator mediator, IToastNotification toastNotification, IGuideService guideService)
        {
            _mediator = mediator;
            _toastNotification = toastNotification;
            _guideService = guideService;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [Route("GetGuide/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetGuide(int id)
        {
            var values = await _mediator.Send(new GetGuideByIdQuery(id));
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
        public async Task<IActionResult> AddGuide(CreateGuideCommand command)
        {
            await _mediator.Send(command);
            _toastNotification.AddSuccessToastMessage("Rehber Eklendi");
            return RedirectToAction("Index");
        }
        [Route("DeleteGuide/{id}")]
        public IActionResult DeleteGuide(int id)
        {
            var values = _guideService.GetById(id);
            _guideService.TDelete(values);
            _toastNotification.AddWarningToastMessage("Rehber Silindi");
            return RedirectToAction("Index");
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
        public async Task<IActionResult> UpdateGuide(UpdateGuideCommand command)
        {
            await _mediator.Send(command);
            _toastNotification.AddSuccessToastMessage("Rehber Güncellendi");
            return RedirectToAction("Index");

        }
    }
}
