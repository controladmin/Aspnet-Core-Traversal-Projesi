using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] anahtarı bu kürüphaneden geliyor
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Feature
    {
        [Key] // bu Key ifadesi FeatureID'nin birincil anahtar olduğunu bildiriyor
        public int FeatureID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool Status { get; set; }
    }
}
