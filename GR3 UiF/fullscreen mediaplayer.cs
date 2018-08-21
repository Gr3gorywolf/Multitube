using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;


namespace GR3_UiF
{
  
    public partial class fullscreen_mediaplayer : Form
    {
        public Size tamanoviejo = new Size();
        public Point locvieja = new  Point();
        public TcpClient cliente = new TcpClient();
        AxWMPLib.AxWindowsMediaPlayer ctr;
        Point locviejaa;
        public string ipadre = "";
        Form1 instancia = (Form1)Application.OpenForms["Form1"];
        public fullscreen_mediaplayer()
        {
            InitializeComponent();
        }

        private void fullscreen_mediaplayer_Load(object sender, EventArgs e)
        {
           
            Form1 instancia = (Form1)Application.OpenForms["Form1"];
            var pantalla = Screen.FromControl(instancia);
            locviejaa = instancia.Location;
            instancia.Location = Screen.AllScreens.First(a => a.DeviceName == pantalla.DeviceName).WorkingArea.Location;
            this.Location = Screen.AllScreens.First(a => a.DeviceName == pantalla.DeviceName).WorkingArea.Location;
            cliente.Client.Connect(ipadre, 1024);
           
            foreach (Control c in panel1.Controls)
            {
                panel1.Controls.Remove(c);
            }

            AxWMPLib.AxWindowsMediaPlayer ctr = instancia.gettearinstancia().axWindowsMediaPlayer1;
            tamanoviejo = ctr.Size;
            locvieja = ctr.Location;
            ctr.Size = panel1.Size;
            ctr.Location = new Point(0, 0);

            this.panel1.Controls.Add(ctr);
         //   this.Location = new Point(0, 0);
           this.Size = new Size(pantalla.Bounds.Width, pantalla.Bounds.Height);
       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try {

              
            if (this.metroTrackBar1.Maximum>= this.metroTrackBar1.Value)
            {
                this.metroTrackBar1.Maximum = instancia.macTrackBar1.Maximum;
                this.metroTrackBar1.Value = instancia.macTrackBar1.Value;



            }
                if (pictureBox5.ImageLocation != instancia.pictureBox1.ImageLocation)
                {
                    pictureBox5.ImageLocation = instancia.pictureBox1.ImageLocation;
                }
                 if(label1.Text!=instancia.igualador)
                {
                    label1.Text = instancia.igualador;
                }
                if (f.Text != instancia.label3.Text)
                {
                    f.Text = instancia.label3.Text;
                }
                }
            catch (Exception)
            {

            }



        }

        private void fullscreen_mediaplayer_FormClosing(object sender, FormClosingEventArgs e)
        {
          
            var newcontroller = panel1.Controls[0];
            newcontroller.Location = locvieja;
            newcontroller.Size = tamanoviejo;

            instancia.gettearinstancia().panel1.Controls.Add(newcontroller);
            instancia.enfullscreen = false;
            cliente.Client.Disconnect(false);
            instancia.Location = locviejaa;
            foreach (Control cs in instancia.gettearinstancia().panel1.Controls)
            {
                if (cs.Equals(newcontroller))
                {
                    cs.BringToFront();

                }
            }

        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            cliente.Client.Send(Encoding.UTF8.GetBytes("playpause()"));
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cliente.Client.Send(Encoding.UTF8.GetBytes("next()"));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            cliente.Client.Send(Encoding.UTF8.GetBytes("back()"));
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            instancia.axWindowsMediaPlayer1.Ctlcontrols.currentPosition = (double)metroTrackBar1.Value;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listBox1_Click(object sender, EventArgs e)
        {
         

          
        }
    }
}
