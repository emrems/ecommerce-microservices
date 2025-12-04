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
    public class CargoCustomerManager : ICargoCustomerService
    {
        private readonly ICargoCustomerDal _cargoCustomer;

        public CargoCustomerManager(ICargoCustomerDal cargoCustomer)
        {
            _cargoCustomer = cargoCustomer;
        }

        public void TDelete(int id)
        {
            _cargoCustomer.Delete(id);
        }

        public List<CargoCustomer> TGetAll()
        {
            return _cargoCustomer.GetAll();
        }

        public CargoCustomer TGetById(int id)
        {
            return _cargoCustomer.GetById(id);
        }

        public void TInsert(CargoCustomer entity)
        {
            _cargoCustomer.Insert(entity);
        }

        public void TUpdate(CargoCustomer entity)
        {
            _cargoCustomer.Update(entity);
        }
    }
}
