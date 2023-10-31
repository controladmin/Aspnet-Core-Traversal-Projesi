using BusinessLayer.Concreate; // DestinationMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework; // EFDestinationDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Reservation sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Authorization; // [AllowAnonymous] bu ifadeyi kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Identity; // UserMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // SelectListItem özelliğin kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    /*iki tane controller dosyası olduğu için b controllerin hangi kısımda olduğunu belirtiyoruz*/
    [Area("Member")]
   
    public class ReservationController : Controller
    {
        DestinationMenager destinationMenager = new DestinationMenager( new EFDestinationDal());
        ReservationMenager reservationMenager = new ReservationMenager(new EFReservationDal());
        private readonly UserManager<AppUser> _userMenager;

        public ReservationController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        public async Task<IActionResult> MyCurrentReservation()
        {

            /*Login olan kullanıcının id değerini alıp isim bilgilerine ulaşacağız burada login olmuş olan personelin onaylanmış rezervasyonlarını getirecek*/
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationMenager.GetListWithReservationByAccepted(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            /*Login olan kullanıcının id değerini alıp isim bilgilerine ulaşacağız burada login olmuş olan personelin geçmiş rezervasyonlarını getirecek*/
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationMenager.GetListWithReservationByLast(values.Id);
            return View(valuesList);
        }

        public async Task<IActionResult> MyApprovalReservation()
        {
            /*Login olan kullanıcının id değerini alıp isim bilgilerine ulaşacağız burada login olmuş olan personelin onay bekleyen rezervasyonlarını getirecek*/
            var values = await _userMenager.FindByNameAsync(User.Identity.Name);
            var valuesList= reservationMenager.GetListWithReservationByWaitApproval(values.Id);
            return View(valuesList);
        }
        

        [HttpGet]
        public IActionResult NewReservation()
        {
            /*Destination classından rota şehir isimlerini alıyoruz*/
            List<SelectListItem> values = (from x in destinationMenager.GetList()
                                           select new SelectListItem
                                           {
                                               Text=x.City,
                                               Value=x.DestinationID.ToString()
                                           }).ToList();
            ViewBag.v = values;
            return View();
        }


        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserID = 3;
            p.Status = "Onay Bekliyor";
            reservationMenager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");
        }
    }
}
