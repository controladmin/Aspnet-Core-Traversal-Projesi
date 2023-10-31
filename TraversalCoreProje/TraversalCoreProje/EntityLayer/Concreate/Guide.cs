using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[key] anahtarı bu kütüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Guide
    {

        [Key] // bu Key ifadesi GuideID'nin birincil anahtar olduğunu bildiriyor
        public int GuidID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string TwitterUrl { get; set; }
        public string Description2 { get; set; }
        public string GuideListImage { get; set; }
        public string InstegramUrl { get; set; }
        public bool Status { get; set; }
        public List<Destination> Destinations { get; set; }
    }
}
