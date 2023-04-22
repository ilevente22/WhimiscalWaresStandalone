using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using Whimsicalwares_inventory_management.DTO.response;

namespace Whimsicalwares_inventory_management
{
    public partial class Form1 : Form
    {
        BindingSource bindingSource = new BindingSource();
        private static String BASE_URL = "http://20.234.113.211:8094//DesktopModules/Hotcakes/API/rest/v1/";
        public Form1()
        {
            InitializeComponent();
            LoadData();

        }
        public async void LoadData()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("products?key=1-af60ed8e-94ff-4da2-a167-8b716ab5629a");

            if (response.IsSuccessStatusCode)
            {
                string data = await response.Content.ReadAsStringAsync();
                //var  A= JsonConvert.DeserializeObject<UpdateHotelInfo>(data);
                // List<UpdateHotelInfo> a = response.Content.ReadAsAsync<List<UpdateHotelInfo>>().Result;
                var result = JsonConvert.DeserializeObject<ProductsResponseRootDto>(data);
                dataGridView1.DataSource = result.Content.Products;
            }
        }
    }
}
