using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Models
{
    public class AnnouncementListViewModel
    {

        /* 
         DTO ile çalışma yaptımız için bu viewModel classına ihtiyaç kalmadı AnnouncementController kısmında index altında kullanılan kodlar yorum satırı
         haline getirildi eğer bu classı kullansaydık o kodları aktif edecektik burası şuan için iptal
        */
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
