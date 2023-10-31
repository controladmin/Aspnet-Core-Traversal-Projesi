using BusinessLayer.Abstract; // ITestimonailService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Abstract; // ITestimonialDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
   public class TestimonialMenager : ITestimonialService
    {

        ITestimonialDal _testimonialDal;

        // yapıcı metot constructor oluşturduk
        public TestimonialMenager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }
        public Testimonial GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Testimonial> GetList()
        {
            return _testimonialDal.GetList();
        }

        public void TAdd(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Testimonial t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Testimonial t)
        {
            throw new NotImplementedException();
        }
    }
}
