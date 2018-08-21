using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GR3_UiF
{
    public partial class Daemon : Form
    {
        public string daemond = GR3_UiF.Properties.Settings.Default.daemond;
        public List<string> nombreses = new List<string>();
        public Daemon()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if(this.BackColor!= GR3_UiF.Properties.Settings.Default.color_barra)
            {
                this.BackColor = GR3_UiF.Properties.Settings.Default.color_barra;
            }
            if (daemond != GR3_UiF.Properties.Settings.Default.daemond)
            {
                daemond =  GR3_UiF.Properties.Settings.Default.daemond;

              
                
                    GR3_UiF.Properties.Settings.Default.daemonr = "No";
                    GR3_UiF.Properties.Settings.Default.Save();

                    nombreses.Add(daemond.Split('¤')[1] + daemond.Split('¤')[3]);
                    Fdescarga descar = new Fdescarga();
                descar.TopLevel = false;
                descar.BackColor= GR3_UiF.Properties.Settings.Default.color_barra;
                descar.imagen = daemond.Split('¤')[0];
                descar.link= daemond.Split('¤')[1];
                descar.nombre= daemond.Split('¤')[2];
                descar.calidad =int.Parse( daemond.Split('¤')[3]);
                descar.vidomp3 = daemond.Split('¤')[4];
                flowLayoutPanel1.Controls.Add(descar);
                descar.Show();
              

                daemond = "";
                GR3_UiF.Properties.Settings.Default.daemond = "";
                GR3_UiF.Properties.Settings.Default.Save();
                this.Visible = true;
                this.Opacity = 90;
             
            }
            else
                if (GR3_UiF.Properties.Settings.Default.daemoninvoke == true)
            {
                GR3_UiF.Properties.Settings.Default.daemoninvoke = false;
                GR3_UiF.Properties.Settings.Default.Save();
                this.Visible = true;
                this.Opacity = 90;
            }

        }

        private void Daemon_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Size = new Size(65, Screen.PrimaryScreen.WorkingArea.Height);
            this.Location = new Point(0, 0);
            this.Opacity = 0;
            this.BackColor = GR3_UiF.Properties.Settings.Default.color_barra;
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Visible = false;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
