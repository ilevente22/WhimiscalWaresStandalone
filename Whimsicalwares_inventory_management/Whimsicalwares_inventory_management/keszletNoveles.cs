using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whimsicalwares_inventory_management
{
    public class keszletNoveles
    {
        public void KeszletNoveles(DataGridViewRow kivalasztott, int quantityToAdd)
        {
            if (kivalasztott != null && quantityToAdd > 0)
            {
                DataGridViewRow currentRow = kivalasztott;
                if (currentRow.Cells["Quantity"].Value != null && int.TryParse(currentRow.Cells["Quantity"].Value.ToString(), out int currentQuantity))
                {
                    int newQuantity = currentQuantity + quantityToAdd;
                    currentRow.Cells["Quantity"].Value = newQuantity;
                    currentRow.Cells["Bvin"].Value.ToString();
                    //Progress();
                }
            }
        }
    }
}
