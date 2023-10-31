using BusinessLayer.Concreate; // CommentMenager sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için ekledik
using DataAccessLayer.EntityFramework; // EFCommentDal sınıfını kullanabilmek için bu kütüphaneyi ekledik
using Microsoft.AspNetCore.Mvc; // ViewComponent sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.ViewCompenent.Comment
{
    public class _CommentList:ViewComponent
    {
        CommentMenager commentMenager = new CommentMenager(new EFCommentDal());
        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.commentCount = context.Comments.Where(x => x.DestinationID == id).Count();
            var values = commentMenager.TGetListCommentWithDestinationAndUser(id);
            return View(values);
        }
    }
}
