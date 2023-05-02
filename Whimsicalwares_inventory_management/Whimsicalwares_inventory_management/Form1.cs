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
using System.Reflection.Emit;
using Whimsicalwares_inventory_management.DTO.Response.ProductInventory.Request;
using ProgressBar = System.Windows.Forms.ProgressBar;

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
        private void ColorCellsByQuantity(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Quantity"].Value != null && int.TryParse(row.Cells["Quantity"].Value.ToString(), out int quantity))
                {
                    if (quantity <= 10)
                    {
                        row.Cells["Quantity"].Style.BackColor = Color.Red;
                    }
                }
            }
        }
        private void ColorCellsByQuantityReset(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Quantity"].Value != null && int.TryParse(row.Cells["Quantity"].Value.ToString(), out int quantity))
                {
                    if (quantity <= 10)
                    {
                        row.Cells["Quantity"].Style.BackColor = Color.White;
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
                ColorCellsByQuantity(dataGridView1);
                dataGridView1.CurrentCell = null;
            }
            else if(clickCount == 2)
            {
                ColorCellsByQuantityReset(dataGridView1);
                clickCount = 0;
                dataGridView1.CurrentCell = null;
            }
            
        }

        private void DisplayProductInfo(DataGridView dgv)
        {
            if (dgv.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dgv.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgv.Rows[selectedRowIndex];
                string productName = selectedRow.Cells["ProductName"].Value.ToString();
                int quantity = Convert.ToInt32(selectedRow.Cells["Quantity"].Value);

                label1.Text = productName;
                label2.Text = quantity.ToString();
            }
        }
        
           
        private async void Progress()
        {
            ProgressBar progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Visible = false, // Elrejtjük az elején
            };
            progressBar.Size = new Size(200, 20); // állítsd be a progressbar méretét
            progressBar.Location = new Point(this.ClientSize.Width / 2 - progressBar.Width / 2, this.ClientSize.Height / 2 - progressBar.Height / 2); // középre pozicionálás
            this.Controls.Add(progressBar);
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
            }
            progressBar.Visible = true;
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Value = i;
                await Task.Delay(5); // Várakozás 30 milliszekundumig
            }
            this.Controls.Remove(progressBar);
            foreach (Control control in this.Controls)
            {
                control.Visible = true;
            }

        }

        private void button_Hozzaad_Click(object sender, EventArgs e)
        {
            
            int quantityToAdd = (int)numericUpDown1.Value;
            if (dataGridView1.CurrentRow != null && numericUpDown1.Value > 0)
            {
                DataGridViewRow currentRow = dataGridView1.CurrentRow;
                if (currentRow.Cells["Quantity"].Value != null && int.TryParse(currentRow.Cells["Quantity"].Value.ToString(), out int currentQuantity))
                {
                    int newQuantity = currentQuantity + quantityToAdd;
                    currentRow.Cells["Quantity"].Value = newQuantity;
                    currentRow.Cells["Bvin"].Value.ToString();
                    Progress();
                }
            }
            
        }

        private void button_Torol_Click(object sender, EventArgs e)
        {
            int quantityToAdd = (int)numericUpDown1.Value;
            if (dataGridView1.CurrentRow != null && numericUpDown1.Value > 0)
            {
                DataGridViewRow currentRow = dataGridView1.CurrentRow;
                if (currentRow.Cells["Quantity"].Value != null && int.TryParse(currentRow.Cells["Quantity"].Value.ToString(), out int currentQuantity))
                {
                    int newQuantity = currentQuantity - quantityToAdd;
                    currentRow.Cells["Quantity"].Value = newQuantity;
                    currentRow.Cells["Bvin"].Value.ToString();
                    Progress();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DisplayProductInfo(dataGridView1);
        }
        ProductDto product = new ProductDto(); // példány létrehozása
        string imageUrl = product.ImageFileSmall;

    }

}

