using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;  //[key] anahtarı bu kütüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Feature2
    {

        [Key] // bu Key ifadesi Feature2ID'nin birincil anahtar olduğunu bildiriyor
        public int Feature2ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }
    }
}
