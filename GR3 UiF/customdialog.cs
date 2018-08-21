using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using System.Threading;
using System.Net.Sockets;
using VideoLibrary;
namespace GR3_UiF
{
    public partial class customdialog : MaterialSkin.Controls.MaterialForm
    {
        public string titulo;
        public string url;
        public string imagen;
       
        public string musiquita;
      
        public bool encontroconcalidadactual = false;
        TcpClient cliente = new TcpClient();
        string statusinical = "";
        WMPLib.WindowsMediaPlayerClass musicaplayer = new WMPLib.WindowsMediaPlayerClass();
        public bool sepuede;


        public customdialog()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text.Trim());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (sepuede == true)
             {

                /*
                   cliente.Client.Send(Encoding.UTF8.GetBytes("agregar()"));
                   cliente.Client.Send(Encoding.UTF8.GetBytes(url)); */
                if (encontroconcalidadactual)
                {
                    GR3_UiF.Properties.Settings.Default.tubito = "agregar";
               GR3_UiF.Properties.Settings.Default.tubito2 =RemoveIllegalPathCharacters( titulo);
                GR3_UiF.Properties.Settings.Default.laparalink =url;
                GR3_UiF.Properties.Settings.Default.Save();
            this.Close();

                }
                else
                {
                   notificarerror("No se puede reproducir el video con la calidad actual");
                }
            }
        }
        public void notificarerror(string texto)
        {
            foreach (Control aa in panel1.Controls)
            {
                if (aa.Size == new Size(271, 60))
                {
                    this.Invoke((MethodInvoker)delegate {
                        panel1.Controls.Remove(aa);// runs on UI thread
                    });

                }
            }
            var prri = new MonoFlat.MonoFlat_NotificationBox();
          prri.Location = new Point(this.Width - 286, 65);
            prri.Size = new Size(271, 60);
            prri.Image = GR3_UiF.Properties.Resources.youtube_logo;
            prri.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
            prri.RoundCorners = true;
            prri.Anchor = AnchorStyles.Top;
            prri.Anchor = AnchorStyles.Right;
            try { 
            this.Invoke((MethodInvoker)delegate {
                panel1.Controls.Add(prri);// runs on UI thread
            });
            }
            catch (Exception)
            {

            }
            prri.BringToFront();
            prri.BringToFront();
            prri.BringToFront();
            prri.Text = texto;
        }
        public void notificarerrors(string texto)
        {
            foreach (Control aa in this.Controls)
            {
                if (aa.Size == new Size(271, 60))
                {
                    this.Controls.Remove(aa);
                }
            }
            var prri = new MonoFlat.MonoFlat_NotificationBox();
            prri.Location = new Point(this.Width - 286, 65);
            prri.Size = new Size(271, 60);
            prri.Image = GR3_UiF.Properties.Resources.youtube_logo;
            prri.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Success;
            prri.RoundCorners = true;
            prri.Anchor = AnchorStyles.Top;
            prri.Anchor = AnchorStyles.Right;
            try
            {
                this.Controls.Add(prri);
            }
            catch (Exception)
            {

            }
         
            prri.BringToFront();
            prri.BringToFront();
            prri.BringToFront();
            prri.Text = texto;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (sepuede == true)
             {
                /*
                cliente.Client.Send(Encoding.UTF8.GetBytes(url));
                */
                if (encontroconcalidadactual)
                {
                    GR3_UiF.Properties.Settings.Default.tubito = "reproducir";
                    GR3_UiF.Properties.Settings.Default.tubito2 = RemoveIllegalPathCharacters(titulo);
                    GR3_UiF.Properties.Settings.Default.laparalink = url;
                    GR3_UiF.Properties.Settings.Default.Save();
                    this.Close();

                }else
                {
                   notificarerror("No se puede reproducir el video con la calidad actual");
                }
               
            }
            else
            {
             notificarerror("Por favor espere que se cargue la informacion del video");
            }
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (pictureBox1.Image == pictureBox1.ErrorImage)
            {
                pictureBox1.ImageLocation = @"https://i.ytimg.com/vi/" + imagen.Trim() + "/mqdefault.jpg";
                pictureBox1.Refresh();
            }
        }

        private void customdialog_Load(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = @"https://i.ytimg.com/vi/" + imagen.Trim() + "/mqdefault.jpg";        
            linkLabel1.Text = url;
            musicaplayer.StatusChange += Musicaplayer_StatusChange;
            metroProgressSpinner1.Value = 0;
            metroProgressSpinner1.Visible = true;
            Thread tuparra = new Thread(new ThreadStart(busqueda));
            tuparra.Start();
            cliente.Connect("localhost", 1024);
           
            statusinical = GR3_UiF.Properties.Settings.Default.estatus;
            if (File.Exists("fablist.gr3lst"))
            {
                string[] a = new string[0];
                string[] nombres = new string[0];
                try
                {
                    a = File.ReadAllText("fablist.gr3lst").Split('$')[1].Split(';');
                    nombres = File.ReadAllText("fablist.gr3lst").Split('$')[0].Split(';');
                }
                catch (Exception)
                {

                }

                List<string> listica = new List<string>();
                List<string> listica2 = new List<string>();
                bool encontro = false;
                int i = 0;
                foreach (string al in a)
                {
                    if (al == linkLabel1.Text)
                    {

                        encontro = true;

                    }
                    else
                    {
                        listica.Add(al);
                        listica2.Add(nombres[i]);
                    }
                    i++;

                }
                if (encontro)
                {
                    pictureBox7.BackgroundImage = GR3_UiF.Properties.Resources.star__1_;



                }
                else
                {


                    pictureBox7.BackgroundImage = GR3_UiF.Properties.Resources.star;



                }

            }
            else
            {
                var a = File.CreateText("fablist.gr3lst");

                a.Close();
            }


        }

        private void Musicaplayer_StatusChange()
        {
            metroTrackBar1.Maximum = Convert.ToInt32(musicaplayer.currentMedia.duration);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
          
            metroTrackBar1.Value = Convert.ToInt32(musicaplayer.currentPosition);
            System.Text.StringBuilder sb = new System.Text.StringBuilder(RemoveIllegalPathCharacters(label1.Text));
            int total = sb.Length;
            if (total >= 35)
            {

                char ch = sb[0];
                sb.Remove(0, 1);
                sb.Insert(sb.Length, ch);
                label1.Text = sb.ToString();
                label1.Refresh();
            }
        }
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }
        public void busqueda()
        {

            try {

                string video2 = "";
                string title = "";
                string prrin = null;
                using (var videito = Client.For(YouTube.Default))
                {
                    var videoo = videito.GetAllVideosAsync(url.Trim());
                    var resultados = videoo.Result;
                    title = resultados.First().Title.Replace("- YouTube", "");

                    // video2 = resultados.First(info => info.Resolution == -1 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;

                    ///  video2 = resultados.First(info => info.Resolution == 240 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;

                    int calidad2 = GR3_UiF.Properties.Settings.Default.caldidad_defecto;
                    if (calidad2 == 0)
                    {
                        calidad2 = -1;
                    }
                    video2 = resultados.First(info => info.Resolution == -1 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                    prrin= resultados.First(info => info.Resolution ==calidad2  && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                }


               /// videoinfos = DownloadUrlResolver.GetDownloadUrls(url.Trim(), false);
               /// this.label3.Text = "Cargando audio" + 45 + "%";
                metroProgressSpinner1.Value = 45;
              
             ///   video = videoinfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 0);
     
                if (prrin != null)
                {
                    encontroconcalidadactual = true;
                }
                
              //  this.label3.Text = "Cargando audio" + 90 + "%";
                metroProgressSpinner1.Value = 90;              
                musicaplayer.autoStart = false;
                musicaplayer.URL =video2;
                this.label1.Text = title;
                titulo = title;
            //    this.label3.Text = "Cargando audio" + 100 + "%";
                metroProgressSpinner1.Value = 100;             
             //   label3.Visible = false;

            }
            catch (Exception)
            {
              
                    notificarerror("Error al abrir");// runs on UI thread
               

        }
            try { 
             this.Invoke((MethodInvoker)delegate {
            metroProgressSpinner1.Visible = false;
             });
            }
            catch (Exception)
            {

            }


                sepuede = true;
          
          
             
          




        }
      
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            this.Refresh();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (titulo.Trim().Length > 0 && sepuede) {
              
                if (musicaplayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                pictureBox4.Image = GR3_UiF.Properties.Resources.play_arrow_triangle_in_circular_button_outline;
                musicaplayer.controls.pause();
                    if (statusinical == "reprod")
                    {
                        cliente.Client.Send(Encoding.Default.GetBytes("play()"));
                    }
               

            }
            else
            {
                   
                    pictureBox4.Image = GR3_UiF.Properties.Resources.circular_pause_button;
                musicaplayer.controls.play();
                    cliente.Client.Send(Encoding.Default.GetBytes("pause()"));

                }
            }
            else
            {
               notificarerror("Por favor espere que cargue el audio para luego reproducirlo");
            }

        }

        private void customdialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.musicaplayer.controls.stop();
            if (statusinical == "reprod")
            {
                cliente.Client.Send(Encoding.Default.GetBytes("play()"));
            }
            musicaplayer.close();
            cliente.Client.Disconnect(false);
        }

        private void metroTrackBar1_Validated(object sender, EventArgs e)
        {
        
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            musicaplayer.controls.currentPosition= Convert.ToDouble(metroTrackBar1.Value);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            if (metroProgressSpinner1.Value == 100)
            {
                Downloader2 dl = new Downloader2();
                dl.link = linkLabel1.Text;
                dl.Location = this.Location;
                dl.titulo = titulo;
                dl.imgurl = @"https://i.ytimg.com/vi/" + imagen.Trim() + "/hqdefault.jpg";
                dl.modoenform = false;
                dl.TopMost = true;
                this.Close();
                dl.ShowDialog();
            }
            else
            {
              notificarerror("Por espere a que cargue la informacion del video");
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (metroProgressSpinner1.Value == 100 && sepuede)
            {
              
                    agregarelementoaplaylist aa = new agregarelementoaplaylist();
                    aa.nombreelemento = titulo;
                    aa.Location = this.Location;
                    aa.linkelemento = linkLabel1.Text;
                    this.Close();
                    aa.ShowDialog();
            
              
                 }
            else
            {
             notificarerror("Por espere a que cargue la informacion del video");
            }

        }

        private void customdialog_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (File.Exists("fablist.gr3lst"))
            {
                string[] a = new string[0];
                string[] nombres = new string[0];
                try
                {
                    a = File.ReadAllText("fablist.gr3lst").Split('$')[1].Split(';');
                    nombres = File.ReadAllText("fablist.gr3lst").Split('$')[0].Split(';');
                }
                catch (Exception)
                {

                }

                List<string> listica = new List<string>();
                List<string> listica2 = new List<string>();
                bool encontro = false;
                int i = 0;
                foreach (string al in a)
                {
                    if (al == linkLabel1.Text)
                    {

                        encontro = true;

                    }
                    else
                    {
                        listica.Add(al);
                        listica2.Add(nombres[i]);
                    }
                    i++;

                }

                if (encontro)
                {

                    pictureBox7.BackgroundImage = GR3_UiF.Properties.Resources.star;
                    File.Delete("fablist.gr3lst");
                    var aaa = File.CreateText("fablist.gr3lst");
                    string sting = "";
                    string sting2 = "";
                    foreach (string ass in listica)
                    {
                     
                        sting += ass.Replace('$', ' ') + ";";
                    }
                    foreach (string ass2 in listica2)
                    {
                       
                        sting2 += ass2.Replace('$', ' ') + ";";
                    }
                    if (sting.Trim().Length > 3 && sting.Trim().Length > 3)
                    {


                        sting = sting.Remove(sting.Length - 1, 1);
                        sting2 = sting2.Remove(sting2.Length - 1, 1);
                        aaa.Write(sting2 + "$" + sting);


                    }
                
                    aaa.Close();
                    notificarerrors("Eliminado de favoritos");

                }
                else
                {
                    if (label1.Text.Trim() != "")
                    {


                        pictureBox7.BackgroundImage = GR3_UiF.Properties.Resources.star__1_;
                        listica.Add(linkLabel1.Text);
                        listica2.Add(titulo);
                        File.Delete("fablist.gr3lst");
                        var aaa = File.CreateText("fablist.gr3lst");
                        string sting = "";
                        string sting2 = "";
                        foreach (string ass in listica)
                        {
                       
                            sting += ass.Replace('$', ' ') + ";";
                        }
                        foreach (string ass2 in listica2)
                        {
                           
                            sting2 += ass2.Replace('$', ' ') + ";";
                        }
                        if (sting.Trim().Length > 3 && sting.Trim().Length > 3)
                        {


                            sting = sting.Remove(sting.Length - 1, 1);
                            sting2 = sting2.Remove(sting2.Length - 1, 1);
                            aaa.Write(sting2 + "$" + sting);
                        }
                     
                        aaa.Close();
                        notificarerrors("Agregado a favoritos");
                    }
                    else
                    {
                       notificarerror("Por favor espere que cargue la informacion del video antes de agregar");
                    }
                }

            }
            else
            {
                var a = File.CreateText("fablist.gr3lst");

                a.Close();
            }
        }
    }
}


