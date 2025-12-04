using Multishop.Cargo.BusinessLayer.Abstract;
using Multishop.Cargo.DataAccessLayer.Abstract;
using Multishop.Cargo.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.BusinessLayer.Concreate
{
    public class CargoDetailManager : ICargoDetailService
    {
        private readonly ICargoDetailDal _cargoDetail;

        public CargoDetailManager(ICargoDetailDal cargoDetail)
        {
            _cargoDetail = cargoDetail;
        }

        public void TDelete(int id)
        {
            _cargoDetail.Delete(id);
        }

        public List<CargoDetail> TGetAll()
        {
            return _cargoDetail.GetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoDetail.GetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _cargoDetail.Insert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoDetail.Update(entity);
        }
    }
}
