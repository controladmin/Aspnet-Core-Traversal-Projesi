using BusinessLayer.Abstract; // IDestinationServie interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Destination sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json; // JsonCOvert sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProje.Models; // AjaxCityClass sınıfını kullanabilmek için bu kütüphaneyi ekledik

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AjaxCityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public IActionResult Index()
        {
            return View();
        }
        public AjaxCityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.GetList()); /* _destinationService.getList() listesini json formata çevirdik*/
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination); /* destination ifadesini json formata çevirdi*/
            return Json(values);

        }
       public IActionResult GetById(int DestinationID)
        {
           var values=_destinationService.GetById(DestinationID);
            if(values==null)
            {
                return View();
            }
            else
            {
                var jsonValues = JsonConvert.SerializeObject(values); /* bu ifadeyi json formata çevirdik*/
                return Json(jsonValues);
            }
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.GetById(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            var values = _destinationService.GetById(destination.DestinationID);
            destination.Status = values.Status;
            destination.Price = values.Price;
            destination.Image = values.Image;
            destination.Description = values.Description;
            destination.Capacity = values.Capacity;
            destination.CoverImage = values.CoverImage;
            destination.Details1 = values.Details1;
            destination.Details2 = values.Details2;
            destination.Image2 = values.Image2;
            _destinationService.TUpdate(destination);
            var jsonvalues = JsonConvert.SerializeObject(destination);
            return Json(jsonvalues);
        }
    }
}
