using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] anahtarı bu kütüphneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
   public class SubAbout
    {
        [Key] // bu Key ifadesi SubAboutID'nin birincil anahtar olduğunu bildiriyor
        public int SubAboutID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
