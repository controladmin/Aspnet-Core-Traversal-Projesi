using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // [Key] kullanabilmek için ekledik
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.DAL
{
    public enum ECity
    {
        Edirne=1,
        İstanbul=2,
        Ankara=3,
        Antalya=4,
        Bursa=5,
    }

    /* bağlantı adresini appsettings.json dosyası içine yazıyorz SignalR altındaki json dosyası
     Postgresql portu 5432'dir
     */
    public class VisitorCity
    {
        [Key]
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
