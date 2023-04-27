using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whimsicalwares_inventory_management.DTO.Response.ProductInventory.Request
{
    public class CreateInventoryDto
    {
        public String ProductBvin { get; set; }
        public int QuantityOnHand { get; set; }
        public int LowStockPoint { get; set; }
        public int OutOfStockPoint { get; set; }
    }
}
