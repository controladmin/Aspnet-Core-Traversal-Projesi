using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //[Key] anahtarı bu kütüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Contact
    {
        [Key] // bu Key ifadesi ContactID'nin birincil anahtar olduğunu bildiriyor
        public int ContactID { get; set; }
        public string Description { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Map { get; set; }
        public bool Status { get; set; }
    }
}
