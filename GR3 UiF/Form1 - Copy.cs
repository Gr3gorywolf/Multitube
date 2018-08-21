using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Speech.Synthesis;
using System.Threading;
using System.IO;

using System.Text.RegularExpressions;
using prueba_de_lista_generica;
using System.Threading.Tasks;
using YoutubeSearch;
using ZXing;
using VideoLibrary;
using MaterialSkin;
namespace GR3_UiF
{
    public partial class Form1copy : MaterialSkin.Controls.MaterialForm
    {
        claseanimaciones canim = new claseanimaciones();
        public bool enproceso = false;
        public string lenguaje = "";
        WebClient clientegue = new WebClient();
        public TcpClient cliente = new TcpClient();
        public bool lenguajeseteado = false;
        public SpeechSynthesizer tumalditamadre = new SpeechSynthesizer();
        public TcpListener oidor;
        public List<TcpClient> clientes= new List<TcpClient>();
        public Thread proceso;
        public bool activado;
        public bool detenedor = true;
        string capturado = "";
        public string zelda = "";
        public string zeldamobile = "";
       
        public string tubito = "";
        public string tubito2 = "";
        public int quality;
        public string imgloc="";
        public string connectionstatusicon = "";
        public List<string> lapara = new List<string>();
        public List<string> laparalink = new List<string>();
        public List<string> listretroceso = new List<string>();
        public string igualador;
        public Int32 locanterior=0;
        public string anterior;
        public bool enfullscreen;
        public string backup;
        public string lista = "";
        public string ipadre;
        public bool pideindex;
        public int indexdelalista;
        public bool entro = false;
        public string anumasisierto = "";
        public TcpClient cliente2;
        public string lista2 = "";
        public ToolTip tt = new ToolTip();
        public ToolTip ttp7 = new ToolTip();
        public ToolTip ttp4 = new ToolTip();
        public ToolTip tt12 = new ToolTip();
        public ToolTip tt19 = new ToolTip();
        public ToolTip tt18 = new ToolTip();
        public ToolTip tt17 = new ToolTip();
        public ToolTip tt16 = new ToolTip();
        public ToolTip tt32 = new ToolTip();
        public ToolTip tt15 = new ToolTip();
        public ToolTip tt9 = new ToolTip();
        public ToolTip tt10 = new ToolTip();
        public ToolTip tt2 = new ToolTip();
        public ToolTip tt11 = new ToolTip();
        public ToolTip tt5 = new ToolTip();
        public ToolTip tt3 = new ToolTip();
        public ToolTip tt6 = new ToolTip();
        public ToolTip tt8 = new ToolTip();
        public ToolTip tt21 = new ToolTip();
        public ToolTip tt22 = new ToolTip();
        public ToolTip tt23 = new ToolTip();
        public ToolTip tt20 = new ToolTip();
        public ToolTip tt33 = new ToolTip();
        public ToolTip tt34 = new ToolTip();
        public   ToolTip tt7 = new ToolTip();
        public ToolTip tt35= new ToolTip();
       
        public Form1copy()
        {
            InitializeComponent();
          
        }

        public void notificarerror(string texto)
        {
           foreach(Control aa in panel1.Controls)
            {
                if (aa.Size==new Size(271, 60))
                {
                    this.Invoke((MethodInvoker)delegate {
                        panel1.Controls.Remove(aa);// runs on UI thread
                    });
                   
                }
            }
            var prri = new MonoFlat.MonoFlat_NotificationBox();
            prri.Location= new Point(panel2.Size.Width-286, 105);
            prri.Size=new Size(271, 60);
            prri.Image = GR3_UiF.Properties.Resources.youtube_logo;
            prri.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
            prri.RoundCorners = true;
            prri.Anchor = AnchorStyles.Top;
            prri.Anchor = AnchorStyles.Right;
            this.Invoke((MethodInvoker)delegate {
                panel1.Controls.Add(prri);// runs on UI thread
            });
           
           prri.BringToFront();
            prri.BringToFront();
            prri.BringToFront();
            prri.Text = texto;     
        }
        private Bitmap GetQRCode()
        {
         
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 600,
                    Width = 600
                }
            };
            return writer.Write(ipadre);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                WebClient clientew = new WebClient();
             
                string numerover = clientew.DownloadString("http://gr3uifppage.droppages.com/");
           
                if (!numerover.Contains("9"))
                {
                  
                    notificacionactualizacion aa = new notificacionactualizacion();
                    aa.linkdescarga = numerover.Split('¤')[1];
                    aa.Show();
                }
            }
            catch (Exception)
            {

            }
      

            Daemon dae = new Daemon();
            dae.Visible = false;
            dae.Show();

            if (GR3_UiF.Properties.Settings.Default.lugar_descarga.Trim() == "")
            {
                GR3_UiF.Properties.Settings.Default.lugar_descarga =Application.StartupPath+ @"\descargas";
                GR3_UiF.Properties.Settings.Default.Save();
            }
            if (!File.Exists("Downloadlog.gr3a"))
            {

     
            var aa = File.CreateText("Downloadlog.gr3a");
            aa.Close();
            }
            else
            {

            }
            if (!Directory.Exists(@"descargas"))
            {
                Directory.CreateDirectory(@"descargas");
            }
            if (!Directory.Exists(@"Saved_playlist"))
            {
                Directory.CreateDirectory(@"Saved_playlist");
            }
            if (!Directory.Exists(@"portraits"))
            {
                Directory.CreateDirectory(@"portraits");
            }

            GR3_UiF.Properties.Settings.Default.miniplayeron = false;
            axWindowsMediaPlayer1.Controls.Clear();
          label1.Font = new Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            metroProgressSpinner1.ForeColor= panel2.BackColor;

          //  languajeselector selectol = new languajeselector();
          //  selectol.ShowDialog();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
          //  morphingnorm();
            if (GR3_UiF.Properties.Settings.Default.sobre == true)
            {
                this.TopMost = true;
      
            }
        

            oidor = new TcpListener(IPAddress.Any,1024);
            oidor.Start();
            proceso = new Thread(new ThreadStart(oir));
            proceso.IsBackground = true;
            proceso.Start();
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach(IPAddress ip in localIPs)
            {
                if(ip.AddressFamily== System.Net.Sockets.AddressFamily.InterNetwork)
                {

                    ipadre = ip.ToString();

                 
                }
             
            
            }
         
            this.pictureBox31.Image = GetQRCode();
            this.pictureBox4.BackColor = GR3_UiF.Properties.Settings.Default.colorm;          
            this.panel2.BackColor = GR3_UiF.Properties.Settings.Default.colorm;
            this.panel3.BackColor = GR3_UiF.Properties.Settings.Default.color_barra;
            pictureBox1.BackColor = GR3_UiF.Properties.Settings.Default.colorm;


            tubito = GR3_UiF.Properties.Settings.Default.tubito;
            axWindowsMediaPlayer1.settings.volume = 100;
            macTrackBar2.Value = axWindowsMediaPlayer1.settings.volume;
            cliente.Close();
      
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa") {
                lenguaje = "esp";
                metroLabel2.Text = "Personalizacion de interfaz";
                metroLabel3.Text = "Descargar";
                metroLabel4.Text = "Descargas realizadas";
                metroLabel5.Text = "Navegador";
                metroLabel6.Text = "Conectar cliente";
                metroLabel7.Text = "mini reproductor";
                metroLabel8.Text = "Sincronizar listas de reproduccion";
                metroLabel9.Text = "Configuracion";
                metroLabel1.Text = "Cerrar menu";
                tt35.SetToolTip(pictureBox35,"Lista de descargas realizadas");
            tt7.SetToolTip(pictureBox7, "Configuraciones");
            tt20.SetToolTip(pictureBox20, "Abrir menú de conexion con cliente(app)");
            tt8.SetToolTip(pictureBox8, "Abrir navegador personalizado");
            tt6.SetToolTip(pictureBox6, "Menú de descargas");
            tt3.SetToolTip(pictureBox3, "Personalizacion de la interfaz");
            tt5.SetToolTip(pictureBox5, "Cerrar Menú desplegable");
            tt11.SetToolTip(pictureBox11, "Abrir menú de reproducción");
        
            ttp4.SetToolTip(panel4, "Busqueda rapida");
            tt12.SetToolTip(pictureBox12, "Cerrar menú de reproducción");
        
            tt18.SetToolTip(pictureBox18, "Repetir la lista");
            tt17.SetToolTip(pictureBox17, "Repetir elemento actual");
            tt16.SetToolTip(pictureBox16, "Elemento anterior");
            tt15.SetToolTip(pictureBox15, "Elemento siguiente");
            tt9.SetToolTip(pictureBox9, "Pausar");
            tt10.SetToolTip(pictureBox10, "Reproducir");
                this.label5.Text = "Lista actual";
                tt34.SetToolTip(pictureBox34, "Recargar elemento actual");
            tt2.SetToolTip(pictureBox2,"Abrir menú desplegable");
                tt21.SetToolTip(pictureBox21, "Reproducir lista de reproducción creada");
              
                tt32.SetToolTip(pictureBox32, "Modo mini");

                tt33.SetToolTip(pictureBox33, "Menu de sincronizacion");
            }
            else
                     if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                lenguaje = "eng";
                tt35.SetToolTip(pictureBox35, "List of completed downloads");
                tt7.SetToolTip(pictureBox7, "Setting");
                tt20.SetToolTip(pictureBox20, "Open client(app)connection menu");
                tt8.SetToolTip(pictureBox8, "Open custom web browser");
                tt6.SetToolTip(pictureBox6, "Download menu");
                tt3.SetToolTip(pictureBox3, "Customize the interface");
                tt5.SetToolTip(pictureBox5, "Close side menu");
                tt11.SetToolTip(pictureBox11, "Open play menu");            
                ttp4.SetToolTip(panel4, "Fast search");
                tt12.SetToolTip(pictureBox12, "Close play menu");
              
                tt18.SetToolTip(pictureBox18, "Repeat the playlist");
                tt17.SetToolTip(pictureBox17, "Repeat actual media");
                tt16.SetToolTip(pictureBox16, "Back");
                tt15.SetToolTip(pictureBox15, "Next");
                tt9.SetToolTip(pictureBox9, "Pause");
                tt10.SetToolTip(pictureBox10, "Play");
                tt2.SetToolTip(pictureBox2, "Open side menu");
                this.label5.Text = "Current playlist";
                tt34.SetToolTip(pictureBox34, "Reload actual element");
                tt21.SetToolTip(pictureBox21, "Play created playlist");
              
                tt32.SetToolTip(pictureBox32, "Mini mode");
                tt33.SetToolTip(pictureBox33, "Sync menu");

                metroLabel2.Text = "User interface customization";
                metroLabel3.Text = "Download";
                metroLabel4.Text = "Realized downloads";
                metroLabel5.Text = "Custom web browser";
                metroLabel6.Text = "Connect client";
                metroLabel7.Text = "Mini player";
                metroLabel8.Text = "Sync playlist";
                metroLabel9.Text = "Settings";
                metroLabel1.Text = "Close menu";
            }
         
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            
           

        }
 
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
          
            enproceso = true;
            metroProgressSpinner1.Value = 0;
            metroProgressSpinner1.Visible = true;
            string ladvd = clientegue.DownloadString(webBrowser1.Url);
           
            //https://www.youtube.com/tv#/watch?v= youtube tv

            zelda = "https://www.youtube.com/watch?v=" + ladvd;
            metroProgressSpinner1.Value = metroProgressSpinner1.Value + 20;

            limpiarui();
            this.linkLabel1.Text = "https://www.youtube.com/watch?v=" + ladvd;
          
            pictureBox1.ImageLocation = @"https://i.ytimg.com/vi/" + ladvd + "/hqdefault.jpg";
            if (GR3_UiF.Properties.Settings.Default.color_marcoon == false) {
            pictureBox4.ImageLocation = @"https://i.ytimg.com/vi/" + ladvd + "/hqdefault.jpg";
                metroProgressSpinner1.Value = metroProgressSpinner1.Value + 20;
              
            }
            else
                   if (GR3_UiF.Properties.Settings.Default.color_marcoon == true)
            {
                pictureBox4.ImageLocation = "";
                pictureBox4.BackColor = GR3_UiF.Properties.Settings.Default.color_marco;
            }

            Thread proc = new Thread(new ThreadStart(buscar));
            proc.Start();

            imgloc = ladvd;

            if (GR3_UiF.Properties.Settings.Default.caldidad_defecto == 0)
            {
                axWindowsMediaPlayer1.Visible = false;
               
             }
            else
            {
                axWindowsMediaPlayer1.Visible = true;
              
            }
             //macTrackBar1.Maximum =Convert.ToInt32(   axWindowsMediaPlayer1.currentMedia.duration);
         
            metroProgressSpinner1.Value = metroProgressSpinner1.Value + 20;
       
        }  
        
        public void reproducir(string zelda2)
        {
            enproceso = true;
            metroProgressSpinner1.Value = 0;
            metroProgressSpinner1.Visible = true;
            zelda = zelda2;
            string ladvd = zelda.Split('=')[1];
            metroProgressSpinner1.Value = metroProgressSpinner1.Value + 20;

            limpiarui();
            this.linkLabel1.Text = "https://www.youtube.com/watch?v=" + ladvd;

            pictureBox1.ImageLocation = @"https://i.ytimg.com/vi/" + ladvd + "/hqdefault.jpg";
            if (GR3_UiF.Properties.Settings.Default.color_marcoon == false)
            {
                pictureBox4.ImageLocation = @"https://i.ytimg.com/vi/" + ladvd + "/maxresdefault.jpg";
                metroProgressSpinner1.Value = metroProgressSpinner1.Value + 20;

            }
            else
                   if (GR3_UiF.Properties.Settings.Default.color_marcoon == true)
            {
                pictureBox4.ImageLocation = "";
                pictureBox4.BackColor = GR3_UiF.Properties.Settings.Default.color_marco;
            }

            Thread proc = new Thread(new ThreadStart(buscar));
            proc.Start();

            imgloc = ladvd;

            if (GR3_UiF.Properties.Settings.Default.caldidad_defecto == 0)
            {
                axWindowsMediaPlayer1.Visible = false;

            }
            else
            {
                axWindowsMediaPlayer1.Visible = true;

            }
            //macTrackBar1.Maximum =Convert.ToInt32(   axWindowsMediaPlayer1.currentMedia.duration);
           
            metroProgressSpinner1.Value = metroProgressSpinner1.Value + 20;
         
        }  
        private void webBrowser2_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
          
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {



            this.Close();
           


        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void oir()
        {
            while (detenedor==true)
             
                 {
                try
                {
                     cliente2 = oidor.AcceptTcpClient();
                    clientes.Add(cliente2);
                    cliente = cliente2;
                }
                catch (Exception) { };
         
            
                
               
             
       if (cliente2.Connected==true)
                 {
                 
                    proceso = new Thread(new ThreadStart(oir));
                    proceso.IsBackground = true;
                    proceso.Start();
                }



                var stream = cliente2.GetStream();
             
                byte[] bytes = new byte[120000];
              
                int o;
                bool agregado = false;
                bool pedirlista = false;
                bool eliminarelemento = false;
             
                try { 
                while  ((o=stream.Read(bytes,0,bytes.Length))!=0)
                    {
            
                  capturado= Encoding.ASCII.GetString(bytes, 0,o);
                      
                        activado = true;
                        if(capturado=="notificar()" && activado == true)
                        {
                            if (GR3_UiF.Properties.Settings.Default.Notificaciones )
                            {
                                this.Invoke((MethodInvoker)delegate {
                                    Notificacionconectado aa = new Notificacionconectado();
                                    aa.Show();
                                });
                              
                            }
                        }
                        else

                        if (capturado == "pedirlista()" && activado == true)
                        {
                            capturado = "";
                            activado = false;
                            pedirlista = true;
                        }
                        else
                           if (capturado == "eliminarelemento()" && activado == true)
                        {
                            capturado = "";
                            activado = false;
                            eliminarelemento = true;
           
                        }
                        else
                           if (eliminarelemento == true && activado == true)
                        {
                       
                            eliminarelemento = false;
                            activado = false;

                         
                            
                          
                            int indicedelmedio = lapara.IndexOf(">"+igualador+"<");
                         
                         
                            if (Convert.ToInt32(capturado) > indicedelmedio)
                            {

                            }
                            else

                            if (Convert.ToInt32(capturado) == indicedelmedio)
                            {
                                igualador = lapara[indicedelmedio-1];
                                anterior= lapara[indicedelmedio - 1];
                                locanterior--;
                                listBox1.SelectedIndex = indicedelmedio - 1;
                            }
                            else
                            if (Convert.ToInt32(capturado) < indicedelmedio)
                            {
                              
                                locanterior --;
                           
                            }

                            laparalink.RemoveAt(Convert.ToInt32(capturado));
                            lapara.RemoveAt(Convert.ToInt32(capturado));



                            listBox1.DataSource = null;
                            listBox1.DataSource = lapara;
                             listBox1.SelectedIndex= lapara.IndexOf(">" + igualador + "<");
                            actualizarlista();
                            capturado = "";






                        }
                        else


                        if (pedirlista==true && activado == true)
                        {
                            pedirlista = false;
                            activado = false;
                       
                            reproducirlalista(Convert.ToInt32(capturado.Trim()));
                         
                        }
                        else
                    if (capturado == "" && activado == true)
                    {
                        capturado = "";
                        activado = false;
                    }
                     
                    else
                   
if (capturado.Trim() == "close()" && activado == true)
                    {

                        capturado = "";
                        this.Close();
                    }
                    else
                    if (capturado.Trim() == "pedirindice()" && activado == true)
                    {
                        capturado = "";
                        activado = false;
                        pideindex = true;
                       
                      
                    }
                    else
         if (capturado.Trim() == "recall()" && activado == true)
                    {
                        capturado = "";                    
                            activado = false;
                      
                       

                            actualizartodo();
                       



                    }

                    else
                     if (capturado.Trim() == "caratula()" && activado == true)
                        {
                            capturado = "";
                            activado = false;

                         

                                actualizarcaratula();
                            



                        }

                        else
if (capturado.Trim() == "playpause()" && activado == true)
                    {

                        capturado = "";
                        activado = false;
                       if(axWindowsMediaPlayer1.playState==WMPLib.WMPPlayState.wmppsPaused)
                        {
                            axWindowsMediaPlayer1.Ctlcontrols.play();
                            this.pictureBox9.Visible = true;
                            this.pictureBox10.Visible = false;
                                            }
                                            else
                             if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                        {
                            axWindowsMediaPlayer1.Ctlcontrols.pause();
                            this.pictureBox9.Visible = false;
                            this.pictureBox10.Visible = true;
                        }
                        else
                             if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
                        {
                            axWindowsMediaPlayer1.Ctlcontrols.play();
                            this.pictureBox9.Visible = true;
                            this.pictureBox10.Visible = false;
                        }


                    }
                    else
              if (capturado.Trim() == "pause()" && activado == true)
                    {

                        capturado = "";
                        activado = false;

                        axWindowsMediaPlayer1.Ctlcontrols.pause();
                        this.pictureBox9.Visible = false;
                        this.pictureBox10.Visible = true;



                    }
                    else
                    /////////////////////////////////////////////////////////////////////////////
                      if (pideindex==true && activado == true)
                    {
                        
                        activado = false;
                        pideindex = false;
                       

                        indexdelalista = Convert.ToInt32(capturado.Trim());
                        capturado = "";
                        if (lapara.Count >= 1 && indexdelalista>=0 && indexdelalista<=lapara.Count && enproceso == false)
                        {

                         ;
                            int loc1 = indexdelalista;


                            if (loc1 >= lapara.Count)
                            {

                            }
                            else
                            {

                                //  if (lapara.IndexOf(igualador) == locanterior)
                                //{
                                //}
                                //else
                                // {
                                //   if (axWindowsMediaPlayer1.settings.volume != 0 )
                                //{
                                //  lapara[loc1] = "♫" + igualador + "<»";
                                //}
                                //else
                                //{
                                //   lapara[loc1] = "♫" + igualador + "<x";
                                //}
                                //}
                            
                            }
                            if (lapara[loc1].StartsWith(">"))
                            {

                            }
                            else
                            {
                                    listBox1.SelectedIndex = loc1;
                                   igualador = lapara[loc1];
                                string sec1 = lapara[loc1];

                                lapara[loc1] = ">" + igualador + "<";
                                lapara[locanterior] = anterior;
                                anterior = igualador;
                                locanterior = loc1;
                                listBox1.DataSource = null;
                                listBox1.DataSource = lapara;

                                listBox1.Refresh();
                                string[] partes = sec1.Split(' ');
                                string completa = "";
                                for (int i = 0; i < partes.Length; i++)
                                {
                                    completa += partes[i] + "+";
                                }
                                    axWindowsMediaPlayer1.URL = "";
                                    string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[loc1].Split('=')[1];
                                    //   webBrowser1.Navigate(url1);
                                    actualizarlista();
                                    reproducir(laparalink[loc1]);
                                listBox1.DataSource = null;
                                listBox1.DataSource = lapara;
                          
                            }
                           
                        }
                   
                    }
                    else
if (capturado.Trim() == "play()" && activado == true)
                    {

                        capturado = "";
                        activado = false;

                        if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
                        {
                            axWindowsMediaPlayer1.Ctlcontrols.play();
                            this.pictureBox9.Visible = true;
                            this.pictureBox10.Visible = false;
                        }
                        else
                 if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
                        {
                            axWindowsMediaPlayer1.Ctlcontrols.play();
                            this.pictureBox9.Visible = true;
                            this.pictureBox10.Visible = false;

                        }

                    }
                    else
if (capturado.Trim() == "menu()" && activado == true)
                    {

                        capturado = "";
                        activado = false;
                        this.timer3.Enabled = true;
                        
                    }
                    else
if (capturado.Trim() == "navegador()" && linkLabel1.Text != "" && activado == true) 
                    {
                        capturado = "";
                        activado = false;

                        System.Diagnostics.Process.Start(linkLabel1.Text);
                        
                    }
                    else
                    if (capturado.Trim() == "descmp3()" && linkLabel1.Text != "" && activado == true)
                    {

                        capturado = "";
                        activado = false;
                          
                        ejecutarform();
                         

                        }
                    else
                      if (capturado.Trim() == "descvid360()" && linkLabel1.Text != "" && activado == true)
                    {
                            activado = false;
                            quality = 360;
                         
                                ejecutarvidform();
                         
                          
                            capturado = "";
                       
                    }
                    else
                                          if (capturado.Trim() == "descvid480()" && linkLabel1.Text != "" && activado == true)
                    {
                            activado = false;
                            capturado = "";
                       
                        quality = 480;
                     
                                ejecutarvidform();
                         

                        }
                    else
                                          if (capturado.Trim() == "descvid720()" && linkLabel1.Text != "" && activado == true)
                    {
                            activado = false;
                        capturado = "";
                      
                        quality = 720;
                            ejecutarvidform();

                        }
                    else
if (capturado.Trim() == "fullscreen()"&& axWindowsMediaPlayer1.fullScreen==false && activado == true)
                    {
                        capturado = "";
                        activado = false;
                            try
                            {


                                if (label3.Text.Trim() != "")
                                {




                                    axWindowsMediaPlayer1.fullScreen = true;

                                }


                            }
                            catch (Exception)
                            {

                            }

                    }
                    else
                  if (capturado.Trim() == "fullscreen()" && axWindowsMediaPlayer1.fullScreen == true && activado == true)

                    {
                        capturado = "";
                        activado = false;
                            try
                            {
                                if (axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsReady)
                                {

                                    axWindowsMediaPlayer1.fullScreen = false;
                                }
                            }
                            catch (Exception)
                            {

                            }

                    }
                        else

                        if (capturado.Trim() == "actualizarlalista()" && activado == true)

                        {
                            capturado = "";
                            activado = false;
                            actualizarlistareproduccion();



                        }
                        else
                      if (capturado.Trim() == "agregar()" && activado == true)

                    {
                        capturado = "";
                        activado = false;
                        agregado = true;
                      
                    

                    }
                    else
                       if (capturado.Trim() == "next()" && activado == true && enproceso == false)

                    {
                        capturado = "";
                        activado = false;
                        try
                        {
                            if (lapara.Count >= 1)
                        {


                                int loc1 = locanterior;
                            if (loc1 >= lapara.Count)
                            {

                            }
                            else
                            {

                                    loc1 = locanterior + 1;
                                  
                                        igualador = lapara[loc1];
                                    string sec1 = lapara[loc1];
                                lapara[locanterior] = anterior;
                                anterior = igualador;
                                if (axWindowsMediaPlayer1.settings.volume != 0)
                                {
                                        lapara[loc1] = ">" + igualador + "<";
                                    }
                                else
                                {
                                        lapara[loc1] = ">" + igualador + "<";
                                    }
                                locanterior = loc1;
                                listBox1.DataSource = null;
                                listBox1.DataSource = lapara;
                                 
                                    listBox1.Refresh();
                                string[] partes = sec1.Split(' ');
                                string completa = "";
                                for (int i = 0; i < partes.Length; i++)
                                {
                                    completa += partes[i] + "+";
                                }
                                        listBox1.SelectedIndex = locanterior;
                                        axWindowsMediaPlayer1.URL = "";
                                        string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[loc1].Split('=')[1]; ;
                               // webBrowser1.Navigate(url1);
                                        reproducir(laparalink[loc1]);
                                        actualizarlista();
                             
                                    }

                        }
                       
                        }catch(Exception)
                        {
                           


                        }
                    }
                    else
                    if (capturado.Trim() == "back()" && activado == true && enproceso == false)

                    {
                        capturado = "";
                        activado = false;
                        try
                        {

                            if (lapara.Count >= 1)
                            {

                                int loc1 = locanterior;
                               
                                if (loc1 <= 0)
                                {
                                  
                                }
                                else
                                {
                                   loc1 = locanterior - 1;
                                    igualador = lapara[loc1];
                                      
                                        string sec1 = lapara[loc1];
                                    lapara[locanterior] = anterior;
                                    anterior = igualador;
                                    if (axWindowsMediaPlayer1.settings.volume != 0)
                                    {
                                        lapara[loc1] = ">" + igualador + "<";
                                    }
                                    else
                                    {
                                        lapara[loc1] = ">" + igualador + "<";
                                    }
                                    locanterior = loc1;
                                    listBox1.DataSource = null;
                                    listBox1.DataSource = lapara;
                                        

                                    listBox1.Refresh();
                                        listBox1.SelectedIndex = locanterior;
                                        axWindowsMediaPlayer1.URL = "";
                                        string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[loc1].Split('=')[1]; ;
                                        //  webBrowser1.Navigate(url1);
                                        reproducir(laparalink[loc1]);
                                        actualizarlista();
                                
                                }
                            }


                           

                    }
                        catch(Exception )
                        {

                        }
                    }
                    else
                    if (capturado.Trim() == "vol+()" && activado == true)

                    {
                        capturado = "";
                        activado = false;
                        axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume + 10;
                        if (GR3_UiF.Properties.Settings.Default.Notificaciones == true)
                        {

                                Thread proc = new Thread(new ThreadStart(notificarvolumen));
                                proc.Start();
                           
                        }
                    }
                    else
                        if (capturado.Trim() == "vol-()" && activado == true)
                    {
                        capturado = "";
                        activado = false;
                        axWindowsMediaPlayer1.settings.volume = axWindowsMediaPlayer1.settings.volume -10;
                            if (GR3_UiF.Properties.Settings.Default.Notificaciones == true)
                            {

                                Thread proc = new Thread(new ThreadStart(notificarvolumen));
                                proc.Start();

                            }

                    }
                    else
                     if (capturado.Trim() == "actual+()" && linkLabel1.Text != "" && activado == true)
                    {
                         capturado = "";
                        activado = false;
                        if (axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsReady)
                        {
                            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition + 10;
                        }

                    }
                    else
                      if (capturado.Trim() == "cerrado()" && activado == true)
                    {
                        capturado = "";
                        activado = false;
                    
                       

                    }
                    else
                     if (capturado.Trim() == "actual-()" && linkLabel1.Text != "")
                    {
                        capturado = "";
                        activado = false;
                        if (axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsReady)
                        {
                            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition - 10;
                        }

                    }
                    else


                    {
                            ////////////////////////////////////////////////////////////
                            if (agregado == true && activado == true)
                            {

                                agregado = false;

                                string textboxcopia = obtenernombreylink(capturado);
                                if (textboxcopia != "%%%nulo%%%") {


                                    if (encontroparecido(textboxcopia.Split('¤')[1].Trim(), laparalink) == false) {

                                        laparalink.Add(textboxcopia.Split('¤')[1]);
                                        lapara.Add(textboxcopia.Split('¤')[0]);
                                        capturado = "";

                                        if (lapara.Count == 1)
                                        {
                                            string[] partes = textboxcopia.Split(' ');

                                            string completa = "";
                                            for (int i = 0; i < partes.Length; i++)
                                            {
                                                completa += partes[i] + "+";
                                            }
                                            axWindowsMediaPlayer1.URL = "";
                                            string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[0].Split('=')[1]; ;
                                            //   webBrowser1.Navigate(url1);




                                            locanterior = 0;
                                            igualador = lapara[0];

                                            if (axWindowsMediaPlayer1.settings.volume != 0)
                                            {
                                                lapara[0] = ">" + igualador + "<";
                                            }
                                            else
                                            {
                                                lapara[0] = ">" + igualador + "<";
                                            }

                                            listBox1.DataSource = null;
                                            listBox1.DataSource = lapara;
                                            listBox1.SelectedIndex = 0;
                                            anterior = textboxcopia.Split('¤')[0];
                                            actualizarlista();

                                            reproducir(laparalink[0]);


                                            activado = false;
                                        }
                                        else
                                        {


                                            listBox1.DataSource = null;
                                            listBox1.DataSource = lapara;

                                            actualizarlista();
                                            activado = false;


                                        }
                                    }
                                    else
                                    {

                                        notificarerror("Elemento ya existe");
                                    }
                                }
                            }
                            ////////////////////////////////////////////////////////////////////////////////////////////////
                            else
                            if (activado == true && capturado.Trim().Length>0 && !nocontienequerry(capturado))
                            {

                                try { 
                                
                                string textboxcopia = obtenernombreylink(capturado);
                                if (textboxcopia != "%%%nulo%%%")
                                {


                                    if (encontroparecido(textboxcopia.Split('¤')[1], laparalink) == false)
                                    {



                                        laparalink.Add(textboxcopia.Split('¤')[1]);
                                        lapara.Add(textboxcopia.Split('¤')[0]);
                                        capturado = "";

                                        if (lapara.Count == 1)
                                        {


                                            string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[0].Split('=')[1];
                                            //  webBrowser1.Navigate(url1);



                                            locanterior = 0;
                                            igualador = lapara[0];

                                            if (axWindowsMediaPlayer1.settings.volume != 0)
                                            {
                                                lapara[0] = ">" + igualador + "<";
                                            }
                                            else
                                            {
                                                lapara[0] = ">" + igualador + "<";
                                            }
                                            listBox1.DataSource = null;
                                            listBox1.DataSource = lapara;
                                            listBox1.SelectedIndex = 0;

                                            anterior = textboxcopia.Split('¤')[0];

                                            actualizarlista();
                                            reproducir(laparalink[0]);
                                        }
                                        else
                                        {

                                            lapara[locanterior] = igualador;

                                            igualador = textboxcopia.Split('¤')[0];
                                            locanterior = lapara.IndexOf(igualador);

                                            if (axWindowsMediaPlayer1.settings.volume != 0)
                                            {
                                                lapara[locanterior] = ">" + igualador + "<";
                                            }
                                            else
                                            {
                                                lapara[locanterior] = ">" + igualador + "<";
                                            }
                                            anterior = textboxcopia.Split('¤')[0];
                                            axWindowsMediaPlayer1.URL = "";
                                            string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[locanterior].Split('=')[1];
                                            //  webBrowser1.Navigate(url1);
                                            actualizarlista();
                                            reproducir(laparalink[locanterior]);
                                            listBox1.DataSource = null;
                                            listBox1.DataSource = lapara;
                                            listBox1.SelectedIndex = locanterior;



                                        }

                                    }
                                    else
                                    {
                                        notificarerror("Elemento ya existe");
                                    }
                                }
                            }
                                catch (Exception eee)
                                {
                                    MessageBox.Show("error aqui", eee.Message);
                                }
                            }
                        }
                      

                    }
             
            }catch(Exception )
                {
                   
                }
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        

        }

        public void notificarvolumen()
        {
            this.BeginInvoke((Action)delegate {

                Volumedialog volume = new Volumedialog();
                volume.porciento = axWindowsMediaPlayer1.settings.volume;
                volume.Show();


            });
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                GR3_UiF.Properties.Settings.Default.estatus = "reprod";

            }
            else
            {
                GR3_UiF.Properties.Settings.Default.estatus = "no";
            }

            if (GR3_UiF.Properties.Settings.Default.miniplayeron == true && lapara.Count>0)
            {
                if (GR3_UiF.Properties.Settings.Default.controlmini == true && GR3_UiF.Properties.Settings.Default.cambiovolumenmini==false)
                {
                  
                    axWindowsMediaPlayer1.Ctlcontrols.currentPosition = GR3_UiF.Properties.Settings.Default.posicionmini;
                    GR3_UiF.Properties.Settings.Default.controlmini = false;
                    GR3_UiF.Properties.Settings.Default.Save();

                }
                else
                if(GR3_UiF.Properties.Settings.Default.controlmini == true && GR3_UiF.Properties.Settings.Default.cambiovolumenmini == true)
                {
                    axWindowsMediaPlayer1.settings.volume = GR3_UiF.Properties.Settings.Default.volumenmini;
                    GR3_UiF.Properties.Settings.Default.cambiovolumenmini = false;
                    GR3_UiF.Properties.Settings.Default.controlmini = false;
                    GR3_UiF.Properties.Settings.Default.Save();
                }
                try
                {
                    GR3_UiF.Properties.Settings.Default.durationstring = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString;
                    GR3_UiF.Properties.Settings.Default.posicion = Convert.ToInt32(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
                    GR3_UiF.Properties.Settings.Default.duracion = Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration);
                    GR3_UiF.Properties.Settings.Default.Save();
                }
                catch (Exception)
                {

                }
              
              
                GR3_UiF.Properties.Settings.Default.volumen = axWindowsMediaPlayer1.settings.volume;
             
                /////////////////////////////////////////////////////////////////////////////////////////////


                this.Visible = false;
                    this.ShowInTaskbar = false;
               

            }
         
            else
            {
                if (this.Visible != true)
                {
                    this.Visible = true;
                    this.ShowInTaskbar = true;
                }
            }

            GR3_UiF.Properties.Settings.Default.Save();




        }


        private void timer2_Tick(object sender, EventArgs e)
        {

           
            string notperma = " " + label1.Text;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(label1.Text);
            int total = sb.Length;
            string n = "";
            int cco = 0;
            try { 
            foreach(TcpClient ccl in clientes)
            {
                if (SocketExtensions.IsConnected(ccl) == true)
                {
                    cco++;
                }
            }
            }
            catch (Exception) { }
            n = string.Concat(Enumerable.Repeat("📱", cco));
            connectionstatusicon = "[" + n + "]";
            if (total >= 55 && this.WindowState == FormWindowState.Normal) 
            {

                char ch = sb[0];
                sb.Remove(0, 1);
                sb.Insert(sb.Length, ch);
                label1.Text = sb.ToString();
                label1.Refresh();

                Application.DoEvents();





            }                      
            else
            if(total==0)
            {
                this.label1.Text = "";
            }
            else
            {
                this.label1.Text = anumasisierto;
            }
           /* if (SocketExtensions.IsConnected(cliente)==true)
            {

                connectionstatusicon = "[📱]";

               
            }
            else
            if (SocketExtensions.IsConnected(cliente) == false)
            {
             
                connectionstatusicon = "[x📱]";
                
            }
            */
            if (this.panel2.BackColor!=GR3_UiF.Properties.Settings.Default.colorm)
            {
                this.pictureBox4.BackColor = GR3_UiF.Properties.Settings.Default.colorm;
                metroProgressSpinner1.ForeColor = panel2.BackColor;
                this.panel2.BackColor = GR3_UiF.Properties.Settings.Default.colorm;
           


            }
            ////////////////////////////////////////////////////////////////////////////////////////////
            if (lista != GR3_UiF.Properties.Settings.Default.lista)
            {
                lista = GR3_UiF.Properties.Settings.Default.lista;
                lista2 = GR3_UiF.Properties.Settings.Default.listalinks;
                lapara.Clear();
                laparalink.Clear();
                int prrol = 0;
             
                string[] partido = lista.Split(';');
                lapara = partido.ToList();
               for (int i=0;i<lapara.Count;i++)
                {
                    if (lapara[i].StartsWith(">") && lapara[i].EndsWith("<"))
                    {
                        prrol = i;
                    }
                    lapara[i] = lapara[i].Replace('>', ' ');
                    lapara[i] = lapara[i].Replace('<', ' ');
                }

            
                string[] partidoo2 = lista2.Split(';');
                laparalink = partidoo2.ToList();
                if (laparalink[laparalink.Count - 1].Trim() == "")
                {
                    laparalink.RemoveAt(laparalink.Count - 1);
                }
                listBox1.Refresh();
              
                

                   
                  
             
                axWindowsMediaPlayer1.URL = "";
                string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[prrol];
                // webBrowser1.Navigate(url1);
                reproducir(laparalink[prrol]);


                locanterior = prrol;
                    igualador = lapara[prrol];

                    if (axWindowsMediaPlayer1.settings.volume != 0)
                    {
                        lapara[prrol] = ">" + igualador + "<";
                    }
                    else
                    {
                        lapara[prrol] = ">" + igualador + "<";
                    }
                   
                    listBox1.Refresh();
                anterior = igualador;
                listBox1.DataSource = null;
                listBox1.DataSource = lapara;
                listBox1.SelectedIndex = prrol;
                actualizarlista();



                GR3_UiF.Properties.Settings.Default.lista = "";
                GR3_UiF.Properties.Settings.Default.listalinks = "";
             
                lista = "";
                GR3_UiF.Properties.Settings.Default.Save();
               


            }
            ////////////////////////////////////////////////////////////////////////////////

            if (GR3_UiF.Properties.Settings.Default.eliminadorabierto == true)
            {
                listBox1.SelectedIndex = lapara.IndexOf(">" + igualador + "<");
            }
            if (lenguaje != GR3_UiF.Properties.Settings.Default.lenguaje)
            {
                lenguajeseteado = false;



            }
            if ( GR3_UiF.Properties.Settings.Default.Color_appchange==true)
            {
                GR3_UiF.Properties.Settings.Default.Color_appchange = false;
                GR3_UiF.Properties.Settings.Default.Save();

                actualizarcaratula();



            }
            if (GR3_UiF.Properties.Settings.Default.lenguaje != "")
            {
                if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
                {
                    lenguaje = "esp";
                    metroLabel2.Text = "Personalizacion de interfaz";
                    metroLabel3.Text = "Descargar";
                    metroLabel4.Text = "Descargas realizadas";
                    metroLabel5.Text = "Navegador";
                    metroLabel6.Text = "Conectar cliente";
                    metroLabel7.Text = "mini reproductor";
                    metroLabel8.Text = "Sincronizar listas de reproduccion";
                    metroLabel9.Text = "Configuracion";
                    metroLabel1.Text = "Cerrar menu";
                    tt35.SetToolTip(pictureBox35, "Lista de descargas realizadas");
                    tt7.SetToolTip(pictureBox7, "Configuraciones");
                    tt20.SetToolTip(pictureBox20, "Abrir menú de conexion con cliente(app)");
                    tt8.SetToolTip(pictureBox8, "Abrir navegador personalizado");
                    tt6.SetToolTip(pictureBox6, "Menú de descargas");
                    tt3.SetToolTip(pictureBox3, "Personalizacion de la interfaz");
                    tt5.SetToolTip(pictureBox5, "Cerrar Menú desplegable");
                    tt11.SetToolTip(pictureBox11, "Abrir menú de reproducción");
            
                    ttp4.SetToolTip(panel4, "Busqueda rapida");
                    tt12.SetToolTip(pictureBox12, "Cerrar menú de reproducción");
             
                    tt18.SetToolTip(pictureBox18, "Repetir la lista");
                    tt17.SetToolTip(pictureBox17, "Repetir elemento actual");
                    tt16.SetToolTip(pictureBox16, "Elemento anterior");
                    tt15.SetToolTip(pictureBox15, "Elemento siguiente");
                    tt9.SetToolTip(pictureBox9, "Pausar");
                    tt10.SetToolTip(pictureBox10, "Reproducir");
                    tt34.SetToolTip(pictureBox34, "Recargar elemento actual");
                    tt2.SetToolTip(pictureBox2, "Abrir menú desplegable");
                    tt21.SetToolTip(pictureBox21, "Reproducir lista de reproducción creada");
                   
                    tt32.SetToolTip(pictureBox32, "Modo mini");
                    this.label5.Text = "Lista actual";
                    tt33.SetToolTip(pictureBox33, "Menu de sincronizacion");
                }
                else
                  if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
                {
                    lenguaje = "eng";
                    tt35.SetToolTip(pictureBox35, "List of completed downloads");
                    tt7.SetToolTip(pictureBox7, "Setting");
                    tt20.SetToolTip(pictureBox20, "Open client(app)connection menu");
                    tt8.SetToolTip(pictureBox8, "Open custom web browser");
                    tt6.SetToolTip(pictureBox6, "Download menu");
                    tt3.SetToolTip(pictureBox3, "Customize the interface");
                    tt5.SetToolTip(pictureBox5, "Close side menu");
                    tt11.SetToolTip(pictureBox11, "Open play menu");
                  
                    ttp4.SetToolTip(panel4, "Fast Search");
                    tt12.SetToolTip(pictureBox12, "Close play menu");
                
                    tt18.SetToolTip(pictureBox18, "Repeat the playlist");
                    tt17.SetToolTip(pictureBox17, "Repeat actual media");
                    tt16.SetToolTip(pictureBox16, "Back");
                    tt15.SetToolTip(pictureBox15, "Next");
                    tt9.SetToolTip(pictureBox9, "Pause");
                    tt10.SetToolTip(pictureBox10, "Play");
                    tt2.SetToolTip(pictureBox2, "Open side menu");
                    this.label5.Text = "Current playlist";
                    tt34.SetToolTip(pictureBox34, "Reload actual element");
                    tt21.SetToolTip(pictureBox21, "Play created playlist");
                   
                    tt32.SetToolTip(pictureBox32, "Mini mode");
                    tt33.SetToolTip(pictureBox33, "Sync menu");

                    metroLabel2.Text = "User interface customization";
                    metroLabel3.Text = "Download";
                    metroLabel4.Text = "Realized downloads";
                    metroLabel5.Text = "Custom web browser";
                    metroLabel6.Text = "Connect client";
                    metroLabel7.Text = "Mini player";
                    metroLabel8.Text = "Sync playlist";
                    metroLabel9.Text = "Settings";
                    metroLabel1.Text = "Close menu";

                }
            }
                if (this.panel3.BackColor != GR3_UiF.Properties.Settings.Default.color_barra)
            {


                this.panel3.BackColor = GR3_UiF.Properties.Settings.Default.color_barra;
                this.panel11.BackColor = GR3_UiF.Properties.Settings.Default.color_barra;


            }
            if (this.pictureBox4.BackColor != GR3_UiF.Properties.Settings.Default.color_marco&& GR3_UiF.Properties.Settings.Default.color_marcoon==true)
            {


                this.pictureBox4.ImageLocation = "";

                this.pictureBox4.BackColor = GR3_UiF.Properties.Settings.Default.color_marco;


            }
          
            
       
          
             
                    if (axWindowsMediaPlayer1.settings.volume != 0)
                {
                  
                   
                    this.Text = connectionstatusicon+"      "+"Youtube" + " <»";
                   
                }
                else
                {
                  
                    this.Text = connectionstatusicon + "      " + "Youtube" + " <x";
                   
                }
                if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
                {

                    this.Text = connectionstatusicon + "      " + "Youtube" + " <";

                }
        
       
          
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            this.panel3.Location = new Point(this.panel3.Location.X + 20, -1);
            this.timer4.Enabled = false;
            this.timer6.Enabled = true;
            if (this.panel3.Location.X >=1)
            {
                this.timer3.Enabled = false;
                this.panel3.Location = new Point(1,-1 );

            }

           
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            this.panel3.Location = new Point(this.panel3.Location.X - 20, -1);
            this.timer3.Enabled = false;

            if (this.panel3.Location.X <= -306)
            {
                this.timer4.Enabled = false;
                this.panel3.Location = new Point(-306, -1);
              

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.timer3.Enabled = true;
        }

      

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
        
            this.timer3.Enabled = true;
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

            canim.animar(pictureBox3, pictureBox3.Height, pictureBox3.Width);
            if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
            {
                configuraciones lapara = new configuraciones();
                formenpanel(panel9, lapara);
            }
            else
            {
                configuraciones lapara = new configuraciones();
                lapara.Show();
             //   lapara.Location = this.Location;
                this.timer4.Enabled = true;
            }

         


           
           
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox5, pictureBox5.Height, pictureBox5.Width);

            this.timer4.Enabled = true;
        }  
             
        private void pictureBox6_Click(object sender, EventArgs e)
        {

            canim.animar(pictureBox6, pictureBox6.Height, pictureBox6.Width);
            if (anumasisierto == "")
            {
              notificarerror("Por favor reproduzca un video");

            }
            else
            {
                if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
                {
                    Downloader2 descalgador = new Downloader2();
                    descalgador.link = this.linkLabel1.Text;
                    descalgador.titulo = anumasisierto;
                    descalgador.imgurl = this.pictureBox1.ImageLocation;
                    descalgador.modoenform = true;
                    formenpanel(panel9, descalgador);
                }
                else {
                    Downloader2 descalgador = new Downloader2();
                  //  descalgador.Location = this.Location;
                    descalgador.link = this.linkLabel1.Text;
                    descalgador.titulo = anumasisierto;
                    descalgador.imgurl = this.pictureBox1.ImageLocation;
                    descalgador.Show();
                    this.timer4.Enabled = true;
                }
             
            }
          
         
    }
        public void buscar()
        {
          
            try
            {
                //   int tryes = 0;
                //    while (video == null || tryes<10) { 

                string video2 = "";
                string title = "";
                using (var videito = Client.For(YouTube.Default))
                {
                    var videoo = videito.GetAllVideosAsync(zelda.Trim());
                    var resultados = videoo.Result;
                    title = resultados.First().Title.Replace("- YouTube", "");

                    // video2 = resultados.First(info => info.Resolution == -1 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;

                    ///  video2 = resultados.First(info => info.Resolution == 240 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                    int calidad = GR3_UiF.Properties.Settings.Default.caldidad_defecto;
                    if (calidad == 0)
                    {
                        calidad = -1;
                    }
                    try { 
               video2 =resultados.First(info => info.Resolution ==calidad && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                    }
                    catch (Exception)
                    {
                        try { 
                        calidad = 360;
                        video2 = resultados.First(info => info.Resolution == 360 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                        }
                        catch (Exception)
                        {
                            try { 
                            calidad = 240;
                            video2 = resultados.First(info => info.Resolution == 240 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                            }
                            catch (Exception)
                            {
                                calidad = -1;
                                video2 = resultados.First(info => info.Resolution == -1 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                            }
                        }
                    }
                  ///  MessageBox.Show(video2);
                  

                }
                /////gjghjg
               /// videoinfoss = DownloadUrlResolver.GetDownloadUrls(zelda.Trim(), false);
               



                  ///  video = videoinfoss.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == GR3_UiF.Properties.Settings.Default.caldidad_defecto);
                  //  tryes++;
                
                   
              //  }
          
               
             
                metroProgressSpinner1.Value = metroProgressSpinner1.Value + 20;
               /* if (video.RequiresDecryption)
                {
                    DownloadUrlResolver.DecryptDownloadUrl(video);
                }
              */
               
                this.label1.Text = "   " + RemoveIllegalPathCharacters(title);
                axWindowsMediaPlayer1.close();
             
                axWindowsMediaPlayer1.URL = video2;
                metroProgressSpinner1.Value = metroProgressSpinner1.Value + 20;
                anumasisierto =RemoveIllegalPathCharacters(title);
             
              
                enproceso = false;
                this.Invoke((MethodInvoker)delegate {
                    pictureBox1.Visible = true;
                });
                if (GR3_UiF.Properties.Settings.Default.Notificaciones==true)
                {
                    this.BeginInvoke((Action)delegate {

                     

                
                    notification_bar la = new notification_bar();
                    la.DesktopLocation = new Point(525, 3);
                        la.titulo = anumasisierto;
                    la.link = linkLabel1.Text;
                    la.imagen = pictureBox1.ImageLocation;

                    la.Show ();
                  
                    });

                    
            }
                this.BeginInvoke((Action)delegate {

                   


                    this.pictureBox9.Visible = true;
                this.pictureBox10.Visible = false;
                });
                actualizarcaratula();
                metroProgressSpinner1.Visible = false;
             
            }
            catch(Exception )
            {
         
                tubito = "";
                GR3_UiF.Properties.Settings.Default.tubito = "";
              
                    if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa") {
                    notificarerror("no se pudo reproducir por favor cambie la calidad o recargue");
                    }
                    else
                        if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
                {
                    notificarerror("The video cant be played please change the quality or recharge the video");
                }
                metroProgressSpinner1.Value = 0;
                enproceso = false;
                metroProgressSpinner1.Visible = false;
                   actualizarcaratula();
                /*
     limpiarui();
  
     */
            }



        }
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }

        public void botongral()
        {
            string textboxcopia = "";
            if ( textBox1.Text.Length >= 5)
            {

                string texto2 = textBox1.Text;
                textBox1.Text = "Buscando...";
                textboxcopia = obtenernombreylink(texto2);
                if (textboxcopia != "%%%nulo%%%")
                {

                    customdialog dialogo = new customdialog();
                    dialogo.Location = this.Location;
                  //  string[] cadenita2 = vireos[indice].url.Split('=');
                    dialogo.imagen =  textboxcopia.Split('¤')[1].Split('=')[1]  ;
                    dialogo.url =textboxcopia.Split('¤')[1] ;

                    dialogo.Show();
                 
                    textBox1.Text = "";


                    /*    if (resultado == DialogResult.OK)
                        {

                            laparalink.Add(textboxcopia.Split('¤')[1]);
                            lapara.Add(textboxcopia.Split('¤')[0]);
                            string[] partes = textboxcopia.Split(' ');

                            string completa = "";
                            for (int i = 0; i < partes.Length; i++)
                            {
                                completa += partes[i] + "+";
                            }

                            string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[0].Split('=')[1];
                            // webBrowser1.Navigate(url1);
                            reproducir(laparalink[0]);

                            locanterior = 0;
                            igualador = lapara[0];

                            if (axWindowsMediaPlayer1.settings.volume != 0)
                            {
                                lapara[0] = ">" + igualador + "<";
                            }
                            else
                            {
                                lapara[0] = ">" + igualador + "<";
                            }

                            listBox1.DataSource = null;
                            listBox1.DataSource = lapara;

                            listBox1.SelectedIndex = 0;
                            listBox1.Refresh();
                            anterior = textboxcopia;
                            this.textBox1.Text = "";
                            actualizarlista();

                        }
                        else
                        if(resultado==DialogResult.No)
                        {

                            laparalink.Add(textboxcopia.Split('¤')[1]);
                            lapara.Add(textboxcopia.Split('¤')[0]);
                            string[] partes = textboxcopia.Split(' ');

                            string completa = "";
                            for (int i = 0; i < partes.Length; i++)
                            {
                                completa += partes[i] + "+";
                            }

                            string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[0].Split('=')[1];
                            // webBrowser1.Navigate(url1);
                            reproducir(laparalink[0]);

                            locanterior = 0;
                            igualador = lapara[0];

                            if (axWindowsMediaPlayer1.settings.volume != 0)
                            {
                                lapara[0] = ">" + igualador + "<";
                            }
                            else
                            {
                                lapara[0] = ">" + igualador + "<";
                            }

                            listBox1.DataSource = null;
                            listBox1.DataSource = lapara;

                            listBox1.SelectedIndex = 0;
                            listBox1.Refresh();
                            anterior = textboxcopia;
                            this.textBox1.Text = "";
                            actualizarlista();

                        }
                        else
                        {
                            textBox1.Text = "";
                        }
                        }
                        else
                        {
                            textBox1.Text = "";
                            notificarerror("El elemento ya existe");
                        }


                        */


                }
                }
            }
      
        private void panel4_Click(object sender, EventArgs e)
        {

            botongral();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox7, pictureBox7.Height, pictureBox7.Width);
            if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
            {
                Configs conf = new Configs();
                formenpanel(panel9, conf);
            }
            else
            {
             
                Configs conf = new Configs();
            //    conf.Location = this.Location;
                conf.Show();
                this.timer4.Enabled = true;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
        
            System.Text.StringBuilder sb2 = new System.Text.StringBuilder(label4.Text);
            sb2.Insert(sb2.Length, "              • • •");
            sb2.Remove(0, 1);

            label4.Text = sb2.ToString();
            label4.Refresh();

            Application.DoEvents();
            if (this.tubito2 != GR3_UiF.Properties.Settings.Default.tubito2 && GR3_UiF.Properties.Settings.Default.tubito.Trim() == "agregar")
            {
                if (encontroparecido(GR3_UiF.Properties.Settings.Default.laparalink, laparalink) == false)
                {
                    string linksillo = "";
                    tubito = GR3_UiF.Properties.Settings.Default.tubito;
                    GR3_UiF.Properties.Settings.Default.tubito = "";

                    tubito2 = GR3_UiF.Properties.Settings.Default.tubito2;

                    lapara.Add(GR3_UiF.Properties.Settings.Default.tubito2);
                    laparalink.Add(GR3_UiF.Properties.Settings.Default.laparalink);
                    linksillo = GR3_UiF.Properties.Settings.Default.laparalink;
                    GR3_UiF.Properties.Settings.Default.laparalink = "";
                    listBox1.DataSource = null;
                    listBox1.DataSource = lapara;
                    listBox1.Refresh();
                    GR3_UiF.Properties.Settings.Default.Save();

                    if (lapara.Count == 1)
                    {


                        string url1 = "https://decapi.me/youtube/videoid?search=" + linksillo;
                        //    webBrowser1.Navigate(url1);
                        reproducir(linksillo);


                        locanterior = 0;
                        igualador = lapara[0];
                        lapara[0] = ">" + GR3_UiF.Properties.Settings.Default.tubito2 + "<";
                        listBox1.DataSource = null;
                        listBox1.DataSource = lapara;
                        listBox1.Refresh();
                        listBox1.SelectedIndex = 0;
                        anterior = tubito2;
                        tubito2 = "";


                    }

                    actualizarlista();
                }
                else
                {
                    tubito = GR3_UiF.Properties.Settings.Default.tubito;
                    GR3_UiF.Properties.Settings.Default.tubito = "";
                    GR3_UiF.Properties.Settings.Default.tubito2 = "";
                    tubito2 = GR3_UiF.Properties.Settings.Default.tubito2;
                    GR3_UiF.Properties.Settings.Default.laparalink = "";

                    tubito = "";
                    tubito2 = "";
                    GR3_UiF.Properties.Settings.Default.Save();
                    notificarerror("El elemento ya existe");
                }
            }
            else
                if (this.tubito2 != GR3_UiF.Properties.Settings.Default.tubito2 && GR3_UiF.Properties.Settings.Default.tubito.Trim() == "reproducir")
            {
                if (encontroparecido(GR3_UiF.Properties.Settings.Default.laparalink, laparalink) == false)
                {
                    string linksillo = "";
                    tubito = GR3_UiF.Properties.Settings.Default.tubito;
                    GR3_UiF.Properties.Settings.Default.tubito = "";

                    tubito2 = GR3_UiF.Properties.Settings.Default.tubito2;
                    laparalink.Add(GR3_UiF.Properties.Settings.Default.laparalink);
                    lapara.Add(GR3_UiF.Properties.Settings.Default.tubito2);
                    linksillo = GR3_UiF.Properties.Settings.Default.laparalink;
                    GR3_UiF.Properties.Settings.Default.laparalink = "";
                    GR3_UiF.Properties.Settings.Default.Save();
                    if (lapara.Count == 1)
                    {


                        string url1 = "https://decapi.me/youtube/videoid?search=" + linksillo;
                        //   webBrowser1.Navigate(url1);
                        reproducir(linksillo);


                        locanterior = 0;
                        igualador = lapara[0];
                        lapara[0] = ">" + GR3_UiF.Properties.Settings.Default.tubito2 + "<";

                        listBox1.DataSource = null;
                        listBox1.DataSource = lapara;
                        listBox1.Refresh();
                        listBox1.SelectedIndex = 0;
                        anterior = tubito2;
                        tubito2 = "";
                        GR3_UiF.Properties.Settings.Default.Save();
                        actualizarlista();

                    }
                    else
                    {
                        string[] partes = tubito2.Split(' ');

                        string completa = "";
                        for (int i = 0; i < partes.Length; i++)
                        {
                            completa += partes[i] + "+";
                        }
                        lapara[locanterior] = igualador;

                        igualador = tubito2;
                        locanterior = lapara.IndexOf(igualador);
                        lapara[locanterior] = ">" + igualador + "<";
                        anterior = tubito2;

                        string url1 = "https://decapi.me/youtube/videoid?search=" + linksillo;
                        //  webBrowser1.Navigate(url1);
                        reproducir(linksillo);
                        listBox1.DataSource = null;
                        listBox1.DataSource = lapara;
                        listBox1.SelectedIndex = locanterior;
                        listBox1.Refresh();

                        tubito2 = "";

                        actualizarlista();
                    }

                }
                else
                {
                    tubito = GR3_UiF.Properties.Settings.Default.tubito;
                    GR3_UiF.Properties.Settings.Default.tubito = "";
                    GR3_UiF.Properties.Settings.Default.tubito2 = "";
                    tubito2 = GR3_UiF.Properties.Settings.Default.tubito2;
                    GR3_UiF.Properties.Settings.Default.laparalink = "";
                   
                    tubito = "";
                    tubito2 = "";
                    GR3_UiF.Properties.Settings.Default.Save();
                    notificarerror("El elemento ya existe");
                }
            }
      
        }

/// /////////////////////////////////////////////////////////////////////////////////

      

/// //////////////////////////////////////////////////////////////////////////////////

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////condicion1/////////////////////////////////

            canim.animar(pictureBox8, pictureBox8.Height, pictureBox8.Width);
            if (GR3_UiF.Properties.Settings.Default.Navegadorn == true)
            {
                if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
                {
                    Webbrowser navegador = new Webbrowser();
                    navegador.Location = this.Location;
                    formenpanel(panel9, navegador);
                }
                else
                {
                    Webbrowser navegador = new Webbrowser();
                 //   navegador.Location = this.Location;
                    navegador.Show();
                    this.timer4.Enabled = true;
                }
             
            }
            /////////////////////////////////condicion2///////////////////////////////////
            else
            {
                if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
                {
                    Customwebbrowser navega2r = new Customwebbrowser();
                    formenpanel(panel9, navega2r);
                }
                else
                {
                    Customwebbrowser navega2r = new Customwebbrowser();
                    navega2r.Show();
                   // navega2r.Location = this.Location;
                    this.timer4.Enabled = true;
                }
             
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            macTrackBar1.Value = Convert.ToInt32(axWindowsMediaPlayer1.Ctlcontrols.currentPosition);
            try
            {
                label3.Text = axWindowsMediaPlayer1.Ctlcontrols.currentPositionString + "/" + axWindowsMediaPlayer1.currentMedia.durationString;
            }
            catch (Exception)
            {

            }
         

            macTrackBar2.Value = axWindowsMediaPlayer1.settings.volume;
     
            if (checkBox1.Checked == true && macTrackBar1.Value >= Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration) - 1)
            {
                macTrackBar1.Value = 1;
                axWindowsMediaPlayer1.Ctlcontrols.currentPosition = 1;
            }
            else
            if (this.axWindowsMediaPlayer1.playState != WMPLib.WMPPlayState.wmppsBuffering)
            {

                this.label4.Visible = false;


            }
            else
            {
                this.label4.Visible = true;
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fullscreen_mediaplayer playy = new fullscreen_mediaplayer();
            playy.Show();
            /*
            this.pictureBox9.Visible = false;
            this.pictureBox10.Visible = true;
          
            playy.axWindowsMediaPlayer1.URL = this.axWindowsMediaPlayer1.URL;
            playy.axWindowsMediaPlayer1.Ctlcontrols.currentPosition = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
         */

        }
        public  void ejecutarform()
        {
           // this.BeginInvoke((Action)delegate {

                GR3_UiF.Properties.Settings.Default.daemond = pictureBox1.ImageLocation + "¤" + linkLabel1.Text.Trim() + "¤" + label1.Text.Trim() + "¤" + 0 + "¤" + "";
                GR3_UiF.Properties.Settings.Default.Save();
       
               /* Fdescarga lapara = new Fdescarga();

                lapara.imagen = pictureBox1.ImageLocation;
                lapara.link = linkLabel1.Text.Trim();
                lapara.nombre = label1.Text.Trim();
                lapara.Show();*/


         //   });

           
   
        }
        public void ejecutarvidform()
        {
          //  this.BeginInvoke((Action)delegate {
                GR3_UiF.Properties.Settings.Default.daemond = pictureBox1.ImageLocation + "¤" + linkLabel1.Text.Trim() + "¤" + label1.Text.Trim() + "¤" +quality + "¤" + "video";
                GR3_UiF.Properties.Settings.Default.Save();

                /*
                Fdescarga lapara = new Fdescarga();
            
            lapara.imagen = pictureBox1.ImageLocation;
            lapara.calidad = quality;
            lapara.vidomp3 = "video";
            lapara.link = linkLabel1.Text.Trim();
            lapara.nombre = label1.Text.Trim();
            lapara.Show();
              */
          //  });
          
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

         
            if (GR3_UiF.Properties.Settings.Default.color_marcoon == false)
            {
                if (pictureBox1.Image == pictureBox1.ErrorImage)
                {
                    pictureBox1.ImageLocation = @"https://i.ytimg.com/vi/" + imgloc.Trim() + "/hqdefault.jpg";
                    actualizarcaratula();
                }
            }
            else
                  if (GR3_UiF.Properties.Settings.Default.color_marcoon == true)
            {
                pictureBox4.BackColor = GR3_UiF.Properties.Settings.Default.color_marco;
            }
      

        }

        private void pictureBox4_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
          
            if (GR3_UiF.Properties.Settings.Default.color_marcoon == false)
            {
                if (pictureBox4.Image == pictureBox4.ErrorImage)
                {


                    pictureBox4.ImageLocation = @"https://i.ytimg.com/vi/" + imgloc.Trim() + "/hqdefault.jpg";

                }
            }
            else
                  if (GR3_UiF.Properties.Settings.Default.color_marcoon == true)
            {
                pictureBox4.BackColor = GR3_UiF.Properties.Settings.Default.color_marco;
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
        

        }

        private void macTrackBar1_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = macTrackBar1.Value;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox9, pictureBox9.Height, pictureBox9.Width);

            if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                this.pictureBox9.Visible = false;
                this.pictureBox10.Visible = true;
            }
           
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox10, pictureBox10.Height, pictureBox10.Width);
            if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                this.pictureBox9.Visible = true;
                this.pictureBox10.Visible = false;
            }
            else
                 if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                this.pictureBox9.Visible = true;
                this.pictureBox10.Visible = false;

            }


        }

        private void axWindowsMediaPlayer1_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
        
            macTrackBar1.Maximum = Convert.ToInt32(axWindowsMediaPlayer1.currentMedia.duration);
         
            if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsMediaEnded)
            {

              
                if (lapara.Count >= 1)
                {
                
                    int loc1 = locanterior ;
              
                    igualador = lapara[loc1];
               
                    if (loc1 > lapara.Count-1 && checkBox2.Checked == true)
                    {
                      
                        loc1 = 0;
                       
                        igualador = lapara[loc1];
                        string sec1 = lapara[0];
                        lapara[locanterior] = anterior;
                        anterior = igualador;
                        lapara[loc1] = ">" + igualador + "<";
                        locanterior = loc1;
                        listBox1.DataSource = null;
                        listBox1.DataSource = lapara;                    
                        listBox1.Refresh();
                        listBox1.SelectedIndex = loc1;
                        axWindowsMediaPlayer1.URL = "";
                        string url11 = "https://decapi.me/youtube/videoid?search=" + laparalink[loc1];
                        //  webBrowser1.Navigate(url11);
                        reproducir(laparalink[loc1]);
                        actualizarlista();
                    }

                    else
                     if (loc1 >= lapara.Count-1 && checkBox2.Checked == false)
                    {
                        this.pictureBox10.Visible = true;
                        this.pictureBox9.Visible = false;
                    }
                    else
                   if (loc1 <lapara.Count-1 && checkBox2.Checked == false)
                        {
                      


                            loc1 = locanterior + 1;
                            igualador = lapara[loc1];
                            if (loc1 >= lapara.Count)
                            {

                            }
                            else
                            {

                                string sec1 = lapara[loc1];
                                lapara[locanterior] = anterior;
                                anterior = igualador;
                                if (axWindowsMediaPlayer1.settings.volume != 0)
                                {
                                lapara[loc1] = ">" + igualador + "<";
                            }
                                else
                                {
                                lapara[loc1] = ">" + igualador + "<";
                            }
                                locanterior = loc1;
                                listBox1.DataSource = null;
                                listBox1.DataSource = lapara;

                                listBox1.Refresh();
                                string[] partes = sec1.Split(' ');
                                string completa = "";
                            listBox1.SelectedIndex = loc1;
                            for (int i = 0; i < partes.Length; i++)
                                {
                                    completa += partes[i] + "+";
                                }
                            axWindowsMediaPlayer1.URL = "";
                            string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[loc1];
                            //  webBrowser1.Navigate(url1);
                            reproducir(laparalink[loc1]);
                            actualizarlista();
                        }

                      
                    }




                }
          /*      if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                this.pictureBox10.Visible = true;
                this.pictureBox9.Visible = false;
                this.label4.Visible = false;
                }*/
            if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
              
               
                    this.label4.Visible = false;

                }
                if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsBuffering)
                {


                   
                }


            }
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox11, pictureBox11.Height, pictureBox11.Width);
            this.panel5.Visible = true;       
            this.pictureBox11.Visible = false;
            this.pictureBox12.Visible = true;
            this.listBox1.Visible = true;     
            this.label5.Visible = true;
            this.panel8.Visible = true;
            this.panel12.Visible = true;

            panel5.BringToFront();
            this.label5.BringToFront();
            this.panel8.BringToFront();
            this.panel12.BringToFront();
            this.listBox1.BringToFront();
            this.pictureBox12.BringToFront();
            this.pictureBox11.BringToFront();

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox12, pictureBox12.Height, pictureBox12.Width);
            this.panel5.Visible = false;
            this.pictureBox11.Visible = true;
         
            this.pictureBox12.Visible = false;
            this.listBox1.Visible = false;
            this.label5.Visible = false;
            this.panel8.Visible = false;
            this.panel12.Visible = false;
            panel5.BringToFront();
            this.label5.BringToFront();
            this.panel8.BringToFront();
            this.panel12.BringToFront();
            this.listBox1.BringToFront();
            this.pictureBox12.BringToFront();
            this.pictureBox11.BringToFront();

        }

        private void macTrackBar2_ValueChanged(object sender, decimal value)
        {
            axWindowsMediaPlayer1.settings.volume = macTrackBar2.Value;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox13, pictureBox13.Height, pictureBox13.Width);
            this.axWindowsMediaPlayer1.settings.volume = 0;
            this.pictureBox13.Visible = false;
            this.pictureBox14.Visible = true;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox14, pictureBox14.Height, pictureBox14.Width);
            this.axWindowsMediaPlayer1.settings.volume = 100;
            this.pictureBox13.Visible = true;
            this.pictureBox14.Visible = false;
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
          
        }

        private void axWindowsMediaPlayer1_DoubleClickEvent(object sender, AxWMPLib._WMPOCXEvents_DoubleClickEvent e)
        {
         /*   if (!enfullscreen)
            {
                enfullscreen = true;
                fullscreen_mediaplayer playy = new fullscreen_mediaplayer();
                playy.Show();
            }else
            {

            }
            */
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            notification_bar lapara = new notification_bar();
            lapara.ShowDialog();
            Thread.Sleep(50);
            axWindowsMediaPlayer1.fullScreen = true;
            axWindowsMediaPlayer1.stretchToFit = true;
          
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
      
            if (e.KeyChar==13)

            {
               string texto2 = textBox1.Text;
            
                string textboxsita = "";
                botongral();
              /*
        

                if (lapara.Count == 0 && textBox1.Text.Length >= 5)
                {
                    textBox1.Text = "";
                    Thread.Sleep(5);
                    textBox1.Text = "Buscando...";
                    textboxsita = agregaralalaista(texto2);
                    if (textboxsita != "%%%nulo%%%")
                    {

                        lapara.Add(textboxsita);
                    string[] partes = textboxsita.Split(' ');

                    string completa = "";
                    for (int i = 0; i < partes.Length; i++)
                    {
                        completa += partes[i] + "+";
                    }

                    string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[0].Split('=')[1]; 
                        // webBrowser1.Navigate(url1);
                        reproducir(laparalink[0]);


                        locanterior = 0;
                    igualador = lapara[0];
                  
                    if (axWindowsMediaPlayer1.settings.volume != 0)
                    {
                        lapara[0] = ">" + igualador + "<";
                    }
                    else
                    {
                        lapara[0] = ">" + igualador + "<";
                    }
                    listBox1.DataSource = null;
                    listBox1.DataSource = lapara;
                    listBox1.SelectedIndex = 0;
                    listBox1.Refresh();
                    anterior = textboxsita;
                    this.textBox1.Text = "";
                    actualizarlista();
                    }
                    else
                    {
                        textBox1.Text = "";
                        MessageBox.Show("No se encontraron resultados");
                    }
                }

                else
                   if (lapara.Count > 0 && textBox1.Text.Length >= 5)
                {
                    textBox1.Text = "";
                    Thread.Sleep(5);
                    textBox1.Text = "Buscando...";
                    textboxsita = agregaralalaista(texto2);
                    if (textboxsita != "%%%nulo%%%")
                    {

                        lapara.Add(textboxsita);
                    string[] partes = textboxsita.Split(' ');

                    string completa = "";
                    for (int i = 0; i < partes.Length; i++)
                    {
                        completa += partes[i] + "+";
                    }
                    lapara[locanterior] = igualador;
                 
                    igualador = textboxsita;
                    locanterior = lapara.IndexOf(igualador);
                    if (axWindowsMediaPlayer1.settings.volume != 0)
                    {
                        lapara[locanterior] = ">" + igualador + "<";
                    }
                    else
                    {
                        lapara[locanterior] = ">" + igualador + "<";
                    }
                    anterior = textboxsita;
                    string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[locanterior];
                        // webBrowser1.Navigate(url1);
                        reproducir(laparalink[locanterior]);
                        listBox1.DataSource = null;
                    listBox1.DataSource = lapara;
                    listBox1.SelectedIndex = locanterior;
         
                    this.textBox1.Text = "";
                    actualizarlista();
                    }
                    else
                    {
                        textBox1.Text = "";
                        MessageBox.Show("No se encontraron resultados");
                    }

                }
                else
                {
                    MessageBox.Show("El texto debe tener almenos 5 caracteres");
                }

            }
          */

        }
        }
        public void morphingnorm()
        {
            pictureBox4.Size = new Size(654, 463);
            pictureBox4.Location = new Point(-1, -1);
            this.Size = new Size(655, 608);
            axWindowsMediaPlayer1.Size = new Size(628, 390);
            axWindowsMediaPlayer1.Location = new Point(12, 24);
            pictureBox1.Size = new Size(112, 64);
            pictureBox1.Location = new Point(15, 10);
            linkLabel1.Visible = true;
            label1.Font = new Font(FontFamily.GenericSansSerif, 14);
            label1.Location = new Point(133, 18);
           
        }
        public void morphingmini()
        {
            if(GR3_UiF.Properties.Settings.Default.caldidad_defecto>0)
            {
                this.WindowState = FormWindowState.Normal;
                pictureBox4.Size = new Size(270, 263);
            pictureBox4.Location = new Point(-1, -1);
            this.Size = new Size(275, 373);
            axWindowsMediaPlayer1.Size = new Size(237, 230);
            axWindowsMediaPlayer1.Location = new Point(13, 10);
            pictureBox1.Size = new Size(60, 60);
            pictureBox1.Location = new Point(3, 7);
            linkLabel1.Visible = false;
            label1.Font = new Font(FontFamily.GenericSansSerif, 10);
                 
            label1.Location = new Point(65, 33);
            }
            else
            {
                pictureBox4.Size = new Size(270, 263);
                pictureBox4.Location = new Point(-1, -1);
                this.Size = new Size(275, 100);
                axWindowsMediaPlayer1.Size = new Size(237, 230);
                axWindowsMediaPlayer1.Location = new Point(13, 10);
                pictureBox1.Size = new Size(60, 60);
                pictureBox1.Location = new Point(3, 7);
                linkLabel1.Visible = false;
                label1.Font = new Font(FontFamily.GenericSansSerif, 10);

                label1.Location = new Point(65, 33);
            }
        }

        private void panel7_Click(object sender, EventArgs e)
        {
          
          if(lapara.Count==0 && textBox1.Text.Length>=5)
            {
                string texto2 = textBox1.Text;
                textBox1.Text = "Agregando...";
                string textboxcopia = agregaralalaista(texto2);
                if (textboxcopia != "%%%nulo%%%")
                {
                    lapara.Add(textboxcopia);
                    string[] partes = textboxcopia.Split(' ');

                    string completa = "";
                    for (int i = 0; i < partes.Length; i++)
                    {
                        completa += partes[i] + "+";
                    }

                    string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[0].Split('=')[1]; 
                  //  webBrowser1.Navigate(url1);
                    reproducir(laparalink[0]);


                    locanterior = 0;
                    igualador = lapara[0];
                    if (axWindowsMediaPlayer1.settings.volume != 0)
                    {
                        lapara[0] = ">" + igualador + "<";
                    }
                    else
                    {
                        lapara[0] = ">" + igualador + "<";
                    }
                    listBox1.DataSource = null;
                    listBox1.DataSource = lapara;
                    listBox1.Refresh();
                    anterior = textboxcopia;
                    this.textBox1.Text = "";
                }
                else
                {
                    textBox1.Text = "";
                    notificarerror("No se encontraron resultados");
                }


            }
          else
          if ( textBox1.Text.Length>=5)
        
            {
                string texto2 = textBox1.Text;
                textBox1.Text = "Agregando...";
                string textboxcopia = agregaralalaista(texto2);
                if (textboxcopia != "%%%nulo%%%")
                {


                    lapara.Add(textboxcopia);
                listBox1.DataSource = null;
                listBox1.DataSource = lapara;
                this.textBox1.Text = "";
                }
                else
                {
                    textBox1.Text = "";
                    notificarerror("No se encontraron resultados");
                }
            }
            else
            {
                notificarerror("El texto debe tener almenos 5 caracteres");
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox15, pictureBox15.Height, pictureBox15.Width);
            try
            {
                if (lapara.Count >= 1 && enproceso == false)
            {


                int loc1 = locanterior;

                if (loc1 >= lapara.Count)
                {

                }
                else
                {
                loc1 = locanterior + 1;
                        listBox1.SelectedIndex = loc1;
                        igualador = lapara[loc1];

                    string sec1 = lapara[loc1];
                    lapara[locanterior] = anterior;
                    anterior = igualador;
                    if (axWindowsMediaPlayer1.settings.volume != 0)
                    {
                          
                           
                            lapara[loc1] = ">" + igualador + "<"; 
                    }
                    else
                    {
                        lapara[loc1] = ">" + igualador + "<";
                    }
                    locanterior = loc1;
                    listBox1.DataSource = null;
                    listBox1.DataSource = lapara;

                    listBox1.Refresh();
                    string[] partes = sec1.Split(' ');
                    string completa = "";
                    for (int i = 0; i < partes.Length; i++)
                    {
                        completa += partes[i] + "+";
                    }
                        axWindowsMediaPlayer1.URL = "";
                    string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[loc1].Split('=')[1];
                        // webBrowser1.Navigate(url1);
                        reproducir(laparalink[loc1]);
                        actualizarlista();
                    }
                  
                }
            }catch(Exception )
            {

            }
        }




        private void pictureBox16_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox16, pictureBox16.Height, pictureBox16.Width);
            try
            {
                if (lapara.Count >= 1&& enproceso == false)
            {


                    int loc1 = locanterior;
                if (loc1 <= 0)
                {
                  
                }
                else
                {
                   loc1 = locanterior - 1;
                        igualador = lapara[loc1];
                        listBox1.SelectedIndex = loc1;
                        string sec1 = lapara[loc1];
                    lapara[locanterior] = anterior;
                    anterior = igualador;
                        if (axWindowsMediaPlayer1.settings.volume != 0)
                        {
                            lapara[loc1] = ">" + igualador + "<";
                        }
                        else
                        {
                            lapara[loc1] = ">" + igualador + "<";
                        }
                        locanterior = loc1;
                    listBox1.DataSource = null;
                    listBox1.DataSource = lapara;

                    listBox1.Refresh();
                    string[] partes = sec1.Split(' ');
                    string completa = "";
                    for (int i = 0; i < partes.Length; i++)
                    {
                        completa += partes[i] + "+";
                    }
                        axWindowsMediaPlayer1.URL = "";
                        string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[loc1].Split('=')[1];
                        // webBrowser1.Navigate(url1);
                        reproducir(laparalink[loc1]);
                    }
            }
            }
            catch(Exception )
            {
               
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }


        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }
      public string quitar_pac(string frase)
        {
            StringBuilder hc = new StringBuilder(frase);
            hc.Remove(0, 1);
            hc.Remove(hc.Length, 1);
            return hc.ToString();


        }

        private void axWindowsMediaPlayer1_Buffering(object sender, AxWMPLib._WMPOCXEvents_BufferingEvent e)
        {
          
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox17, pictureBox17.Height, pictureBox17.Width);
            if (lapara.Count>=1)
            {
                if (this.checkBox1.Checked == false)
            {
                this.checkBox1.Checked = true;
            }
            else
            {
                this.checkBox1.Checked = false;
            }
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
           
            if (lapara.Count >= 1)
            {
                if (this.checkBox2.Checked==false)
            {
                this.checkBox2.Checked = true;
            }
            else
            {
                this.checkBox2.Checked = false;
            }
            }
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
         
            lapara.Clear();
            laparalink.Clear();
            listBox1.DataSource = null;
            listBox1.DataSource = lapara;
            anterior = "";
            igualador = "";
            this.linkLabel1.Text = "";
           this.pictureBox1.ImageLocation = "";
            this.label1.Text = "";
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            locanterior = 0;
            this.pictureBox4.ImageLocation = "";
            axWindowsMediaPlayer1.URL = "";
            actualizartodo();



        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          
           
            try
            {





                foreach (TcpClient cl in clientes)
                {
                    cl.Client.Send(Encoding.Default.GetBytes("cerrar()"));

                }

          //      detenedor = false;
              //  oidor.Stop();
             //   proceso.Abort();
                GR3_UiF.Properties.Settings.Default.tubito2 = "";
                GR3_UiF.Properties.Settings.Default.tubito = "";
                GR3_UiF.Properties.Settings.Default.Save();
             //   lapara.Clear();
             //   listBox1.DataSource = null;
              //  listBox1.DataSource = lapara;
             //   anterior = "";
             //   igualador = "";
             //   this.linkLabel1.Text = "";
             //   this.pictureBox1.ImageLocation = "";
              //  this.label1.Text = "";
              //  axWindowsMediaPlayer1.Ctlcontrols.stop();
              //  locanterior = 0;
              //  this.pictureBox4.ImageLocation = "";
             //   axWindowsMediaPlayer1.URL = "";


            }
            catch (Exception )
            {

            }

    
            Environment.Exit(Environment.ExitCode);

        }

        private void listBox1_Click(object sender, EventArgs e)
        {


            if (GR3_UiF.Properties.Settings.Default.eliminadorabierto == false)
            {
                if (lapara.Count >= 1 && enproceso == false)
                {


                    dialogoeliminar eliii = new dialogoeliminar();
                    eliii.Location = this.Location;
                    string linkcompuesto = laparalink[lapara.IndexOf(listBox1.Text)];
                    eliii.ipadres = ipadre;
                    eliii.indice = lapara.IndexOf(listBox1.Text);
                    eliii.url = laparalink[lapara.IndexOf(listBox1.Text)];
                    eliii.titulo = lapara[lapara.IndexOf(listBox1.Text)];

                    eliii.imagen = linkcompuesto.Split('=')[1];
                    GR3_UiF.Properties.Settings.Default.eliminadorabierto = true;
                    GR3_UiF.Properties.Settings.Default.Save();
                 eliii.Show();
                    /*
                    listBox1.SelectedIndex = lapara.IndexOf(listBox1.Text);
                    int loc1 = lapara.IndexOf(listBox1.Text);


                    if (loc1 >= lapara.Count)
                    {

                    }
                    else
                    {

                        //  if (lapara.IndexOf(igualador) == locanterior)
                        //{
                        //}
                        //else
                        // {
                        //   if (axWindowsMediaPlayer1.settings.volume != 0 )
                        //{
                        //  lapara[loc1] = "♫" + igualador + "<»";
                        //}
                        //else
                        //{
                        //   lapara[loc1] = "♫" + igualador + "<x";
                        //}
                        //}

                    }
                    if(lapara[loc1].StartsWith(">"))
                    {

                         }
                    else
                    {
                        igualador = lapara[loc1];
                        lapara[loc1] = ">" + igualador + "<";
                        string sec1 = lapara[loc1];
                        lapara[locanterior] = anterior;
                        anterior = igualador;
                        locanterior = loc1;
                        listBox1.DataSource = null;
                        listBox1.DataSource = lapara;

                        listBox1.Refresh();
                        string[] partes = sec1.Split(' ');
                        string completa = "";
                        for (int i = 0; i < partes.Length; i++)
                        {
                            completa += partes[i] + "+";
                        }
                        string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[loc1];
                        webBrowser1.Navigate(url1);

                    }

                    listBox1.DataSource = null;
                    listBox1.DataSource = lapara;
                    actualizarlista();*/

                }
            }
       }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox20, pictureBox20.Height, pictureBox20.Width);
            if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
            {
                Asistente_de_conexion asis = new Asistente_de_conexion();
                asis.clientes = clientes;
                asis.ip = ipadre;
                formenpanel(panel9, asis);
            }
            else
            {
                Asistente_de_conexion asis = new Asistente_de_conexion();
                asis.clientes = clientes;
                asis.ip = ipadre;
             //  asis.Location = this.Location;
                asis.Show();
                this.timer4.Enabled = true;
            }
          
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                                 
                                        ////////////////highlighs///////////                                     
       ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      

        private void pictureBox11_MouseEnter(object sender, EventArgs e)
        {
          
            this.pictureBox11.BorderStyle = BorderStyle.FixedSingle;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
         
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle =BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
           
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
         

            this.Refresh();
        }

        private void pictureBox11_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.pictureBox11.BackColor = Color.Black;
            this.Refresh();
        }

        private void pictureBox15_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox15.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
         
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox35.BorderStyle = BorderStyle.None;
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox15_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox9_DragEnter(object sender, DragEventArgs e)
        {
          
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox9.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
           
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
           
            this.pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox9_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox16_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox16.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
        
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox16_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox17_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox17.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
           
            this.pictureBox18.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
          
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox17_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox18_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox18.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
          
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox35.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox18_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox19_MouseEnter(object sender, EventArgs e)
        {

           
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
         
            pictureBox34.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox19_MouseLeave(object sender, EventArgs e)
        {
           
            this.Refresh();
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox14.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
         
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
         
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox13_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox13.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
        
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
           
            this.pictureBox12.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
           
            pictureBox35.BorderStyle = BorderStyle.None;
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox13_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox13.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
           
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox35.BorderStyle = BorderStyle.None;
            pictureBox32.BorderStyle = BorderStyle.None;

            this.Refresh();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox5.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
         
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
          
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox35.BorderStyle = BorderStyle.None;
           
            pictureBox34.BorderStyle = BorderStyle.None;
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox6_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox6.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
         
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox8.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
  this.pictureBox20.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
           
            this.pictureBox18.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.panel4.BorderStyle = BorderStyle.None;
          
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }
        public bool encontroparecido(string link, List<string> listalinks)
        {
            bool encontro = false;
    foreach(string ee in listalinks)
            {
                if (ee.Split('=')[1] == link.Split('=')[1])
                {
                    encontro = true;
                }
            }
            if (encontro)
            {
               
                return true;
            }

            else
            {

                return false;
            }
        }
        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox20_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox20.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
 
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
       
            pictureBox35.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox20_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox7.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
           
        
  this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
           
            pictureBox35.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
         
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            this.panel4.BorderStyle = BorderStyle.FixedSingle;
       
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
        
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
         
            pictureBox34.BorderStyle = BorderStyle.None;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox17.BorderStyle = BorderStyle.None;
       
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox10.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
          
            this.Refresh();
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            this.panel4.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox10_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox17.BorderStyle = BorderStyle.None;
       
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {

            this.pictureBox10.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox12_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
        
            this.pictureBox12.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
        
            this.pictureBox18.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox33.BorderStyle = BorderStyle.None;
        
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////                                 
        ////////////////highlighs end ///////////                                     
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void actualizarlista()
            
        {
            List<TcpClient> clientesesbackup = new List<TcpClient>();




            string listaenlinea = "";
            string listaenlinea2 = "";
            for (int i = 0; i < lapara.Count; i++)
            {
                string perfectastring = lapara[i].Replace('$', ' ');

                listaenlinea += perfectastring + ";";
            }
            for (int i = 0; i < laparalink.Count; i++)
            {
                string perfectastring = laparalink[i].Replace('$', ' ');
                listaenlinea2 += perfectastring + ";";
            }

            foreach (TcpClient c in clientes)
            {

              
                if (SocketExtensions.IsConnected(c)==true )
            {


                    c.Client.Send(Encoding.Default.GetBytes("links()><;" + listaenlinea2));
                    Thread.Sleep(150);
                    c.Client.Send(Encoding.Default.GetBytes(listaenlinea));
                   

                    clientesesbackup.Add(c);

                }
               
            }
           
            clientes = clientesesbackup;

        }
        public void actualizarcaratula()

        {
            List<TcpClient> clientesesbackup = new List<TcpClient>();
            foreach (TcpClient c in clientes)
            {

                if (SocketExtensions.IsConnected(c) == true )
            {


                string colortostr = ColorTranslator.ToHtml(GR3_UiF.Properties.Settings.Default.Color_app);
                c.Client.Send(Encoding.Default.GetBytes("caratula()><;" + pictureBox1.ImageLocation + ";" + anumasisierto + ";" + colortostr+ ";"+zelda));
                    clientesesbackup.Add(c);


            }
            }
           clientes = clientesesbackup;

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
          
           
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.panel3.Location = new Point(-306, 1);
            foreach(Control prr in panel1.Controls)
            {
                if(prr.Size==new Size(271, 60))
                {
                    prr.Location = new Point(panel2.Size.Width - 286, 105);
                }
            }

        }
        public  void actualizartodo()
        {

            string listaenlinea = "";
            string listaenlinea2 = "";
            List<TcpClient> clientesesbackup = new List<TcpClient>();
            for (int i = 0; i < lapara.Count; i++)
            {
                string perfectastring = lapara[i].Replace('$', ' ');

                listaenlinea += perfectastring + ";";
            }
            for (int i = 0; i < laparalink.Count; i++)
            {
                string perfectastring = laparalink[i].Replace('$', ' ');
                listaenlinea2 += perfectastring + ";";
            }

            foreach (TcpClient c in clientes)
            {
               
              
                if (SocketExtensions.IsConnected(c) == true )
                {








               
                    c.Client.Send(Encoding.Default.GetBytes("links()><;" + listaenlinea2));
                    Thread.Sleep(150);
                    c.Client.Send(Encoding.Default.GetBytes(listaenlinea));
                    Thread.Sleep(1000);
                    string colortostr = ColorTranslator.ToHtml(GR3_UiF.Properties.Settings.Default.Color_app);

                    c.Client.Send(Encoding.Default.GetBytes("caratula()><;" + pictureBox1.ImageLocation + ";" + anumasisierto.Replace('$',' ') + ";" + colortostr + ";" + zelda));

                    clientesesbackup.Add(c);


                }
            }
            clientes = clientesesbackup;
         


     
        
        }

        private void axWindowsMediaPlayer1_ClickEvent(object sender, AxWMPLib._WMPOCXEvents_ClickEvent e)
        {
            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                this.pictureBox9.Visible = false;
                this.pictureBox10.Visible = true;

            }
            else
                if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPaused)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                this.pictureBox9.Visible = true;
                this.pictureBox10.Visible = false;
            }
            else
                 if (this.axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
                this.pictureBox9.Visible = true;
                this.pictureBox10.Visible = false;

            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_MouseMoveEvent(object sender, AxWMPLib._WMPOCXEvents_MouseMoveEvent e)
        {
        
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox21, pictureBox21.Height, pictureBox21.Width);


            Load_playlist cargar = new Load_playlist();
            cargar.lista = lapara;
            cargar.listalinks = laparalink;
            cargar.localizacion =new Point(((int)this.Size.Height/2), (((int)this.Size.Width / 2)));
            cargar.Show();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
          
         
            Save_playlist save = new Save_playlist();
            save.listica = lapara;
                save.listicalinks = laparalink;
            save.Location = this.Location;
            save.Show();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void metroProgressSpinner1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox21_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
         
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
        
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.FixedSingle;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox22_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
       
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox23_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
         
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
         
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            pictureBox21.BorderStyle = BorderStyle.None;
     
        }

        private void pictureBox22_MouseLeave(object sender, EventArgs e)
        {

        }
        private void pictureBox23_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
           
            delete_playlist plaaaylist = new delete_playlist();
            plaaaylist.Show();
            plaaaylist.Location = this.Location;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
         
        }

        private void pictureBox24_MouseDown(object sender, MouseEventArgs e)
        {
           
            if (textBox1.TextLength >= 2)
            {
                StringBuilder ss = new StringBuilder(textBox1.Text);
                ss.Remove(textBox1.TextLength -2, 2);
                textBox1.Text = ss.ToString();
            }
            else
            if(textBox1.TextLength==1)
            {
                textBox1.Text = "";
            }
        }
        public void limpiarui()
        {
            this.linkLabel1.Text = "";
            this.pictureBox1.ImageLocation = "";
            this.label1.Text = "";   
            this.pictureBox4.ImageLocation = "";
            axWindowsMediaPlayer1.URL = "";
   
        }

        private void timer7_Tick_1(object sender, EventArgs e)
        {
            StringBuilder sv = new StringBuilder(textBox1.Text);
            if (textBox1.TextLength > 0) {
                sv.Remove(textBox1.Text.Length-1, 1);
            }
            textBox1.Text = sv.ToString();

        }
        public void formenpanel(Control panelz,Form laparaz)
        {
          foreach(Form f in panel10.Controls)
            {
                f.Close();
            }
           panel11.BackColor= GR3_UiF.Properties.Settings.Default.color_barra;
            panelz.Size =new Size(this.Size.Height, this.Height );
           panel10.Size =new Size (this.Size.Height - 50, this.Height - 50);
            panelz.Visible = true;          
            laparaz.FormBorderStyle = FormBorderStyle.None;
            laparaz.TopLevel = false;
            laparaz.AutoScroll = false;
        
    
           // laparaz.Anchor = panel10.Anchor;
            panel10.Controls.Add(laparaz);
         
            laparaz.Show();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            this.timer4.Enabled = true;
            panel9.Visible = false;
            panel9.Size = new Size(1, 1);
           


        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////condicion1/////////////////////////////////
            if (GR3_UiF.Properties.Settings.Default.Navegadorn == true)
            {
                if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
                {
                    Webbrowser navegador = new Webbrowser();
                    formenpanel(panel9, navegador);
                }
                else
                {
                    Webbrowser navegador = new Webbrowser();
                    navegador.Show();
                    this.timer4.Enabled = true;
                }

            }
            /////////////////////////////////condicion2///////////////////////////////////
            else
            {
                if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
                {
                    Customwebbrowser navega2r = new Customwebbrowser();
                    formenpanel(panel9, navega2r);
                }
                else
                {
                    Customwebbrowser navega2r = new Customwebbrowser();
                    navega2r.Show();
                    this.timer4.Enabled = true;
                }

            }
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
            {
                configuraciones lapara = new configuraciones();
                formenpanel(panel9, lapara);
            }
            else
            {
                configuraciones lapara = new configuraciones();
                lapara.Show();
                this.timer4.Enabled = true;
            }
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            if (this.label1.Text == "")
            {
                notificarerror("Por favor reproduzca un video");

            }
            else
            {
                if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
                {
                    Downloader2 descalgador = new Downloader2();
                    descalgador.link = this.linkLabel1.Text;
                    descalgador.titulo = anumasisierto;
                    descalgador.imgurl = this.pictureBox1.ImageLocation;
                    descalgador.modoenform = true;
                   
                    formenpanel(panel9, descalgador);
                }
                else
                {
                    Downloader2 descalgador = new Downloader2();
                    descalgador.link = this.linkLabel1.Text;
                    descalgador.titulo = anumasisierto;
                    descalgador.imgurl = this.pictureBox1.ImageLocation;
                    descalgador.Show();
                    this.timer4.Enabled = true;
                }

            }
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
            {
                Asistente_de_conexion asis = new Asistente_de_conexion();
                asis.clientes = clientes;
                asis.ip = ipadre;
                formenpanel(panel9, asis);
            }
            else
            {
                Asistente_de_conexion asis = new Asistente_de_conexion();
                asis.clientes = clientes;
                asis.ip = ipadre;
                asis.Show();
                this.timer4.Enabled = true;
            }
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.ventanaenventana == true)
            {
                Configs conf = new Configs();
                formenpanel(panel9, conf);
            }
            else
            {
                Configs conf = new Configs();
                conf.Show();
                this.timer4.Enabled = true;
            }

        }
    public string agregaralalaista(string nombrepuro)
        {
            try
            {

          
            WebClient gestordownload = new WebClient();

            string url1 = "https://www.youtube.com/watch?v=" + gestordownload.DownloadString("https://decapi.me/youtube/videoid?search=" + nombrepuro.Replace(' ','+'));

      
            Geteartitulo titulillo = new Geteartitulo();
         
            string posible1= titulillo.GetVideoTitle(titulillo.LoadJson(url1));
            
                if (posible1.Trim() != "")
            {
                    laparalink.Add(url1);
                    return posible1;

            }
            else
            {
                    return "%%%nulo%%%";
            }
            }
            catch (Exception)
            {
                return "%%%nulo%%%";

            }


        }
        public string obtenernombreylink(string nombrepuro)
        {
            try
            {


                WebClient gestordownload = new WebClient();

                string url1 = "http://www.youtube.com/watch?v=" + gestordownload.DownloadString("https://decapi.me/youtube/videoid?search=" + nombrepuro.Replace(' ', '+'));


                Geteartitulo titulillo = new Geteartitulo();

                string posible1 = titulillo.GetVideoTitle(titulillo.LoadJson(url1));

                if (posible1.Trim() != "")
                {
               
                    return posible1+ "¤"+url1;

                }
                else
                {
                    return "%%%nulo%%%";
                }
            }
            catch (Exception)
            {
                return "%%%nulo%%%";

            }


        }
        private void pictureBox32_Click(object sender, EventArgs e)
        {

            canim.animar(pictureBox32, pictureBox32.Height, pictureBox32.Width);
        if (lapara.Count > 0) { 
          Minireproductor reproductor = new Minireproductor();
            reproductor.ip = ipadre;
                reproductor.Show();
                GR3_UiF.Properties.Settings.Default.miniplayeron = true;
            //    reproductor.Location = this.Location;
                GR3_UiF.Properties.Settings.Default.Save();
                this.timer4.Enabled = true;
  
            }
            else
            {
                notificarerror("Necesita almenos 1 elemento reproduciendo para abrir");
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
         
        }

        private void axWindowsMediaPlayer1_KeyPressEvent(object sender, AxWMPLib._WMPOCXEvents_KeyPressEvent e)
        {
  
         
        }

        private void axWindowsMediaPlayer1_KeyUpEvent(object sender, AxWMPLib._WMPOCXEvents_KeyUpEvent e)
        {
            if (e.nKeyCode == 70 && label3.Text.Trim().Length > 0 && GR3_UiF.Properties.Settings.Default.caldidad_defecto != 0)
            {
                if (axWindowsMediaPlayer1.fullScreen == true)
                {
                    axWindowsMediaPlayer1.fullScreen = false;
                }
                else
                {
                    axWindowsMediaPlayer1.fullScreen = true;
                }

            }
        }
        public void actualizarlistareproduccion()
        {

            List<TcpClient> clientesesbackup = new List<TcpClient>();
            string[] items = Directory.GetFiles(Application.StartupPath + @"\Saved_playlist");

          
            foreach (TcpClient c in clientes)
            {
                string listaenlinea = "";
                for (int i = 0; i < items.Length; i++)
                {
                    listaenlinea += Path.GetFileNameWithoutExtension(items[i]) + ";";

                }
                if (SocketExtensions.IsConnected(c) == true)
                {

                   
                    string colortostr = ColorTranslator.ToHtml(GR3_UiF.Properties.Settings.Default.Color_app);
                    c.Client.Send(Encoding.Default.GetBytes("caratula()><;" + pictureBox1.ImageLocation + ";" + anumasisierto.Replace('$',' ') + ";" + colortostr + ";" + zelda));
                    
                    Thread.Sleep(100);
                  

                    listaenlinea = listaenlinea.Remove(listaenlinea.Length - 1, 1);
                    listaenlinea = RemoveIllegalPathCharacters(listaenlinea);
                    c.Client.Send(Encoding.Default.GetBytes("listar()><;" + listaenlinea));
                    clientesesbackup.Add(c);


                }
            }
            clientes = clientesesbackup;

         
        }
      public void reproducirlalista(int indice)
        {
            string listainterna;
            string[] items = Directory.GetFiles(Application.StartupPath + @"\Saved_playlist");
          
            string name = Path.GetFileNameWithoutExtension(items[indice]);
                
          StreamReader  tupara = File.OpenText(Application.StartupPath + @"\Saved_playlist\" + name);
           listainterna =tupara.ReadLine();
           
           string listilla1 = listainterna.Split('$')[0];
            StringBuilder sb = new StringBuilder(listilla1);
            sb.Remove(sb.Length - 1, 1);
            listilla1 = sb.ToString();
            string listilla2 = listainterna.Split('$')[1];         
            string[] partes = listilla1.Split(';');
            
            int indez = 0;
            foreach (string it in partes)
            {
             
                if (it.StartsWith(">"))
                {
                    string papu = it;
                    StringBuilder ee = new StringBuilder(papu);
                    ee.Replace('>', ' ');
                    ee.Replace('<', ' ');

                    partes.SetValue(ee.ToString(), indez);

                 
                }

                indez++;
            }
            string[] partes2 = listilla2.Split(';');
            lapara.Clear();
            laparalink.Clear();
            var casi = partes2.ToList();
            casi.RemoveAt(casi.Count-1);
            lapara = partes.ToList();
            laparalink = casi;

            /////////////////////////////////////////////////////////////////          
            axWindowsMediaPlayer1.URL = ""; 
            string url1 = "https://decapi.me/youtube/videoid?search=" + laparalink[0];
            //webBrowser1.Navigate(url1);
            reproducir(laparalink[0]);


            locanterior = 0;
            igualador = lapara[0];

            if (axWindowsMediaPlayer1.settings.volume != 0)
            {
                lapara[0] = ">" + igualador + "<";
            }
            else
            {
                lapara[0] = ">" + igualador + "<";
            }

             anterior = igualador;
            listBox1.DataSource = null;
            listBox1.DataSource = lapara;
            actualizarlista();


        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox32_DragEnter(object sender, DragEventArgs e)
        {
            pictureBox32.BorderStyle = BorderStyle.None;
        }

        private void pictureBox32_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox17.BorderStyle = BorderStyle.None;
         
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
        
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
        
            pictureBox34.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
          
            pictureBox33.BorderStyle = BorderStyle.None;
            pictureBox32.BorderStyle = BorderStyle.FixedSingle;
            this.Refresh();
        }

        private void pictureBox32_DragLeave(object sender, EventArgs e)
        {
            pictureBox32.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void listBox1_DataSourceChanged(object sender, EventArgs e)
        {
            GR3_UiF.Properties.Settings.Default.locanterior = locanterior;
            GR3_UiF.Properties.Settings.Default.Save();
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            notificarerror("Esto no es un error");
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            canim.animar(pictureBox33, pictureBox33.Height, pictureBox33.Width);
            formsincronizacion sync = new formsincronizacion();
          //  sync.Location = this.Location;
            sync.Show();
            this.timer4.Enabled = true;
          
        }

        private void pictureBox33_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox17.BorderStyle = BorderStyle.None;
           
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
          
            pictureBox35.BorderStyle = BorderStyle.None;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.FixedSingle;
            this.Refresh();
        }

        private void pictureBox33_MouseLeave(object sender, EventArgs e)
        {
            pictureBox33.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
          
        }


        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
          
          
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            if (linkLabel1.Text != "") 
            {
                //  webBrowser1.Navigate("https://decapi.me/youtube/videoid?search=" + linkLabel1.Text);
                reproducir(linkLabel1.Text);
            }
            else
            {
                notificarerror("Por favor reproduzca un elemento");
            }

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            var etrin = "";
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3"))
            {
                etrin = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
            }

            if (etrin.Length > 20)
            {
                Formlistadescarga ff = new Formlistadescarga();
                ff.Show();
                ff.Location = this.Location;
                this.timer4.Enabled = true;
            }else
            {
                notificarerror("No se han descargado elementos para presentar");
            }

           
        }




        private void pictureBox35_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox17.BorderStyle = BorderStyle.None;
          
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.FixedSingle;
  
            this.Refresh();
        }

        private void pictureBox35_MouseLeave(object sender, EventArgs e)
        {
            pictureBox35.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox34_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox10.BorderStyle = BorderStyle.FixedSingle;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            
            this.pictureBox12.BorderStyle = BorderStyle.None;
            this.pictureBox4.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox7.BorderStyle = BorderStyle.None;
            this.pictureBox20.BorderStyle = BorderStyle.None;
            this.pictureBox8.BorderStyle = BorderStyle.None;
            this.pictureBox6.BorderStyle = BorderStyle.None;
            this.pictureBox3.BorderStyle = BorderStyle.None;
            this.pictureBox5.BorderStyle = BorderStyle.None;
            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
            this.pictureBox14.BorderStyle = BorderStyle.None;
          
            this.pictureBox18.BorderStyle = BorderStyle.None;
            this.pictureBox17.BorderStyle = BorderStyle.None;
            this.pictureBox16.BorderStyle = BorderStyle.None;
            this.pictureBox9.BorderStyle = BorderStyle.None;
            this.pictureBox15.BorderStyle = BorderStyle.None;
            this.pictureBox11.BorderStyle = BorderStyle.None;
            pictureBox21.BorderStyle = BorderStyle.None;
           
            pictureBox32.BorderStyle = BorderStyle.None;
            pictureBox33.BorderStyle = BorderStyle.None;
            pictureBox35.BorderStyle = BorderStyle.None;
            pictureBox34.BorderStyle = BorderStyle.FixedSingle;

            this.Refresh();
        }

        private void pictureBox34_MouseLeave(object sender, EventArgs e)
        {
            pictureBox34.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        public bool nocontienequerry(string querrystring)
        {
            if (querrystring.Contains("fullscreen()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("notificar()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("eliminarelemento()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("pedirlista()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("playpause()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("recall()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("vol+()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("vol-()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("actualizarlistaactual()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("actualizarplaylist()"))
            {
                return true;
            }
            else
                 if (querrystring.Contains("caratula()"))
            {
                return true;
            }
            else
                    if (querrystring.Contains("next()"))
            {
                return true;
            }
            else
                    if (querrystring.Contains("pedirindice()"))
            {
                return true;
            }
            else
                    if (querrystring.Contains("actualizarlalista()"))
            {
                return true;
            }
            else
                    if (querrystring.Contains("back()"))
            {
                return true;
            }
            else
                    if (querrystring.Contains("actual+()"))
            {
                return true;
            }
            else
                   if (querrystring.Contains("actual-()"))
            {
                return true;
            }
            else
                   if (querrystring.Contains("agregar()"))
            {
                return true;
            }
            else

                if (querrystring.Contains("descvid360()"))
            {
                return true;
            }
            else
             if (querrystring.Contains("descvid720()"))
            {
                return true;
            }
            else
             if (querrystring.Contains("descmp3()"))
            {
                return true;
            }
            else
            {

                return false;
            }


        }

        private void pictureBox19_Click_1(object sender, EventArgs e)
        {
            fullscreen_mediaplayer playy = new fullscreen_mediaplayer();
            playy.ipadre = ipadre;
            playy.Show();
            this.panel5.Visible = false;
            this.pictureBox11.Visible = true;

            this.pictureBox12.Visible = false;
            this.listBox1.Visible = false;
            this.label5.Visible = false;
            this.panel8.Visible = false;
            this.panel12.Visible = false;
            panel5.BringToFront();
            this.label5.BringToFront();
            this.panel8.BringToFront();
            this.panel12.BringToFront();
            this.listBox1.BringToFront();
            this.pictureBox12.BringToFront();
            this.pictureBox11.BringToFront();


        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}










