using BusinessLayer.Abstract; // IFeatureService interface'ni kullanabilmek için bu kütüphaneyi ekliyoruz
using DataAccessLayer.Abstract; // IFeatureDal interface'ni kullanabilmek için bu kütüphaneyi ekledik
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate
{
    public class FeatureMenager : IFeatureService
    {

        IFeatureDal _featureDal;

        public FeatureMenager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }
        public Feature GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Feature> GetList()
        {
            return _featureDal.GetList();
        }

        public void TAdd(Feature t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Feature t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Feature t)
        {
            throw new NotImplementedException();
        }
    }
}
