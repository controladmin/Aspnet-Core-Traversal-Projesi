using BusinessLayer.Abstract; // ICommentService interface'ni kullanabilmek için bu kütphaneyi ekledik
using DataAccessLayer.Abstract; // ICommentDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class CommentMenager : ICommentService
    {

        ICommentDal _commentDal;

        public CommentMenager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public Comment GetById(int id)
        {
            return _commentDal.GetByID(id);
        }

        public List<Comment> GetList()
        {
            return _commentDal.GetList();
        }
        public List<Comment> TGetDestinationByID(int id)
        {
            return _commentDal.GetListByFilter(x=>x.DestinationID==id);
        }

        public void TAdd(Comment t)
        {
            _commentDal.insert(t);
        }

        public void TDelete(Comment t)
        {
            _commentDal.delete(t);
        }

        public void TUpdate(Comment t)
        {
            _commentDal.update(t);
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> TGetListCommentWithDestinationAndUser(int id)
        {
            return _commentDal.GetListCommentWithDestinationAndUser(id);
        }
    }
}
