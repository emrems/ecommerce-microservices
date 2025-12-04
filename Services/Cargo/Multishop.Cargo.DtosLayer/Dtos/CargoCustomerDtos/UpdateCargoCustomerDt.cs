using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DtosLayer.Dtos.CargoCustomerDtos
{
    public class UpdateCargoCustomerDt
    {
        public int CargoCustomerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string District { get; set; }
        public string City { get; set; }
    }
}
