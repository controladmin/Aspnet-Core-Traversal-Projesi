using Microsoft.AspNetCore.Authorization;  // [AllowAnonymous] bu ifadeyi kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*bu controller Areas klasörü altındaki Controller*/
namespace TraversalCoreProje.Areas.Member.Controllers
{

    /*iki tane controller dosyası olduğu için b controllerin hangi kısımda olduğunu belirtiyoruz*/
    [Area("Member")]
  
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
