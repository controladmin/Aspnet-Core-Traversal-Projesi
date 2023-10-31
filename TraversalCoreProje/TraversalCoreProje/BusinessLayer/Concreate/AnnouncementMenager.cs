using BusinessLayer.Abstract; // IAnnouncement interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Abstract; // IAnnouncementDalinterface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class AnnouncementMenager : IAnnouncementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnouncementMenager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public Announcement GetById(int id)
        {
            return _announcementDal.GetByID(id);
        }

        public List<Announcement> GetList()
        {
            return _announcementDal.GetList();
        }

        public void TAdd(Announcement t)
        {
            _announcementDal.insert(t);
        }

        public void TDelete(Announcement t)
        {
            _announcementDal.delete(t);
        }

        public void TUpdate(Announcement t)
        {
            _announcementDal.update(t);
        }
    }
}
