using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
namespace GR3_UiF
{

    public partial class Formlistadescarga : MaterialSkin.Controls.MaterialForm
    {
        public List<string> nombreses = new List<string>();
        public List<string> linkeses = new List<string>();
        public List<string> patheses = new List<string>();
        TcpClient cl;
        bool enbusqueda = true;
        List<ListViewItem> listaaa = new List<ListViewItem>();
        WMPLib.WindowsMediaPlayerClass reproductor = new WMPLib.WindowsMediaPlayerClass();
        public Formlistadescarga()
        {
            InitializeComponent();
        }

        private void Formlistadescarga_Load(object sender, EventArgs e)
        {
            try
            {


                cl = new TcpClient("localhost", 1024);
            }
            catch (Exception) { }

            this.abajo.Visible = false;
            this.arriba.Visible = false;
            Thread proc = new Thread(new ThreadStart(cargartodoafter));
            proc.IsBackground = true;
            proc.Start();



        }

        public void cargartodoafter()
        {
            nombreses.Clear();
            linkeses.Clear();
            patheses.Clear();
            var archiv = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+@"\downloadlog.gr3");
            if (archiv.Length>1)
            {
                string lector = archiv.Trim();
                if (lector.Length > 2)
                {
                    if (lector.Split('$').Length >= 1)
                    {
                        foreach (string aa in lector.Split('$'))
                         {
                        if (aa.Length > 1)
                          {
                              

                            
                        nombreses.Add( aa.Split('¤')[0]);
                        linkeses.Add( aa.Split('¤')[1]);
                        patheses.Add( aa.Split('¤')[2]);
                             

                            }
                        }
                      
                        //////depurify
                        for (int i = 0; i < nombreses.ToArray().Length; i++)
                        {
                            if(!File.Exists(patheses[i]))
                            {

                                nombreses.RemoveAt(i);
                                linkeses.RemoveAt(i);
                                patheses.RemoveAt(i);
                            }
                         
                           
                        }
                        for (int i = 0; i < nombreses.ToArray().Length; i++)
                        {
                            
                        }

                    }

               
                         this.Invoke((MethodInvoker)delegate
                         {
                             metroProgressSpinner1.Minimum = 0;
                             metroProgressSpinner1.Maximum = nombreses.Count;
                         });
                }


            }

        

            WebClient cli = new WebClient();
            int prro = 0;
            listView1.Items.Clear();
            imageList1.Images.Clear();
            foreach (string ee in linkeses)
            {

                try {

                    if (!Directory.Exists("portraits"))
                    {
                        Directory.CreateDirectory("portraits");
                    }
                    MemoryStream ms;
                    if (!File.Exists(@"portraits/" + ee.Split('=')[1] + ".jpg"))
                    {
                        byte[] biteimagen = cli.DownloadData("http://i.ytimg.com/vi/" + ee.Split('=')[1] + "/hqdefault.jpg");

                        var escrito = File.Create(@"portraits/" + ee.Split('=')[1] + ".jpg");
                        escrito.Write(biteimagen, 0, biteimagen.Length);
                        escrito.Close();
                        ms = new MemoryStream(biteimagen);
                    }
                    else
                    {
                        byte[] biteimagen = File.ReadAllBytes(@"portraits/" + ee.Split('=')[1] + ".jpg");
                        ms = new MemoryStream(biteimagen);
                    }




                    imageList1.Images.Add(new Bitmap(ms));
                    ms.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message+e.Data+ee);
                    imageList1.Images.Add(GR3_UiF.Properties.Resources.song_playlist__1_);
                }
                if (File.Exists(patheses[prro]))
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = nombreses[prro];
                    item.ImageIndex = prro;
                    item.SubItems.Add(linkeses[prro]);
                    listView1.Items.Add(item);
                    listaaa.Add(item);
                }
                prro++;
                metroProgressSpinner1.Value = prro;
            }
            if (metroProgressSpinner1.Value == metroProgressSpinner1.Maximum)
            {
                metroProgressSpinner1.Visible = false;
            }
            enbusqueda = false;
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {



        }

        private void Formlistadescarga_Click(object sender, EventArgs e)
        {

        }

        private void Formlistadescarga_FormClosing(object sender, FormClosingEventArgs e)
        {
  
           
        try{
            cl.Client.Disconnect(false);}
             catch (Exception) { Environment.Exit(Environment.ExitCode); }
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            try { 
            formseleccionarchivo fs = new formseleccionarchivo();

                if (File.Exists(@"portraits/" + linkeses[nombreses.IndexOf(listView1.SelectedItems[0].Text)].Split('=')[1] + ".jpg"))
                {
                    fs.imagen = new Bitmap(@"portraits/" + linkeses[nombreses.IndexOf(listView1.SelectedItems[0].Text)].Split('=')[1] + ".jpg");
                }
                else
                {
                    fs.imagen = new Bitmap(GR3_UiF.Properties.Resources.song_playlist__1_);
                }
         
            fs.titulo = nombreses[nombreses.IndexOf(listView1.SelectedItems[0].Text)];
                fs.Location = this.Location;
            DialogResult resultado = fs.ShowDialog();
            if (resultado == DialogResult.Yes)
            {
                    //  System.Diagnostics.Process.Start(patheses[nombreses.IndexOf(listView1.SelectedItems[0].Text)]);

                    Reprod.URL = patheses[nombreses.IndexOf(listView1.SelectedItems[0].Text)];
                    metroLabel2.Text = listView1.SelectedItems[0].Text;
                    pictureBox1.Image = imageList1.Images[nombreses.IndexOf(listView1.SelectedItems[0].Text)];

                    if (listView1.SelectedItems[0].Text.EndsWith(".mp4"))
                    {
                        this.abajo.Visible = false;
                        this.arriba.Visible = true;
                    }
                    else
                    {
                        this.abajo.Visible = false;
                        this.arriba.Visible = false;
                    }

                    reproductor.controls.pause();
                    this.metroTrackBar1.Visible = true;
                    this.pictureBox1.Visible = true;
                    this.pictureBox3.Visible = true;
                    this.pictureBox4.Visible = true;
                        this.play.Visible = false;
                        this.pause.Visible = true;
                   

                    if (GR3_UiF.Properties.Settings.Default.estatus == "reprod")
                {
                    cl.Client.Send(Encoding.Default.GetBytes("pause()"));
                }
            }
            else
              if (resultado == DialogResult.No)
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select," + patheses[nombreses.IndexOf(listView1.SelectedItems[0].Text)]);
            }
            else
            {

            }
            }
            catch (Exception)
            {

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (enbusqueda == false)
            {
               

                listView1.Items.Clear();
                foreach (var a in listaaa)
                {
                    if (a.Text.ToLower().Contains(textBox1.Text.ToLower()))
                    {
                        listView1.Items.Add(a);
                    }
                }
            }
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (this.Reprod.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                Reprod.Ctlcontrols.pause();
                this.play.Visible = true;
                this.pause.Visible =false;
            }


        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        
            try
            {
                if (Reprod.playState==WMPLib.WMPPlayState.wmppsStopped)
                {
                    Reprod.URL = patheses[nombreses.IndexOf(metroLabel2.Text) + 1];
                metroLabel2.Text = nombreses[nombreses.IndexOf(metroLabel2.Text) + 1];
                pictureBox1.Image = imageList1.Images[nombreses.IndexOf(metroLabel2.Text)];

                if (nombreses[nombreses.IndexOf(metroLabel2.Text)].EndsWith(".mp4"))
                {
                    Reprod.Location = new Point(1, 1);
                    this.Opacity = 95;
                    Reprod.Size = new Size(1, 1);
                    Reprod.Visible = false;
                    this.abajo.Visible = false;
                    this.arriba.Visible = true;
                    }
                    else
                    {
                        Reprod.Size = new Size(1, 1);
                        Reprod.Visible = false;
                        this.abajo.Visible = false;
                            this.arriba.Visible = false;
                        pictureBox2.Visible = true;
                        metroLabel1.Visible = true;
                    }


                this.metroTrackBar1.Visible = true;
                this.pictureBox1.Visible = true;
                this.pictureBox3.Visible = true;
                this.pictureBox4.Visible = true;
                this.play.Visible = false;
                this.pause.Visible = true;


                if (GR3_UiF.Properties.Settings.Default.estatus == "reprod")
                {
                    cl.Client.Send(Encoding.Default.GetBytes("pause()"));
                }

                }
            }
            catch (Exception)
            {
                this.play.Visible = true;
                this.pause.Visible = false;
            }


            try
            {


                metroTrackBar1.Maximum = (int)Reprod.currentMedia.duration;
                this.metroTrackBar1.Value = (int)Reprod.Ctlcontrols.currentPosition;
                this.metroLabel3.Text = Reprod.Ctlcontrols.currentPositionString;
            }
            catch (Exception) {
            }
        }

        private void play_Click(object sender, EventArgs e)
        {
            if (this.Reprod.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                Reprod.Ctlcontrols.play();
                this.pause.Visible = true;
                this.play.Visible = false;
            }
            else
             if (this.Reprod.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                Reprod.Ctlcontrols.play();
                this.pause.Visible = true;
                this.play.Visible = false;
            }
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Reprod.Ctlcontrols.currentPosition = (double)metroTrackBar1.Value;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Reprod.Visible = true;       
            this.Opacity = 100;
             Reprod.Location = new Point(0, 62);
             Reprod.Size = new Size(this.Width, this.Height - 133);
           // Reprod.Location = listView1.Location;
          //  Reprod.Size = new Size((int)(listView1.Width - (listView1.Width) / 2), listView1.Height);
            this.arriba.Visible = false;
            pictureBox2.Visible = false;
            metroLabel1.Visible = false;
            this.abajo.Visible = true;
        }

        private void abajo_Click(object sender, EventArgs e)
        {
              Reprod.Location = new Point(1, 1);
            this.Opacity = 95;
            Reprod.Size = new Size(1, 1);
            Reprod.Visible = false;
            pictureBox2.Visible = true;
            metroLabel1.Visible = true;
            this.arriba.Visible = true;
            this.abajo.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try { 

            Reprod.URL = patheses[nombreses.IndexOf(metroLabel2.Text)+1];
            metroLabel2.Text = nombreses[nombreses.IndexOf(metroLabel2.Text) + 1];
            pictureBox1.Image = imageList1.Images[nombreses.IndexOf(metroLabel2.Text) ];

            if (nombreses[nombreses.IndexOf(metroLabel2.Text) ].EndsWith(".mp4"))
            {
                    Reprod.Location = new Point(1, 1);
                    this.Opacity = 95;
                    Reprod.Size = new Size(1, 1);
                    Reprod.Visible = false;
                    this.abajo.Visible = false;
                this.arriba.Visible = true;
            }
            else
            {
                    Reprod.Location = new Point(1, 1);
                    this.Opacity = 95;
                    Reprod.Size = new Size(1, 1);
                    Reprod.Visible = false;
                    this.abajo.Visible = false;
                this.arriba.Visible = false;
                    pictureBox2.Visible = true;
                    metroLabel1.Visible = true;
                }

            reproductor.controls.pause();
            this.metroTrackBar1.Visible = true;
            this.pictureBox1.Visible = true;
            this.pictureBox3.Visible = true;
            this.pictureBox4.Visible = true;
            this.play.Visible = false;
            this.pause.Visible = true;


            if (GR3_UiF.Properties.Settings.Default.estatus == "reprod")
            {
                cl.Client.Send(Encoding.Default.GetBytes("pause()"));
            }
            }
            catch (Exception)
            {

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {

                Reprod.URL = patheses[nombreses.IndexOf(metroLabel2.Text) - 1];
                metroLabel2.Text = nombreses[nombreses.IndexOf(metroLabel2.Text) - 1];
                pictureBox1.Image = imageList1.Images[nombreses.IndexOf(metroLabel2.Text)];

                if (nombreses[nombreses.IndexOf(metroLabel2.Text) ].EndsWith(".mp4"))
                {
                    Reprod.Location = new Point(1, 1);
                    this.Opacity = 95;
                    Reprod.Size = new Size(1, 1);
                    Reprod.Visible = false;
                    this.abajo.Visible = false;
                    this.arriba.Visible = true;
                }
                else
                {
                    Reprod.Location = new Point(1, 1);
                    this.Opacity = 95;
                    Reprod.Size = new Size(1, 1);
                    Reprod.Visible = false;
                    this.abajo.Visible = false;
                    this.arriba.Visible = false;
                    pictureBox2.Visible = true;
                    metroLabel1.Visible = true;
                }

                reproductor.controls.pause();
                this.metroTrackBar1.Visible = true;
                this.pictureBox1.Visible = true;
                this.pictureBox3.Visible = true;
                this.pictureBox4.Visible = true;
                this.play.Visible = false;
                this.pause.Visible = true;


                if (GR3_UiF.Properties.Settings.Default.estatus == "reprod")
                {
                    cl.Client.Send(Encoding.Default.GetBytes("pause()"));
                }
            }
            catch (Exception)
            {

            }
        }

        private void Reprod_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {

            if (this.Reprod.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                this.play.Visible = true;
                this.pause.Visible = false;
            }

            if (this.Reprod.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                this.play.Visible = false;
                this.pause.Visible = true;
            }
            if (this.Reprod.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {
              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Thread proc = new Thread(new ThreadStart(agregartododesdecarpetadescarga));
            proc.Start();

        }
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
         string al= r.Replace(path, "");
          return Regex.Replace(al, "[^A-Za-z0-9 _]", "");
        }
        public void agregartododesdecarpetadescarga()
        {
            WebClient cliente = new WebClient();
            nombreses.Clear();
            patheses.Clear();
            linkeses.Clear();
            foreach (string a in Directory.GetFiles(GR3_UiF.Properties.Settings.Default.lugar_descarga))
            {
                nombreses.Add(Path.GetFileName(a));
                patheses.Add(a);
                linkeses.Add("https://www.youtube.com/watch?v=" + cliente.DownloadString("https://decapi.me/youtube/videoid?search=" +RemoveIllegalPathCharacters( Path.GetFileNameWithoutExtension(a)).Replace(' ','+')));

            }

            if (File.Exists("Downloadlog.gr3a"))
            {
                File.Delete("Downloadlog.gr3a");
                var aa = File.CreateText("Downloadlog.gr3a");
                aa.Write(string.Join("¤", nombreses.ToArray()) + "$" + string.Join("¤", linkeses.ToArray()) + "$" + string.Join("¤", patheses.ToArray()));
                aa.Close();
                cargartodoafter(); 
                }
        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {
            formsyncoffline sincro = new formsyncoffline();
            sincro.Show();
        }
    }
}
