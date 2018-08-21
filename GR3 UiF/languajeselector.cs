using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace GR3_UiF
{
    public partial class languajeselector : MaterialSkin.Controls.MaterialForm
    {
        public string lenguaje = "";
        public languajeselector()
        {
            InitializeComponent();
        }

        private void metroLabel3_MouseEnter(object sender, EventArgs e)
        {
            metroLabel2.BorderStyle = BorderStyle.None;
            metroLabel3.BorderStyle = BorderStyle.FixedSingle;
            metroLabel1.Text = "Por favor seleccione un lenguaje";
        }

        private void metroLabel2_MouseEnter(object sender, EventArgs e)
        {
           metroLabel3.BorderStyle= BorderStyle.None;
            metroLabel2.BorderStyle = BorderStyle.FixedSingle;
            metroLabel1.Text = "Please select your language";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (lenguaje.Length > 0) { 
            GR3_UiF.Properties.Settings.Default.lenguaje = lenguaje;
            GR3_UiF.Properties.Settings.Default.Save();
            }else
            {
                GR3_UiF.Properties.Settings.Default.lenguaje = "eng";
                GR3_UiF.Properties.Settings.Default.Save();
            }

            this.ShowInTaskbar = false;
            this.Visible = false;
            this.Opacity = 0;
            string aa = "";
            var elarray = 0;
            aa = "";
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3"))
            {

           
            aa =File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
            }
            if (aa.Length > 20)
            {
                elarray = aa.Split('$').Length;
            }



          
                if (elarray > 1)
                {

                Selector_de_modo selec = new Selector_de_modo();
                selec.Show();
              
                }
                else
                {
               Form1 selec = new Form1 ();
                selec.Show();

            }
         

        }

        private void languajeselector_Load(object sender, EventArgs e)
        {

            this.Location = new Point(1, 1);
            if (GR3_UiF.Properties.Settings.Default.lenguaje != "")
            {

                this.ShowInTaskbar = false;
                this.Visible = false;
                this.Opacity = 0;
                Selector_de_modo selec = new Selector_de_modo();
                selec.Show();
            }
            else
            {
                if (File.Exists("Downloadlog.gr3a"))
                {
                    File.Delete("Downloadlog.gr3a");
                }
                if (Directory.Exists("portraits"))
                {

               
                foreach (var a in Directory.GetFiles(@"portraits/"))
                {
                    File.Delete(a);
                  
                }
                }else
                {
                    Directory.CreateDirectory("portraits");
                }

            }
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            metroLabel3.ForeColor = Color.Black;
            metroLabel2.ForeColor = Color.Green;
            lenguaje = "eng";
        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {
            metroLabel3.ForeColor = Color.Green;
            metroLabel3.ForeColor = Color.Black;
            lenguaje = "spa";
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
           pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void metroLabel2_MouseLeave(object sender, EventArgs e)
        {
            metroLabel2.BorderStyle = BorderStyle.None;
        }

        private void metroLabel3_MouseLeave(object sender, EventArgs e)
        {
            metroLabel3.BorderStyle = BorderStyle.None;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void languajeselector_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (lenguaje.Trim() == "")
            {
                GR3_UiF.Properties.Settings.Default.lenguaje = "spa";
                GR3_UiF.Properties.Settings.Default.Save();
            }else
            {
                GR3_UiF.Properties.Settings.Default.lenguaje = lenguaje;
                GR3_UiF.Properties.Settings.Default.Save();
            }

            
        }
    }
}
