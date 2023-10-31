using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] ifadesi bu kütüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Testimonial
    {

        [Key] // bu Key ifadesi TestimonialID'nin birincil anahtar olduğunu bildiriyor
        public int TestimonialID { get; set; }

        public string Client { get; set; }

        public string Comment { get; set; }

        public string ClientImage { get; set; }

        public bool Status { get; set; }
    }
}
