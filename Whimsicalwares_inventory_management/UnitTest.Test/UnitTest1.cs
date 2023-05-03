using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Whimsicalwares_inventory_management.BO;
using System.Windows.Forms;
using static Whimsicalwares_inventory_management.keszletNoveles;
using Whimsicalwares_inventory_management;
using NUnit.Framework;
namespace UnitTest.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [TestCase(5, 10)]
        [TestCase(6, 11)]

        public void TestHozzaad(int ertek, int expected)
        {
            //arrange
            DataGridViewRow termekMock = new DataGridViewRow();

            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.Name = "Quantity";
            termekMock.Cells.Add(quantityColumn.CellTemplate.Clone() as DataGridViewCell);
            termekMock.Cells["Quantity"].Value = 5;

            //act

            var termekMock2 = termekMock;
            keszletNoveles keszletnoveles = new keszletNoveles();
            keszletnoveles.KeszletNoveles(termekMock2, ertek);


            //assert
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected, termekMock2.Cells["Quantity"].Value); ;
        }
    }
}
