using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Runtime;

using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace GR3_UiF
{
    public partial class Downloader : Form
    {
      
        public string link;
        public string imagen;
        public string titulo;
      
        public string direccion;
        public Thread proc;
        public Thread proc2;
        public int calidad;
        public bool nactivo = true;
        public bool descargado = false;
     





        public Downloader()
        {
            InitializeComponent();
        }

        private void Downloader_Load(object sender, EventArgs e)
        {
    
            if (GR3_UiF.Properties.Settings.Default.lugar_descarga=="")
            {
                direccion = Application.StartupPath+ @"\descargas";
            }
            else
            {
                direccion = GR3_UiF.Properties.Settings.Default.lugar_descarga;
            }
            this.label1.Text = titulo;
            this.linkLabel1.Text = link;
            
          this.pictureBox1.ImageLocation = imagen;
           proc2 = new Thread(new ThreadStart(buscar));
           proc2.Start();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          


        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
          

        }

        public void buscar()
        {
        
        }
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.panel1.Visible = false;
            this.Size = new Size(576, 283);
        }

        private void button2_Click(object sender, EventArgs e)
        {


         

}

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.panel2.Visible =false;
            this.panel1.Visible = true;
            this.Size = new Size(576, 283);

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        public void ponerimagen()
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ponerimagen();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

           


          
        }

        private void metroComboBox1_Validated(object sender, EventArgs e)
        {
      
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.metroComboBox1.Text == "144p")
            {
                calidad = 144;
            }
            if (this.metroComboBox1.Text == "240p")
            {
                calidad = 240;
            }
            if (this.metroComboBox1.Text == "360p")
            {
                calidad = 360;
            }
            if (this.metroComboBox1.Text == "480p")
            {
                calidad = 480;
            }
            if (this.metroComboBox1.Text == "720p")
            {
                calidad = 720;
            }
            if (this.metroComboBox1.Text == "1080p")
            {
                calidad = 1080;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.sendingdiscover == true)
            {
                GR3_UiF.Properties.Settings.Default.sendingdiscover = false;
                GR3_UiF.Properties.Settings.Default.Save();

                this.Close();
            }
        }
    }




}

   
  



