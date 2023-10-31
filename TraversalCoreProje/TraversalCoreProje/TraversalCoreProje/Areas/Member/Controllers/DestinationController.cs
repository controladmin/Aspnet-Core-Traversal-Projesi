using BusinessLayer.Concreate; // DestinationMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework; // EFDestinationDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Authorization; //  [AllowAnonymous] bu ifadeyi kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*bu controller Areas klasörü altındaki Controller*/
namespace TraversalCoreProje.Areas.Member.Controllers
{

    /*iki tane controller dosyası olduğu için b controllerin hangi kısımda olduğunu belirtiyoruz*/
    [Area("Member")]
    [Route("Member/Destination")]
    public class DestinationController : Controller
    {
        DestinationMenager _destinationMenager = new DestinationMenager(new EFDestinationDal());
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _destinationMenager.GetList();
            return View(values);
        }
        /* filtre ile şehir araması yapmak için kullanıyoruz*/
        [Route("GetCitiesSearchByName")]
        public IActionResult GetCitiesSearchByName(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values = from x in _destinationMenager.GetList() select x;
            if(!string .IsNullOrEmpty(searchString))
            {
                values = values.Where(y => y.City.Contains(searchString));
            }
            return View(values.ToList());
        }
    }
}
