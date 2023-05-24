using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Whimsicalwares_inventory_management;


namespace UnitTest1.Test
{
    internal class InventoryManagementTest
    {

        [Test,
         TestCase(5, true),
         TestCase(100, false)
            ]
        public void TestHozzaad(int bemenet, bool expectedResult)
        {

            // Arrange

            NumericUpDown numericUpDown1 = new NumericUpDown();
            DataGridView dataGridView1 = new DataGridView();

            numericUpDown1.Value = bemenet;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Bvin";
            dataGridView1.Columns[1].Name = "ProductSKU";
            dataGridView1.Columns[2].Name = "ProductName";
            dataGridView1.Columns[3].Name = "Quantity";
            dataGridView1.Rows.Add("qwer1234", "p000", "Test", 950);
            Form form1 = new Form();


            // Act

            Hozzaad hozzaad = new Hozzaad();
            hozzaad.dataGridView1 = dataGridView1;
            hozzaad.numericUpDown1 = numericUpDown1;
            hozzaad.formhozza = form1;
            hozzaad.result = DialogResult.Yes;
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            hozzaad.hozzaad();

            string value = dataGridView1.Rows[0].Cells[3].Value.ToString();


            var actualResult = int.Parse(value) == 950 + bemenet;

            // Assert

            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test,
             TestCase(2, true),
             TestCase(5, true),
             TestCase(100, false)
                ]
        public void TestTorol(int bemenet, bool expectedResult)
        {

            // Arrange

            NumericUpDown numericUpDown1 = new NumericUpDown();
            DataGridView dataGridView1 = new DataGridView();

            numericUpDown1.Value = bemenet;
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Bvin";
            dataGridView1.Columns[1].Name = "ProductSKU";
            dataGridView1.Columns[2].Name = "ProductName";
            dataGridView1.Columns[3].Name = "Quantity";
            dataGridView1.Rows.Add("qwer1234", "p000", "Test", 5);
            Form form1 = new Form();


            // Act

            Torol torol = new Torol();
            torol.dataGridView1 = dataGridView1;
            torol.numericUpDown1 = numericUpDown1;
            torol.formtorol = form1;
            torol.result = DialogResult.Yes;
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            torol.torol();

            string value = dataGridView1.Rows[0].Cells[3].Value.ToString();


            var actualResult = int.Parse(value) == 5 - bemenet;

            // Assert

            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
