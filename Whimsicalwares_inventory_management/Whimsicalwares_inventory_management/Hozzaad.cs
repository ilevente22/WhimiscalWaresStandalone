using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whimsicalwares_inventory_management
{
    public class Hozzaad
    {
        public DataGridView dataGridView1;
        public NumericUpDown numericUpDown1;
        public Form formhozza;
        public DialogResult result;
        public void hozzaad()
        {
            int quantityToAdd = (int)numericUpDown1.Value;
            if (dataGridView1.CurrentRow != null && numericUpDown1.Value > 0)
            {

                if (result != DialogResult.Yes)
                {
                    result = MessageBox.Show("Biztosan hozzá akarsz adni termékeket?", "Hozzáadás megerősítése", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (result == DialogResult.Yes)
                {
                    // A felhasználó kiválasztotta a "Yes" gombot, folytatjuk a törlést
                    DataGridViewRow currentRow = dataGridView1.CurrentRow;
                    if (currentRow.Cells["Quantity"].Value != null && int.TryParse(currentRow.Cells["Quantity"].Value.ToString(), out int currentQuantity))
                    {
                        int newQuantity = currentQuantity + quantityToAdd;
                        if (newQuantity > 999)
                        {
                            MessageBox.Show("Maximum 999db lehet raktáron egy termékből. Nem adhatsz hozzá annyit, hogy átlépd ezt a határt.");
                            return;
                        }
                        else
                        {
                            currentRow.Cells["Quantity"].Value = newQuantity;
                            currentRow.Cells["Bvin"].Value.ToString();
                            Progress progress = new Progress();
                            progress.formprog = formhozza;
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
