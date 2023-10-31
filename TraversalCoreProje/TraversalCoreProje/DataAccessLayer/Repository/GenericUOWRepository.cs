using DataAccessLayer.Abstract; // IGenericUOWDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using DataAccessLayer.Concreate; // Context sınıfını kullanabilmek için bu kütüphaneyi ekledik
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericUOWRepository<T> : IGenericUOWDal<T> where T : class
    {

        private readonly Context _context;

        public GenericUOWRepository(Context context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void insert(T t)
        {
            _context.Add(t);
            //_context.SaveChanges(); SaveChanges() metodunu başka bir class'ta çağıracağız
        }

        public void MultiUpdate(List<T> t)
        {
            _context.UpdateRange(t); /* birden fazla güncelleme için UpdateRange metodunu kullanıyoruz*/
            
        }

        public void update(T t)
        {
            _context.Update(t);
        }
    }
}
