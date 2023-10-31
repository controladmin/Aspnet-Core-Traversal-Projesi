using BusinessLayer.Abstract; // ICommentService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using BusinessLayer.Concreate; // CommentMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.EntityFramework; // EFCommentDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc;
using NToastNotify;  // IToastNotification  interfeceni kullanabilmek için ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
   [Route("Admin/Comment")]
    public class CommentController : Controller
    {

        /* bu şekilde interface ile çağırıp Constructur oluşturunca hata verir böyle kullanmak istiyorsan Startup tarafında yapılandırmak gerekir
         configure etmeliyiz startup içine  
        services.AddScoped<ICommentService, CommentMenager>(); 
        services.AddScoped<ICommentDal, EFCommentDal>();
        bu iki ifadeyi ekliyoruz ConfigureServices Metodu içine
        
         bunu niye yaptık ConfgureMenager configureMenager=new ConfigureMenager(new EFCommentDal()) bağımlılığını kaldırmak için*/
        private readonly ICommentService _commentService;
        private readonly IToastNotification _toastNotification;

        public CommentController(ICommentService commentService, IToastNotification toastNotification)
        {
            _commentService = commentService;
            _toastNotification = toastNotification;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            /*DestinationCity şeklinde kullanabilmek için bu şekilde yazdık*/
            var values = _commentService.TGetListCommentWithDestination();
            return View(values);
        }

        [Route("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            var values = _commentService.GetById(id);
            _commentService.TDelete(values);
            _toastNotification.AddWarningToastMessage("Yorum Silindi");
            return RedirectToAction("Index");
        }
    }
}
