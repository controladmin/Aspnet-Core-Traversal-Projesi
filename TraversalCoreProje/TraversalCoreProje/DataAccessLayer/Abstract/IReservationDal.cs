using EntityLayer.Concreate; // Reservation sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal:IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id); /* Onay Bekleyen rezervasyonlar*/
        List<Reservation> GetListWithReservationByAccepted(int id); /* onay verilmiş rezervasyonlar*/
        List<Reservation> GetListWithReservationByLast(int id); /* Geçmiş rezervasyonlar*/
    }
}
