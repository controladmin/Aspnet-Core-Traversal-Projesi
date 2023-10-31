using BusinessLayer.Abstract; // IReservationService interface'ni kullanabilmek için bu kütüphneyi ekledik
using DataAccessLayer.Abstract; // IReservationDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class ReservationMenager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationMenager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            return _reservationDal.GetListWithReservationByAccepted(id);
        }

        public List<Reservation> GetListWithReservationByLast(int id)
        {
            return _reservationDal.GetListWithReservationByLast(id);
        }

        public List<Reservation> GetListWithReservationByWaitApproval(int id)
        {
           return   _reservationDal.GetListWithReservationByWaitApproval(id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.insert(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.delete(t);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.update(t);
        }
    }
}
