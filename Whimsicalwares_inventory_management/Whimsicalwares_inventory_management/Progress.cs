using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whimsicalwares_inventory_management
{
    public class Progress
    {
        public Form formprog;
        public async void progress()
        {
            ProgressBar progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Visible = false, // Elrejtjük az elején
            };
            progressBar.Size = new Size(200, 20); // állítsd be a progressbar méretét
            progressBar.Location = new Point(formprog.ClientSize.Width / 2 - progressBar.Width / 2, formprog.ClientSize.Height / 2 - progressBar.Height / 2); // középre pozicionálás
            formprog.Controls.Add(progressBar);
            foreach (Control control in formprog.Controls)
            {
                control.Visible = false;
            }
            progressBar.Visible = true;
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Value = i;
                await Task.Delay(5); // Várakozás 30 milliszekundumig
            }
            formprog.Controls.Remove(progressBar);
            foreach (Control control in formprog.Controls)
            {
                control.Visible = true;
            }

        }
    }
}
