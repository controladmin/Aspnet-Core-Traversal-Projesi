using BusinessLayer.Concreate; // TestimonialMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework; //EFTestimonialDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için bu kütüphaneyi ekliyoruz
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.Default
{
    public class _Testimonial:ViewComponent
    {
        TestimonialMenager testimonialMenager = new TestimonialMenager(new EFTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values = testimonialMenager.GetList();
            return View(values);
        }
    }
}
