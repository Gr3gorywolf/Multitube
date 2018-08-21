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
    public partial class Selector_de_modo : MaterialSkin.Controls.MaterialForm
    {
        public bool normalyy = false;
        public Selector_de_modo()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            normalyy = true;
            this.Visible = false;
         
            Form1 elform = new Form1();
            elform.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            normalyy = true;
            this.Visible = false;

            Formlistadescarga elform = new Formlistadescarga();
            elform.Show();
        }

        private void Selector_de_modo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!normalyy)
            {
                Environment.Exit(Environment.ExitCode);
            }
        
        }

        private void Selector_de_modo_Load(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                metroLabel1.Text = "Select the mode";
                metroLabel2.Text = "Online player";
                metroLabel3.Text = "Offline player";
            }
        }
    }
}
