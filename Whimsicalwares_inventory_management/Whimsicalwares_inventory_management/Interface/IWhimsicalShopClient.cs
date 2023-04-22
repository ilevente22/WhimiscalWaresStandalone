using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whimsicalwares_inventory_management.DTO.response;
using Whimsicalwares_inventory_management.DTO.Response.ProductInventory;

namespace Whimsicalwares_inventory_management.Interface
{
    public interface IWhimsicalShopClient
    {
        Task<List<ProductDto>> GetProducts();

        Task<List<InventoryItem>> GetInventoryItems();

        Task<bool> PostProductInventory(String productBvin, int newQuantity);
    }
}
