using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whimsicalwares_inventory_management.DTO.Response.ProductInventory
{
    public class InventoryItem
    {
        public string Bvin { get; set; }
        public DateTime LastUpdated { get; set; }
        public string ProductBvin { get; set; }
        public string VariantId { get; set; }
        public int QuantityOnHand { get; set; }
        public int QuantityReserved { get; set; }
        public int LowStockPoint { get; set; }
        public int OutOfStockPoint { get; set; }
    }
}
