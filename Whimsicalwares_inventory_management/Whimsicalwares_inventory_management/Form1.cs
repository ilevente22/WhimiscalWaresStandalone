﻿using System;
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
using Whimsicalwares_inventory_management.Interface;
using Whimsicalwares_inventory_management.Repository;
using Whimsicalwares_inventory_management.DTO.Response.ProductInventory;
using Whimsicalwares_inventory_management.BO;

namespace Whimsicalwares_inventory_management
{
    public partial class Form1 : Form
    {
        BindingSource bindingSource = new BindingSource();
        IWhimsicalShopClient ShopClient;
        public Form1(IWhimsicalShopClient shopClient)
        {
            this.ShopClient = shopClient;
            InitializeComponent();
            LoadData();
            
        }
        private void ColorRowsByQuantity(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Quantity"].Value != null && int.TryParse(row.Cells["Quantity"].Value.ToString(), out int quantity))
                {
                    if (quantity <= 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.Red;
                    }
                }
            }
        }
        private void ColorRowsByQuantityReset(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Quantity"].Value != null && int.TryParse(row.Cells["Quantity"].Value.ToString(), out int quantity))
                {
                    if (quantity <= 10)
                    {
                        row.DefaultCellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        public async void LoadData()
        {

            List<ProductDto> products = await ShopClient.GetProducts();
            List<InventoryItem> inventoryItems = await ShopClient.GetInventoryItems();

            List<ProductBo> productBos = (
            from p in products
            join i in inventoryItems on p.Bvin equals i.ProductBvin into gj
            from inv in gj.DefaultIfEmpty()
            select new ProductBo
            {
                Bvin = p.Bvin,
                ProductSKU = p.Sku,
                ProductName = p.ProductName,
                Quantity = inv.QuantityOnHand // null coalescing operator to handle null values
            }).ToList();

            dataGridView1.DataSource = productBos;
        }

        private async void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Quantity"].Index && e.ColumnIndex >= 0)
            {
                String newQuantityString = dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();
                String productId = dataGridView1.Rows[e.RowIndex].Cells["Bvin"].Value.ToString();

                ColorRowsByQuantity(dataGridView1);
                int newQuantity;

                Int32.TryParse(newQuantityString.Trim(),out newQuantity);
                await ShopClient.PostProductInventory(productId, newQuantity);
                dataGridView1.Refresh();
            }
        }

        private int clickCount = 0;
        private void button_LowQuantity_Click(object sender, EventArgs e)
        {
            clickCount++;
            if (clickCount == 1)
            {
                ColorRowsByQuantity(dataGridView1);
                dataGridView1.CurrentCell = null;
            }
            else if(clickCount == 2)
            {
                ColorRowsByQuantityReset(dataGridView1);
                clickCount = 0;
                dataGridView1.CurrentCell = null;
            }
            
        }
    }
}
