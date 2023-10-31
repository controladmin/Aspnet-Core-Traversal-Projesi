using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key] anahtarı bu kütüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class NewsLetter
    {
        [Key] // bu Key ifadesi NewsLetterID'nin birincil anahtar olduğunu bildiriyor
        public int NewsLetterID { get; set; }
        public string Mail { get; set; }
    }
}
