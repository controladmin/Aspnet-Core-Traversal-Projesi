using DataAccessLayer.Abstract; // ICommenttDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Repository; // GenercRepository sınıfını kullanmak için bu kütüphaneyi ekledik
using EntityLayer.Concreate; // Comment sınıfını kullanmak için bu kütüphaneyi ekledik
using Microsoft.EntityFrameworkCore; // Include sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetListCommentWithDestination()
        {
          using (var c=new Context())
            {
                /*burada Comments tablosuna Destination tablosunu include ediyor tabloda Destination.City şeklinde kullanabilmek için
                 daha sorna Business tarafında da çağırıyoruz ICommentService içinde ve CommentMenager içinde de çağırıyoruz implement ediyoruz */
                return c.Comments.Include(x => x.Destination).ToList();
            }
        }

        public List<Comment> GetListCommentWithDestinationAndUser(int id)
        {
            using (var c = new Context())
            {
                /*burada Comments tablosuna AppUser tablosunu include ediyoruz */
                return c.Comments.Where(x=>x.DestinationID==id).Include(x => x.AppUser).ToList();
            }
        }
    }
}
