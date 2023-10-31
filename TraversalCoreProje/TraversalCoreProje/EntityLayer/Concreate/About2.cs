using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key] anahtarı bu kütüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class About2
    {
        [Key] // bu Key ifadesi About2ID'nin birincil anahtar olduğunu bildiriyor
        public int About2ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }
    }
}
