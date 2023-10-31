using EntityLayer.Concreate; // Reservation sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitApproval(int id); /* Onay Bekleyen rezervasyonlar*/
        List<Reservation> GetListWithReservationByAccepted(int id); /* Onaylanmış rezarvasyonlar*/
        List<Reservation> GetListWithReservationByLast(int id); /* Geçmiş rezarvasyonlar*/
    }
}
