using BusinessLayer.Concreate; // CmmentMenager sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFCommentDal sınıfını kullanmak için ekledik
using EntityLayer.Concreate; // Comment sınıfını kullanabilmek için ekledik
using Microsoft.AspNetCore.Identity; // UserMenager sınıfını kullanabilmek için ekledik
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Controllers
{
    public class CommentController : Controller
    {
        CommentMenager commentMenager = new CommentMenager(new EFCommentDal());

        private readonly UserManager<AppUser> _userMenager;

        public CommentController(UserManager<AppUser> userMenager)
        {
            _userMenager = userMenager;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.CommentDate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
            p.CommentState = true;
            // Yorum ekleme yapmak için web sayfasından
            commentMenager.TAdd(p);
            return RedirectToAction("Index", "Destination");
        }
    }
}
