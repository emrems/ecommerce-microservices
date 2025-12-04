using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.Cargo.DtosLayer.Dtos.CargoDetailsDtos
{
    public class UpdateCargoDetailDto
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; } //gönderici
        public string ReciverCustomer { get; set; }//alıcı
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
       
    }
}
