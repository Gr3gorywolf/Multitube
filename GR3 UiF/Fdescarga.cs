using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Net;
using VideoLibrary;
namespace GR3_UiF
{
  
    public partial class Fdescarga : Form
    {
        public string pathdescargadoselect="";
      
        public string link = "";
        public string direccion;
        public Thread proc;
        public string imagen;
        public string nombre;
        public int calidad;
       
        public string vidomp3;
        public WebClient downloader = new WebClient();
        public bool endescarga;
        bool existe;
        public bool cancelado = false;
     
        public Thread proc2;
        public int startPosX = Screen.PrimaryScreen.WorkingArea.Width - Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width- Screen.PrimaryScreen.WorkingArea.Width*0.001);
        public int startPosY = Screen.PrimaryScreen.WorkingArea.Height - Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height- Screen.PrimaryScreen.WorkingArea.Height*0.50);
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0001;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
     
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
       
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public Fdescarga()
        {
            InitializeComponent();

            string video2 = "";
            string title = "";
           
           

        }

        private void Fdescarga_Load(object sender, EventArgs e)
        {
            GR3_UiF.Properties.Settings.Default.Descargando = true;
            GR3_UiF.Properties.Settings.Default.Save();
         pictureBox1.ImageLocation = imagen;
            proc = new Thread(new ThreadStart(buscar));
           proc.Start();
            if (GR3_UiF.Properties.Settings.Default.lugar_descarga == "")
            {
                direccion = Application.StartupPath + @"\descargas";
            }
            else
            {
                direccion = GR3_UiF.Properties.Settings.Default.lugar_descarga;
            }
          
            SetWindowPos(this.Handle, HWND_TOPMOST, startPosX, startPosY, 7, 7, TOPMOST_FLAGS);

            downloader.Credentials = new NetworkCredential("anonymous", "");
            downloader.Encoding = Encoding.UTF8;
        }
        public void buscar()
        {
            try {
          //  videoInfos = DownloadUrlResolver.GetDownloadUrls(link.Trim(), false);
                /////////////////////////////////////////////////////////////////////////////////
                if (vidomp3 == "video" && calidad > 0 && link.Contains("http"))
                {
                    //  videoInfos = DownloadUrlResolver.GetDownloadUrls(link.Trim(), false);
                  //  searcher.GetAllVideos(link.Trim());
                    descargavid();
                }
                else
               if (link.Contains("http"))
                {
                  //  videoInfos = DownloadUrlResolver.GetDownloadUrls(link.Trim(), false);
                    descargam();
                }
                else
                {
                    descarftp(link);
                }
            }
          
            catch (Exception e)
            {
                MessageBox.Show("error al descargar por favor intente de nuevo "+e.Message+link);
                this.Close();
            }


        }
        public void descargam()
        {


            //  videox = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 0);

            string title = "";
            string video2 = "";
            using (var videito = Client.For(YouTube.Default))
            {
                var videoo = videito.GetAllVideosAsync(link);
                var resultados = videoo.Result;
                title = resultados.First().Title.Replace("- YouTube", "");

                // video2 = resultados.First(info => info.Resolution == -1 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;

                ///  video2 = resultados.First(info => info.Resolution == 240 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
          

                video2 = resultados.First(info => info.Resolution == -1 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;

            }

            try
            {
               
                if (video2 =="")
                { MessageBox.Show("video invalido"); }
                else
                {
                  /*
                    descvideo2 = new VideoDownloader(videox, Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3"));

                    descvideo2.DownloadProgressChanged += (enviador, args) => progrssessBar1.Value = Convert.ToInt32(args.ProgressPercentage);
                    descvideo2.DownloadProgressChanged += (enviador, args) => this.label1.Text=Convert.ToInt32(args.ProgressPercentage).ToString() + "%";

                    pathdescargadoselect = Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3");

                   descvideo2.DownloadFinished += (sen, args) =>
                    {
                        progrssessBar1.Value = 0;
                        if (File.Exists("Downloadlog.gr3a"))
                        {


                           if(decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp3") == false) { 
                            string contenido = File.ReadAllText("Downloadlog.gr3a")  + RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "$");

                            File.Delete("Downloadlog.gr3a");
                            var aa = File.CreateText("Downloadlog.gr3a");
                            aa.Write(contenido);
                            aa.Close();

                            }
                        }
                        else
                        {
                            if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp3") == false)
                            {
                                var aa = File.CreateText("Downloadlog.gr3a");
                                string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "$");
                                aa.Write(contenido);
                                aa.Close();
                            }


                        }








                        if (GR3_UiF.Properties.Settings.Default.rutaalterna == true)

                        {
                            try
                            {
                                File.Copy(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3"), Path.Combine(GR3_UiF.Properties.Settings.Default.rutaalternastr, RemoveIllegalPathCharacters(videox.Title) + ".mp3"));
                                MessageBox.Show("archivo copiado");
                            }
                            catch (Exception )
                            {

                            }
                            //proc2 = new Thread(() => { copiar(); });                     
                            //proc2.Start();

                        }
                        Thread pr = new Thread(new ThreadStart(laconversion));
                        pr.IsBackground = true;
                        pr.Start();


                    };

                    proc = new Thread(() => { descvideo2.Execute(); });
                    proc.IsBackground = true;
                    proc.Start();
                    endescarga = true;*/
                  
                     downloader.DownloadFileAsync(new Uri( video2), Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp4"));
                    
                    endescarga = true;
                    downloader.DownloadFileCompleted += (aa, aaa) =>
                    {
                        if (!aaa.Cancelled) {

                            this.progrssessBar1.Value = Convert.ToInt32(100);
                            pathdescargadoselect = Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp3");
                            endescarga = false;
                            /*  if (File.Exists("Downloadlog.gr3a"))
                              {
                                  if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp3") == false)
                                  {
                                      string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "$");
                                      File.Delete("Downloadlog.gr3a");
                                      var aas = File.CreateText("Downloadlog.gr3a");
                                           (contenido);
                                      aas.Close();
                                  }
                              }
                              else
                              {

                                  if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp3") == false)
                                  {
                                      var aasss = File.CreateText("Downloadlog.gr3a");
                                      string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "$");
                                      aasss.Write(contenido);
                                      aasss.Close();
                                  }
                              }*/
                            if (!File.Exists(Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3"))
                            {
                                var prro = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                                prro.Write(RemoveIllegalPathCharacters(title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp3") + "$");
                                prro.Close();
                            }
                            else
                                 if (!decirladvd(RemoveIllegalPathCharacters(title) + ".mp3"))
                            {
                                string contenido = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                                var prro = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                                prro.Write(contenido + RemoveIllegalPathCharacters(title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp3") + "$");
                                prro.Close();
                            }

                           
                               
                            if (GR3_UiF.Properties.Settings.Default.rutaalterna == true)

                            {
                                try
                                {
                                    File.Copy(Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp3"), Path.Combine(GR3_UiF.Properties.Settings.Default.rutaalternastr, RemoveIllegalPathCharacters(title) + ".mp3"));
                                    MessageBox.Show("archivo copiado");
                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show(e.Message);
                                    var prro = e;
                                }
                                endescarga = false;
                            } 
                       }
                        else
                        {
                            downloader.Dispose();
                        }
                        laconversion(title);
                    };
                    downloader.DownloadProgressChanged += (aa, aaa) =>
                    {
                      
                      
                            this.progrssessBar1.Value = Convert.ToInt32(aaa.ProgressPercentage);
                        this.label1.Text = Convert.ToInt32(aaa.ProgressPercentage).ToString() + "%";
                     
                    };





                }

                }
            catch (Exception e )
            {
                var prro = e;
                MessageBox.Show(e.Message);
                MessageBox.Show("No se pudo descargar intente de nuevo");
                this.Close();

            }
        }
    

        public bool decirladvd(string nombrecompleto)
        {
            bool identify = false;
       
            var archivo = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");

            if (archivo.Length > 2) { 
            List <string> aa = archivo.Split('$').ToList();
         
            foreach (string prrin in aa)
            {
                if (prrin.Split('¤')[0].Contains(nombrecompleto))
                    {
                    identify = true;


                    }
                 
            }
            }
            if (identify == false)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        public void laconversion(string titulo)
        {
            if (cancelado==false)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.pictureBox2.Visible = false;
                });

                var inputfile =new MediaToolkit.Model.MediaFile {Filename= Path.Combine(direccion, RemoveIllegalPathCharacters(titulo)) + ".mp4" };
                var outputfile= new MediaToolkit.Model.MediaFile { Filename= Path.Combine(direccion, RemoveIllegalPathCharacters(titulo)) + ".mp3" };
                MediaToolkit.Options.ConversionOptions prro = new MediaToolkit.Options.ConversionOptions();
                prro.VideoFps = 0;
                prro.CustomHeight = 0;
                prro.CustomWidth = 0;
                prro.VideoAspectRatio = MediaToolkit.Options.VideoAspectRatio.R3_2;
                using (var engine=new MediaToolkit.Engine())
                {
                    engine.CustomCommand("-threads 1");
                    engine.GetMetadata(inputfile);
                engine.Convert(inputfile, outputfile);
                }
                File.Delete(Path.Combine(direccion, RemoveIllegalPathCharacters(titulo)) + ".mp4");
              //  var aaa = new NReco.VideoConverter.FFMpegConverter();
              //   aaa.ConvertMedia(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) ) + ".mp3", Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) ) + ".mp33", "mp3");

                //   File.Delete(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) ) + ".mp3");
                // File.Move(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title)) + ".mp33", Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title)) + ".mp3");

                //    File.Delete(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title)) + ".mp33");


                this.Invoke((MethodInvoker)delegate
                {
                    this.pictureBox2.Visible = true;
                    this.pictureBox2.Location = new Point(37, 114);
                    this.pictureBox3.Visible = true;
                    this.pictureBox3.Location = new Point(7, 114);

                });
            }
        }
        public void laconversion2(string titulo)
        {
            if (cancelado == false)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.pictureBox2.Visible = false;
                });

                var inputfile = new MediaToolkit.Model.MediaFile { Filename = Path.Combine(direccion,titulo.Replace(".mp3",".mp4")) };
                var outputfile = new MediaToolkit.Model.MediaFile { Filename = Path.Combine(direccion, titulo) };
                MediaToolkit.Options.ConversionOptions prro = new MediaToolkit.Options.ConversionOptions();
                prro.VideoFps = 0;
                prro.CustomHeight = 0;
                prro.CustomWidth = 0;
                prro.VideoAspectRatio = MediaToolkit.Options.VideoAspectRatio.R3_2;
                using (var engine = new MediaToolkit.Engine())
                {
                    engine.CustomCommand("-threads 1");
                    engine.GetMetadata(inputfile);
                    engine.Convert(inputfile, outputfile);
                }
                File.Delete(Path.Combine(direccion, titulo.Replace(".mp3", ".mp4")));
                //  var aaa = new NReco.VideoConverter.FFMpegConverter();
                //   aaa.ConvertMedia(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) ) + ".mp3", Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) ) + ".mp33", "mp3");

                //   File.Delete(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) ) + ".mp3");
                // File.Move(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title)) + ".mp33", Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title)) + ".mp3");

                //    File.Delete(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title)) + ".mp33");


                this.Invoke((MethodInvoker)delegate
                {
                    this.pictureBox2.Visible = true;
                    this.pictureBox2.Location = new Point(37, 114);
                    this.pictureBox3.Visible = true;
                    this.pictureBox3.Location = new Point(7, 114);

                });
            }
        }
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            string pelin = r.Replace(path, "");
            pelin = pelin.Replace('$', ' ');
            pelin = pelin.Replace('¤', ' ');
            return pelin;
        }
        public void descargavid()
        {

           // try { 
           // videox = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == calidad);
            string title = "";
            string video2 = "";
            using (var videito = Client.For(YouTube.Default))
            {
                var videoo = videito.GetAllVideosAsync(link);
                var resultados = videoo.Result;
                title = resultados.First().Title.Replace("- YouTube", "");

                // video2 = resultados.First(info => info.Resolution == -1 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;

                ///  video2 = resultados.First(info => info.Resolution == 240 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                int calidad2 =calidad;
                if (calidad2 == 0)
                {
                    calidad2 = -1;
                }

                try
                {
                    video2 = resultados.First(info => info.Resolution == calidad2 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                }
                catch (Exception)
                {
                    try
                    {
                        calidad2 = 360;
                        video2 = resultados.First(info => info.Resolution == 360 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            calidad2 = 240;
                            video2 = resultados.First(info => info.Resolution == 240 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                        }
                        catch (Exception)
                        {
                            calidad2 = -1;
                            video2 = resultados.First(info => info.Resolution == -1 && info.AudioFormat == AudioFormat.Aac).GetUriAsync().Result;
                        }
                    }
                }
            }

          
            if (video2 == "")
            { MessageBox.Show("video invalido"); }
            else
            {

                    /*
                descvideo = new VideoDownloader(video, Path.Combine(direccion, RemoveIllegalPathCharacters(video.Title) + video.VideoExtension));
                descvideo.DownloadProgressChanged += (enviador, args) => this.progrssessBar1.Value = Convert.ToInt32(args.ProgressPercentage);
                descvideo.DownloadProgressChanged += (enviador, args) => this.label1.Text = Convert.ToInt32(args.ProgressPercentage).ToString()+"%";
                descvideo.DownloadFinished += (enviador, args) => progrssessBar1.Value = 0;
                    pathdescargadoselect = Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp4");

                    descvideo.DownloadFinished += (naa, naaa)=>{
                
                    if (File.Exists("Downloadlog.gr3a"))
                    {
                        if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp4") == false)
                        {
                            string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + video.VideoExtension + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + video.VideoExtension + "$");
                            File.Delete("Downloadlog.gr3a");
                            var aa = File.CreateText("Downloadlog.gr3a");
                            aa.Write(contenido);
                            aa.Close();
                        }
                    }
                    else
                    {
                        
                        if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp4") == false)
                        {
                            var aa = File.CreateText("Downloadlog.gr3a");
                            string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + video.VideoExtension + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + video.VideoExtension + "$");
                            aa.Write(contenido);
                            aa.Close();
                        }
                    }
                    endescarga = false;
                        this.Invoke((MethodInvoker)delegate {
                            this.pictureBox2.Location = new Point(37, 114);
                            this.pictureBox3.Visible = true;
                            this.pictureBox3.Location = new Point(7, 114);
                        });

                    };
                proc = new Thread(() => { descvideo.Execute(); });
                proc.IsBackground = true;
                proc.Start();
                    endescarga = true;
                    */

                    downloader.DownloadFileAsync(new Uri( video2), Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp4"));
                endescarga = true;
                downloader.DownloadFileCompleted += (aa, aaa) =>
                    {
                        if (!aaa.Cancelled)
                        {

                   
                        this.progrssessBar1.Value = Convert.ToInt32(100);

                        pathdescargadoselect = Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp4");
                            /* if (File.Exists("Downloadlog.gr3a"))
                             {
                                 if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp4") == false)
                                 {
                                     string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + ".mp4" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + videox.VideoExtension + "$");
                                     File.Delete("Downloadlog.gr3a");
                                     var aas = File.CreateText("Downloadlog.gr3a");
                                     aas.Write(contenido);
                                     aas.Close();
                                 }
                             }
                             else
                             {

                                 if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp4") == false)
                                 {
                                     var aasss = File.CreateText("Downloadlog.gr3a");
                                     string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + videox.VideoExtension + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + videox.VideoExtension + "$");
                                     aasss.Write(contenido);
                                     aasss.Close();
                                 }
                             }*/
                            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +@"\downloadlog.gr3"))
                            {
                                var prro = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                                prro.Write(RemoveIllegalPathCharacters(title) + ".mp4" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp4") + "$");
                                prro.Close();
                            }
                            else
                              if (!decirladvd(RemoveIllegalPathCharacters(title) + ".mp4"))
                            {
                                string contenido =File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                                var prro = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                                prro.Write(contenido+ RemoveIllegalPathCharacters(title) + ".mp4" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp4") + "$");
                                prro.Close();
                            }

                           
                        
                            this.Invoke((MethodInvoker)delegate
                        {
                            this.pictureBox2.Location = new Point(37, 114);
                            this.pictureBox3.Visible = true;
                            this.pictureBox3.Location = new Point(7, 114);
                        });

                            if (GR3_UiF.Properties.Settings.Default.rutaalterna == true)

                            {
                                try
                                {
                                    File.Copy(Path.Combine(direccion, RemoveIllegalPathCharacters(title) + ".mp3"), Path.Combine(GR3_UiF.Properties.Settings.Default.rutaalternastr, RemoveIllegalPathCharacters(title) + ".mp3"));
                                    MessageBox.Show("archivo copiado");
                                }
                                catch (Exception)
                                {

                                }
                                endescarga = false;
                            }
                        }
                        else
                        {
                            downloader.Dispose();
                        }
                    };
                    downloader.DownloadProgressChanged += (aa,aaa)=>
                    {
                       
                        this.progrssessBar1.Value = Convert.ToInt32(aaa.ProgressPercentage);
                        this.label1.Text = Convert.ToInt32(aaa.ProgressPercentage).ToString() + "%";
                   
                    };
                }
            }
            /*catch (Exception e)
            {
                MessageBox.Show("error al descargar el archivo"+e.Message+e.TargetSite+e.Source+calidad);
                this.Close();
            }*/
           // }

public void copiar()
        {
          
        }

        private void progrssessBar1_MouseEnter(object sender, EventArgs e)
        {
       
        }

        private void Fdescarga_MouseEnter(object sender, EventArgs e)
        {
        
        }

        private void Fdescarga_MouseLeave(object sender, EventArgs e)
        {
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {


                if (endescarga==true)
                {
                    cancelado = true;
                    downloader.CancelAsync();

                    this.Close();
                }
                else
                {
                    this.Close();
                }
                   

                
        
     

            }
            catch (Exception)
            {
                this.Close();
            }
        }

        private void progrssessBar1_MouseLeave(object sender, EventArgs e)
        {
          
          
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
        //    this.pictureBox2.Visible = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
        ///    this.pictureBox2.Visible = false;
        }

        private void Fdescarga_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", "/select," + pathdescargadoselect);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (endescarga == false)
            {
                System.Diagnostics.Process.Start(pathdescargadoselect);
            }
        }

        public void descarftp(string linkarchivo)
        {

      




            /*
            descvideo2 = new VideoDownloader(videox, Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3"));

            descvideo2.DownloadProgressChanged += (enviador, args) => progrssessBar1.Value = Convert.ToInt32(args.ProgressPercentage);
            descvideo2.DownloadProgressChanged += (enviador, args) => this.label1.Text=Convert.ToInt32(args.ProgressPercentage).ToString() + "%";

            pathdescargadoselect = Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3");

           descvideo2.DownloadFinished += (sen, args) =>
            {
                progrssessBar1.Value = 0;
                if (File.Exists("Downloadlog.gr3a"))
                {


                   if(decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp3") == false) { 
                    string contenido = File.ReadAllText("Downloadlog.gr3a")  + RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "$");

                    File.Delete("Downloadlog.gr3a");
                    var aa = File.CreateText("Downloadlog.gr3a");
                    aa.Write(contenido);
                    aa.Close();

                    }
                }
                else
                {
                    if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp3") == false)
                    {
                        var aa = File.CreateText("Downloadlog.gr3a");
                        string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "$");
                        aa.Write(contenido);
                        aa.Close();
                    }


                }








                if (GR3_UiF.Properties.Settings.Default.rutaalterna == true)

                {
                    try
                    {
                        File.Copy(Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3"), Path.Combine(GR3_UiF.Properties.Settings.Default.rutaalternastr, RemoveIllegalPathCharacters(videox.Title) + ".mp3"));
                        MessageBox.Show("archivo copiado");
                    }
                    catch (Exception )
                    {

                    }
                    //proc2 = new Thread(() => { copiar(); });                     
                    //proc2.Start();

                }
                Thread pr = new Thread(new ThreadStart(laconversion));
                pr.IsBackground = true;
                pr.Start();


            };

            proc = new Thread(() => { descvideo2.Execute(); });
            proc.IsBackground = true;
            proc.Start();
            endescarga = true;*/
            bool esvideo = false;
            if (nombre.EndsWith(".mp4"))
            {
                esvideo = true;
            }
            if (!esvideo)
            {
           
                downloader.DownloadFileAsync(new Uri(linkarchivo), Path.Combine(GR3_UiF.Properties.Settings.Default.lugar_descarga,RemoveIllegalPathCharacters( nombre.Replace(".mp3", ".mp4"))));
            }else
            {
                downloader.DownloadFileAsync(new Uri(linkarchivo), Path.Combine(GR3_UiF.Properties.Settings.Default.lugar_descarga,removerto( nombre)));
            }
          
            endescarga = true;
            downloader.DownloadFileCompleted += (aa, aaa) =>
            {
                if (!aaa.Cancelled)
                {
                  

                    this.progrssessBar1.Value = Convert.ToInt32(100);
                    pathdescargadoselect = Path.Combine(direccion, removerto(nombre));
                    endescarga = false;
                    /*  if (File.Exists("Downloadlog.gr3a"))
                      {
                          if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp3") == false)
                          {
                              string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "$");
                              File.Delete("Downloadlog.gr3a");
                              var aas = File.CreateText("Downloadlog.gr3a");
                                   (contenido);
                              aas.Close();
                          }
                      }
                      else
                      {

                          if (decirladvd(RemoveIllegalPathCharacters(videox.Title) + ".mp3") == false)
                          {
                              var aasss = File.CreateText("Downloadlog.gr3a");
                              string contenido = File.ReadAllText("Downloadlog.gr3a") + RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "¤" + link + "¤" + Path.Combine(direccion, RemoveIllegalPathCharacters(videox.Title) + ".mp3" + "$");
                              aasss.Write(contenido);
                              aasss.Close();
                          }
                      }*/

                    if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3"))
                    {
                        var prro = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                        prro.Write(removerto(nombre) + "¤" + "https://www.youtube.com/watch?v=" + imagen.Split('/')[4] + "¤" + Path.Combine(direccion,removerto(nombre)) + "$");
                        prro.Close();
                    }
                    else
                                 if (!decirladvd( removerto(nombre)))
                    {
                        string contenido = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                        var prro = File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
                        prro.Write( contenido+removerto( nombre) + "¤" + "https://www.youtube.com/watch?v=" +imagen.Split('/')[4] + "¤" + Path.Combine(direccion, removerto(nombre)) + "$");
                        prro.Close();
                    }
                    if (GR3_UiF.Properties.Settings.Default.rutaalterna == true)

                    {
                        try
                        {
                            File.Copy(Path.Combine(direccion, nombre), Path.Combine(GR3_UiF.Properties.Settings.Default.rutaalternastr, nombre));
                            MessageBox.Show("archivo copiado");
                        }
                        catch (Exception)
                        {

                        }
                        endescarga = false;
                    }
                }
                else
                {
                    downloader.Dispose();
                }
                if (!esvideo)
                {
                    laconversion2(removerto(nombre));
                }else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.pictureBox2.Visible = true;
                        this.pictureBox2.Location = new Point(37, 114);
                        this.pictureBox3.Visible = true;
                        this.pictureBox3.Location = new Point(7, 114);

                    });
                }
               
            };


        
            downloader.DownloadProgressChanged += (aa, aaa) =>
            {


                this.progrssessBar1.Value = Convert.ToInt32(aaa.ProgressPercentage);
                this.label1.Text = Convert.ToInt32(aaa.ProgressPercentage).ToString() + "%";

            };





        }





        public string removerto(string klk)
        {
           
            var aa = RemoveIllegalPathCharacters(klk);
            aa = aa.Replace('$', ' ').Replace('¤', ' ');


            return aa;
        }


    }
}



