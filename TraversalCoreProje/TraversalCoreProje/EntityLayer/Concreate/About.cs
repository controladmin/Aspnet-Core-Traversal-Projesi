using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[key] anahtarı bu kütüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class About
    {

        [Key] // bu Key ifadesi AboutID'nin birincil anahtar olduğunu bildiriyor
        public int AboutID{get;set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string Title2 { get; set; }
        public string Description2 { get; set; }
        public bool Status { get; set; }
    }
}
