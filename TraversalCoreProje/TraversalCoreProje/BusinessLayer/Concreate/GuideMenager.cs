using BusinessLayer.Abstract; // IGuideService interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Abstract; // IGuideDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class GuideMenager : IGuideService
    {
        IGuideDal _guideDal;

        public GuideMenager(IGuideDal guideDal)
        {
            _guideDal = guideDal;
        }

        public Guide GetById(int id)
        {
            return _guideDal.GetByID(id);
        }

        public List<Guide> GetList()
        {
           return  _guideDal.GetList();
        }

        public void TAdd(Guide t)
        {
            _guideDal.insert(t);
        }

        public void TChangeToFalseByGuide(int id)
        {
            _guideDal.ChangeToFalseByGuide(id);
        }

        public void TChangeToTrueByGuide(int id)
        {
            _guideDal.ChangeToTrueByGuide(id);
        }

        public void TDelete(Guide t)
        {
            _guideDal.delete(t);
        }

        public void TUpdate(Guide t)
        {
            _guideDal.update(t);
        }
    }
}
