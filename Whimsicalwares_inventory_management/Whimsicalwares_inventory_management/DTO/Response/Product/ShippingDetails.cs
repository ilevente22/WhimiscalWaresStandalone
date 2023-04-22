using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whimsicalwares_inventory_management.DTO.response
{
    public class ShippingDetails
    {
        public bool IsNonShipping { get; set; }
        public decimal ExtraShipFee { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int ShippingSource { get; set; }
        public string ShippingSourceId { get; set; }
        public bool ShipSeparately { get; set; }
    }
}
