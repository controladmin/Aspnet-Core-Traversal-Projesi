using AspNetCoreHero.ToastNotification.Abstractions; // INotyfService kullanabilmek için ekledik
using BusinessLayer.Abstract.AbstractUOW; // IAccountService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Account sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Areas.Admin.Models; // AccountViewModel sınıfını kullanabilmek için ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
      

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

     
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetById(model.SenderID);
            var valueReceiver = _accountService.TGetById(model.ReceiverID);
            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;
            /* çoklu update için tek parametre haline getirdik liste şekline iki değeri*/
            List<Account> modifiedAccount = new List<Account>()
            {
                valueSender,
                valueReceiver
            };
            _accountService.TMultiUpdate(modifiedAccount);
            return View();
        }
    }
}
