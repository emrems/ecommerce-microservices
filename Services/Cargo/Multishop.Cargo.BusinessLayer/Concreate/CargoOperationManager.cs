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
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationDal _cargoOperation;

        public CargoOperationManager(ICargoOperationDal cargoOperation)
        {
            _cargoOperation = cargoOperation;
        }

        public void TDelete(int id)
        {
            _cargoOperation.Delete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperation.GetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOperation.GetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperation.Insert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperation.Update(entity);
        }
    }
}
