using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Threading;

namespace GR3_UiF
{
    public partial class Minireproductor : MaterialSkin.Controls.MaterialForm
    {
      
        public string ip;
        public TcpClient cliente;
        public bool detenedor = true;
        public List<string> listalinks = new List<string>();
        string linksiguiente = "";
        string linkanterior = "";
        public List<string> listatotal = new List<string>();
        Form1 instancia = (Form1) Application.OpenForms["Form1"];

        string temporal1 = "";
        string temporal2 = "";
        string temporal3 = "";
        public Minireproductor()
        {
            InitializeComponent();
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {

            GR3_UiF.Properties.Settings.Default.volumenmini = metroTrackBar2.Value;
            GR3_UiF.Properties.Settings.Default.posicionmini = metroTrackBar1.Value;
            GR3_UiF.Properties.Settings.Default.controlmini = true;
            GR3_UiF.Properties.Settings.Default.Save();
        }

        private void Minireproductor_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            if (GR3_UiF.Properties.Settings.Default.estatus == "reprod")
            {

             

            }
            else
               if (GR3_UiF.Properties.Settings.Default.estatus == "no")
            {
                
             
            }
            panel1.BackColor = GR3_UiF.Properties.Settings.Default.color_barra;
            cliente = new TcpClient();

            cliente.Client.Connect(ip, 1024);
            Thread proc = new Thread(new ThreadStart(oir));
            proc.Start();

        }
        public void oir()
        {
            try
            {
                while (cliente.Client.Connected == true && detenedor == true)
                {
                    cliente.Client.Send(Encoding.Default.GetBytes("recall()"));
                    var stream = cliente.GetStream();
                    Byte[] bites = new byte[120000];
                    int o;

                    while ((o = stream.Read(bites, 0, bites.Length)) != 0 && detenedor == true)
                    {

                        string capturado = Encoding.Default.GetString(bites, 0, o);
                        string[] partesillas = capturado.Split(';');
                        if (capturado != " " && partesillas[0].Trim() == "caratula()><")
                        {
                            capturado = "";


                            var zelda = partesillas[4];
                            linkLabel1.Text = partesillas[4];
                            metroLabel1.Text = "      " + partesillas[2];
                            temporal3 = "      " + partesillas[2];

                            this.listalinks = instancia.laparalink;
                            this.listatotal = instancia.lapara;
                            pictureBox1.ImageLocation = partesillas[1];

                            ///////////////////////ponerelementolinks
                            try
                            {
                                linkanterior = listalinks[GR3_UiF.Properties.Settings.Default.locanterior - 1];
                                pictureBox8.ImageLocation = @"https://i.ytimg.com/vi/" + linkanterior.Split('=')[1] + "/hqdefault.jpg";
                                linkLabel2.Text = linkanterior;
                            }
                            catch (Exception)
                            {
                                linkLabel2.Text = "";
                                metroLabel5.Text = "";
                                pictureBox8.ImageLocation = "";

                            }
                            try
                            {

                                linksiguiente = listalinks[GR3_UiF.Properties.Settings.Default.locanterior + 1];
                                pictureBox9.ImageLocation = @"https://i.ytimg.com/vi/" + linksiguiente.Split('=')[1] + "/hqdefault.jpg";

                                linkLabel3.Text = linksiguiente;

                            }
                            catch (Exception)
                            {
                                linkLabel3.Text = "";
                                metroLabel6.Text = "";
                                pictureBox9.ImageLocation = "";

                            }
                            ///////////////////////////ponerlementonombre
                            try {
                                metroLabel5.Text = "      " + listatotal[GR3_UiF.Properties.Settings.Default.locanterior - 1];
                                temporal1 = "      " + metroLabel5.Text;

                            }
                            catch (Exception)
                             {
                             metroLabel5.Text = "";
                             temporal1 = "";

                             }
                             try
                            {

                            metroLabel6.Text = "      " + listatotal[GR3_UiF.Properties.Settings.Default.locanterior + 1];
                            temporal2 = "      " + metroLabel6.Text;
                                }
                                catch (Exception)
                           {

                           metroLabel6.Text = "";
                           temporal2 = "";
                           }



                            listBox1.DataSource = instancia.lapara;
                            listBox1.SelectedIndex = GR3_UiF.Properties.Settings.Default.locanterior;
                        }
                    }
                }
            }
            catch (Exception)
            {
               
            }
      }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.estatus == "reprod")
            {
                cliente.Client.Send(Encoding.Default.GetBytes("pause()"));
              
              

            }
            else
                if (GR3_UiF.Properties.Settings.Default.estatus == "no")
            {
                cliente.Client.Send(Encoding.Default.GetBytes("play()"));
            
            }
         

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            cliente.Client.Send(Encoding.Default.GetBytes("next()"));

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cliente.Client.Send(Encoding.Default.GetBytes("back()"));
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Downloader2 descargador = new Downloader2();
            descargador.Location = this.Location;
            descargador.link = linkLabel1.Text;
            descargador.titulo = metroLabel1.Text;
            descargador.imgurl = pictureBox1.ImageLocation;
            descargador.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.Navegadorn == false)
            {
                Customwebbrowser navegador = new Customwebbrowser();
                navegador.Location = this.Location;
                navegador.Show();
            }
            else
            {
                Webbrowser nav = new Webbrowser();
                nav.Location = this.Location;
                nav.Show();
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try { 
           
            metroLabel2.Text = GR3_UiF.Properties.Settings.Default.durationstring;
            metroTrackBar1.Maximum= GR3_UiF.Properties.Settings.Default.duracion;
            metroTrackBar1.Value =GR3_UiF.Properties.Settings.Default.posicion;
            metroTrackBar2.Value = GR3_UiF.Properties.Settings.Default.volumen;
             if (GR3_UiF.Properties.Settings.Default.estatus == "reprod")
            {

                    pictureBox2.Image = GR3_UiF.Properties.Resources.circular_pause_button;

            }
            else
              if (GR3_UiF.Properties.Settings.Default.estatus == "no")
            {
                    pictureBox2.Image = GR3_UiF.Properties.Resources.play_arrow_triangle_in_circular_button_outline;
              
            }

            }catch(Exception) { }

        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            GR3_UiF.Properties.Settings.Default.volumenmini = metroTrackBar2.Value;
            GR3_UiF.Properties.Settings.Default.posicionmini = metroTrackBar1.Value;
            GR3_UiF.Properties.Settings.Default.controlmini = true;
            GR3_UiF.Properties.Settings.Default.cambiovolumenmini = true;
            GR3_UiF.Properties.Settings.Default.Save();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
          
            this.Close();
          
        }

        private void Minireproductor_FormClosing(object sender, FormClosingEventArgs e)
        {
            detenedor = false;
            GR3_UiF.Properties.Settings.Default.miniplayeron = false;
            GR3_UiF.Properties.Settings.Default.Save();
            cliente.Client.Disconnect(false);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
         
            StringBuilder sb1 = new StringBuilder(metroLabel5.Text);
            StringBuilder sb2 = new StringBuilder(metroLabel6.Text);
            StringBuilder sb3 = new StringBuilder(metroLabel1.Text);
            try {
            if (temporal1.Length >= 45)
            {
                char ch = metroLabel5.Text.ToCharArray()[0];
                sb1.Remove(0, 1);
                sb1.Insert(sb1.Length, ch);
                metroLabel5.Text = sb1.ToString();
            }
                else
                {
                    if (temporal1.Length > 1)
                    {
                        metroLabel5.Text = temporal1;
                    }
                }

            }
            catch (Exception)
            {
                metroLabel5.Text = temporal1;
            }

            try { 
            if (temporal2.Length >= 45)
            {
                char ch2 = metroLabel6.Text.ToCharArray()[0];
                sb2.Remove(0, 1);           
                sb2.Insert(sb2.Length, ch2);
                metroLabel6.Text = sb2.ToString();
            }
            else
            {
                if (temporal2.Length > 1)
                {
                    metroLabel6.Text = temporal2;
                }
            }
            }
            catch (Exception)
            {
                metroLabel6.Text = temporal2;
            }
            try
            {

        
            if (temporal3.Length >= 45)
            {
                char ch = metroLabel1.Text.ToCharArray()[0];
                sb3.Remove(0, 1);
                sb3.Insert(sb3.Length, ch);
                metroLabel1.Text = sb3.ToString();
            }
            else
            {
                if (temporal3.Length > 1)
                {
                    metroLabel1.Text = temporal3;
                }
            }

            }
            catch (Exception)
            {
                metroLabel1.Text = temporal3;
            }

      

    }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Load_playlist lplaylist = new Load_playlist();
            lplaylist.localizacion = this.Location;
            lplaylist.Show();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            dialogoeliminar dleliminar = new dialogoeliminar();
            dleliminar.Location = this.Location;
            dleliminar.url = listalinks[listatotal.IndexOf(listBox1.Text)];
            dleliminar.titulo=listatotal[listatotal.IndexOf(listBox1.Text)];
            dleliminar.ipadres = ip;
            dleliminar.indice = listatotal.IndexOf(listBox1.Text);
            dleliminar.imagen = listalinks[listatotal.IndexOf(listBox1.Text)].Split('=')[1];
            listBox1.SelectedIndex = GR3_UiF.Properties.Settings.Default.locanterior;
            dleliminar.ShowDialog();

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(485, 639);
            this.MinimumSize = new Size(485, 639);
            this.Size = new Size(485, 639);


            pictureBox12.Visible = true;
            pictureBox11.Visible = false;



        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(485, 393);
            this.MinimumSize= new Size(485, 393);
            this.Size = new Size(485, 393);

            pictureBox12.Visible = false;
            pictureBox11.Visible = true;

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            formsincronizacion fs = new formsincronizacion();
            fs.Location = this.Location;
            fs.Show();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Configs c = new Configs();
            c.Location = this.Location;
            c.Show();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
