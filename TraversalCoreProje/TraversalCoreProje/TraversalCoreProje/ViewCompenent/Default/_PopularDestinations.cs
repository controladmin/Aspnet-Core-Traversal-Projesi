using BusinessLayer.Concreate; // DestinationMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework; // sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanmak için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.Default
{
    public class _PopularDestinations:ViewComponent
    {

        DestinationMenager destinationMenager = new DestinationMenager(new EFDestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = destinationMenager.GetList();
            // aldığımız değeri view sayfasına parametre olarak gönderiyoruz
            return View(values);
        }
    }
}
