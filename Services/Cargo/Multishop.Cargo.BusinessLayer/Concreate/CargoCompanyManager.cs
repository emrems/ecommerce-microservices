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
    public class CargoCompanyManager : ICargoCompanyService
    {
        private readonly ICargoCompanyDal _cargoCompany;

        public CargoCompanyManager(ICargoCompanyDal cargoCompany)
        {
            _cargoCompany = cargoCompany;
        }
        public void TDelete(int id)
        {
            _cargoCompany.Delete(id);
        }

        public List<CargoCompany> TGetAll()
        {
            return _cargoCompany.GetAll();
        }

        public CargoCompany TGetById(int id)
        {
            return _cargoCompany.GetById(id);
        }

        public void TInsert(CargoCompany entity)
        {
            _cargoCompany.Insert(entity);
        }

        public void TUpdate(CargoCompany entity)
        {
            _cargoCompany.Update(entity);
        }
    }
}
