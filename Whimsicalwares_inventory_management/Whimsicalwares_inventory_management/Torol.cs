using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whimsicalwares_inventory_management
{
    public class Torol
    {
        public NumericUpDown numericUpDown1;
        public DataGridView dataGridView1;
        public Form formtorol;
        public DialogResult result;
        public void torol()
        {
            int quantityToRemove = (int)numericUpDown1.Value;
            if (dataGridView1.CurrentRow != null && numericUpDown1.Value > 0)
            {

                if (result != DialogResult.Yes)
                {
                    result = MessageBox.Show("Biztosan törölni akarsz?", "Törlés megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    // A felhasználó kiválasztotta a "Yes" gombot, folytatjuk a törlést

                    DataGridViewRow currentRow = dataGridView1.CurrentRow;
                    if (currentRow.Cells["Quantity"].Value != null && int.TryParse(currentRow.Cells["Quantity"].Value.ToString(), out int currentQuantity))
                    {
                        if (currentQuantity - quantityToRemove < 0)
                        {
                            MessageBox.Show("A termékkészletet nem lehet NEGATÍVBA csökkenteni");
                        }
                        else
                        {
                            int newQuantity = currentQuantity - quantityToRemove;
                            currentRow.Cells["Quantity"].Value = newQuantity;
                            currentRow.Cells["Bvin"].Value.ToString();
                            Progress progress = new Progress();
                            progress.formprog = formtorol;
                            progress.progress();
                        }
                    }
                }
            }
            else
            {
                // A felhasználó kiválasztotta a "No" gombot, nem töröljük az adatokat
                return;
            }
            
        }
    }
}
