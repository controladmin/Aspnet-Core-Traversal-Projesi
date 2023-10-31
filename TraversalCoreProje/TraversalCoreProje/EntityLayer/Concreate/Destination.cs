using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key] anahtarı bu kütüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Destination
    {
        [Key] // bu Key ifadesi DestinationID'nin birincil anahtar olduğunu bildiriyor
        public int DestinationID { get; set; }
        public string City {get;set;}

        public string DayNight { get; set; }

        public double Price { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public bool Status { get; set; }
        public string CoverImage { get; set; }
        public string Details1 { get; set; }
        public string Details2 { get; set; }
        public string Image2 { get; set; }
        public DateTime Date { get; set; }
        public  List<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }
        /* destination ile guide tablolarını ilişkilendiriyoruz*/
        public int GuidID { get; set; }
        public Guide Guide { get; set; }
    }
}
