using AutoMapper; // IMapper interface'ni kullanabilmek için ekledik
using BusinessLayer.Abstract; // IContactUsService kullanabilmek için ekledik
using BusinessLayer.Concreate; // ContactMenager sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFContactUsDal sınıfını kullanabilmek için ekledik
using DTOLayer.DTOs.ContactDTOs; // SendMesajDTO sınıfını kullanabilmek için ekledik
using EntityLayer.Concreate; // ContactUs sınıfını kullanabilmek için ekledik
using Microsoft.AspNetCore.Authorization; //  [AllowAnonymous] kullanabilmek için ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactUsService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMesajDTO model)
        {
            if(ModelState.IsValid)
            {
                _contactService.TAdd(new ContactUs
                {
                    MesajDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                    MesajBody = model.MesajBody,
                    Subject = model.Subject,
                    Mail = model.Mail,
                    Status = true,
                    Name=model.Name
                }); ; ;
                return RedirectToAction("Index","Default");
            }
            return View(model);
        }
    }
}
