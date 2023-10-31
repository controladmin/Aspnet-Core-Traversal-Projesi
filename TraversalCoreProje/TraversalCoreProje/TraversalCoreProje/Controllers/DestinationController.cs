using BusinessLayer.Concreate;  //  DestinationMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework;// EFDestinationDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Destination sınıfını kullanmak için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Authorization; //  [AllowAnonymous] kullanabilmek için ekledik
using Microsoft.AspNetCore.Identity; // UserMenager sınıfını kullanabilmek için ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {

        DestinationMenager destinationMenager = new DestinationMenager(new EFDestinationDal());
        private readonly UserManager<AppUser> _userMenager;

        public DestinationController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }
        public IActionResult Index()
        {
            var values = destinationMenager.GetList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> DestinationsDetails(int id)
        {
            ViewBag.i = id;
            ViewBag.destID = id; /* yorum yap kısmında destination id'yi almak için bu kodu yazdık hangi kısma yorum yazdığımızı ayırmak için*/
            /* yorum yapan kullanıcı bilgisini almak için ekledik*/
            var value = await _userMenager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = value.Id;
            var values = destinationMenager.TGetDestinationWithGuide(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult DestinationsDetails(Destination d)
        {
            return View();
        }
    }
}
