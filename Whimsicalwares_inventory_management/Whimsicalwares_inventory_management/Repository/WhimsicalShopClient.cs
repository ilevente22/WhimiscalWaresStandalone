using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whimsicalwares_inventory_management.DTO.response;
using Whimsicalwares_inventory_management.DTO.Response.ProductInventory;
using Whimsicalwares_inventory_management.DTO.Response.ProductInventory.Request;
using Whimsicalwares_inventory_management.Interface;

namespace Whimsicalwares_inventory_management.Repository
{
    public class WhimsicalShopClient : IWhimsicalShopClient
    {
        private HttpClient client;
        private static String BASE_URL = "http://20.234.113.211:8094//DesktopModules/Hotcakes/API/rest/v1/";

        public WhimsicalShopClient()
        {
            this.client = new HttpClient();
            this.client.BaseAddress = new Uri(BASE_URL);
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<ProductDto>> GetProducts()
        {
            HttpResponseMessage response = await this.client.GetAsync("products?key=1-af60ed8e-94ff-4da2-a167-8b716ab5629a");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductsResponseRootDto>(data);
                return result.Content.Products;
            }

            throw new Exception("Error ocurred while fetching products from Whimsical");
        }

        public async Task<List<InventoryItem>> GetInventoryItems()
        {
            HttpResponseMessage response = await this.client.GetAsync("productinventory?key=1-af60ed8e-94ff-4da2-a167-8b716ab5629a");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProductInventory>(data);
                return result.Content;
            }

            throw new Exception("Error ocurred while fetching products inventories from Whimsical");
        }

        public async Task<bool> PostProductInventory(String Bvin, int newQuantity)
        {
            CreateInventoryDto createInventoryDto = new CreateInventoryDto() 
            { 
                ProductBvin = Bvin,
                QuantityOnHand = newQuantity,
            };

            var requestBody = JsonConvert.SerializeObject(createInventoryDto);

            // Create the request content with JSON MIME type
            var requestContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await this.client.PostAsync("productinventory?key=1-af60ed8e-94ff-4da2-a167-8b716ab5629a", requestContent);

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();

                return true;
            }

            throw new Exception("Error ocurred while fetching products inventories from Whimsical");
        }
    }
}
