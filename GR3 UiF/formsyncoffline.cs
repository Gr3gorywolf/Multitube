using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mooftpserv;
using System.IO;
using System.Net.Sockets;
using System.Net;
using FluentFTP;
using System.Threading;
using ZXing;
namespace GR3_UiF
{
    public partial class formsyncoffline : MaterialSkin.Controls.MaterialForm
    {


        public int cantbytesreceiving;
        Random rondon = new Random();
        public bool ensubida = false;
        public bool enbajada = false;
        bool detenedor = true;
        public Server servidorftp;
        public TcpListener servidorquerry;
        public TcpClient clientequerry;
        FtpClient clienteftp = new FtpClient();
        public string nombrearchivo;
        public string linkarchivo;
        public string supath = "";
        int mipuertoarchivo = 0;
        int mipuertoquerry = 0;
        string ipdelotro = "";
        string miip = "";
        string pathimagenesdelotro = "";
        string mipathimagenes = Application.StartupPath + @"\portraits\";
        int puertoquerrydelotro = 0;
        int puertoarchivosdelotro = 0;
        public List<ListViewItem> listaitemes = new List<ListViewItem>();
        Formlistadescarga instancia =(Formlistadescarga) Application.OpenForms["Formlistadescarga"];

        public formsyncoffline()
        {
            InitializeComponent();
        }

        private void formsyncoffline_Load(object sender, EventArgs e)
        {
            mipuertoquerry = rondon.Next(21, 6000);
            mipuertoarchivo = rondon.Next(25, 6000);
            servidorquerry = new TcpListener(IPAddress.Any, mipuertoquerry);
            servidorquerry.Start();
            miip = gettearip();
            this.pictureBox1.Image = GetQRCode();
         
            new Thread(() =>
            {
                servidorhabladera(false);
            }).Start();
            foreach (ListViewItem it in instancia.listView1.Items)
            {
                listaitemes.Add((ListViewItem)it.Clone());
                listView1.Items.Add((ListViewItem)it.Clone());
            }
            foreach (Image it in instancia.imageList1.Images)
            {
                imageList1.Images.Add((Image)it.Clone());
            }
        
            
            servidorftp = new Server();
            servidorftp.LocalPort = mipuertoarchivo;
            servidorftp.LocalAddress = IPAddress.Parse(miip);
            servidorftp.LogHandler = new DefaultLogHandler(false);
            servidorftp.AuthHandler = new DefaultAuthHandler();
            servidorftp.FileSystemHandler = new DefaultFileSystemHandler();
            servidorftp.BufferSize = 1000000;

            new Thread(() =>
            {
                servidorftp.Run();
            }).Start();




        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems[0].Text.Length>0){
                DialogResult dialogo = MessageBox.Show("Desea enviar  el elemento: " + instancia.nombreses[instancia.nombreses.IndexOf(listView1.SelectedItems[0].Text)] + " al cliente??", "", MessageBoxButtons.YesNo);
                if (dialogo == DialogResult.Yes)
                {
                   
                enviararchivo(instancia.nombreses[instancia.nombreses.IndexOf(listView1.SelectedItems[0].Text)], instancia.linkeses[instancia.nombreses.IndexOf(listView1.SelectedItems[0].Text)], instancia.patheses[instancia.nombreses.IndexOf(listView1.SelectedItems[0].Text)]);
                }
            }
          
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

           
            return writer.Write(miip + "¤" + mipuertoquerry + "¤" + mipuertoarchivo + "¤" + GR3_UiF.Properties.Settings.Default.lugar_descarga.Replace(@"\", "/") + "¤" + mipathimagenes.Replace(@"\", "/"));
        }

        public void enviararchivo(string nombrearchivo, string linkarchivo, string patharchivo)
        {

            clientequerry.Client.Send(Encoding.UTF8.GetBytes("mediadata()¤" + nombrearchivo + "¤" + linkarchivo + "¤" + patharchivo.Replace(@"\", "/")));


         

            ////////////////////////////////////////////////////////////////




            //  clientearchivo.Client.Send(archivoenbytes);






        }

        public void servidorhabladera(bool tenemostodo)
        {
            if (!tenemostodo)
            {
                try
                {
                    clientequerry = servidorquerry.AcceptTcpClient();
                }
                catch (Exception)
                {

                }

            }
            if (clientequerry.Connected)
            {
                int cantidadbytes = 0;
                var stream = clientequerry.GetStream();
                byte[] losbits = new byte[2000000];
                string querrystring = "";
                this.MinimumSize = new Size(388, 593);
                this.MaximumSize=new Size(388, 593);
                this.Size = new Size(388,593);
                while (detenedor)
                {
                    if (clientequerry.Connected)
                    {
                        while (stream.DataAvailable)
                        {
                            cantidadbytes = stream.Read(losbits, 0, losbits.Length);
                            querrystring += Encoding.UTF8.GetString(losbits, 0, cantidadbytes);
                        }

                        if (querrystring.StartsWith("mediadata()"))
                        {
                            nombrearchivo = querrystring.Split('¤')[1];
                            linkarchivo = querrystring.Split('¤')[2];
                            string patharchivo = querrystring.Split('¤')[3];
                            new Thread(() =>
                            {
                                descargame(nombrearchivo, linkarchivo, patharchivo);
                            }).Start();
                        }
                        else
                         if (querrystring.StartsWith("dataserver()"))
                        {
                            ipdelotro = querrystring.Split('¤')[1];
                            puertoquerrydelotro = int.Parse(querrystring.Split('¤')[2]);
                            puertoarchivosdelotro = int.Parse(querrystring.Split('¤')[3]);

                            ///  RunOnUiThread(() => Toast.MakeText(this, "me conecte", ToastLength.Long).Show());                    
                            supath = querrystring.Split('¤')[4];
                            pathimagenesdelotro = querrystring.Split('¤')[5];

                            //   clientearchivo.Client.Connect(ipdelotro, puertoarchivosdelotro);



                        }
                        else
                       if (querrystring.StartsWith("acabamos"))
                        {
                            instancia.cargartodoafter();
                            this.Close();
                        }
                        querrystring = "";
                        cantidadbytes = 0;
                        stream = clientequerry.GetStream();
                        losbits = new byte[2000000];

                    }
                    querrystring = "";
                    Thread.Sleep(40);
                }
            }
        }
        public string gettearip()
        {
            string klk = "";
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress ip in localIPs)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {

                    klk = ip.ToString();
                }
            }
            return klk;
        }
        public void descargame(string nombrearchivo, string linkarchivo, string patharchivo)
        {

            if (!Directory.Exists("portraits"))
            {
                Directory.CreateDirectory("portraits");
            }
            DialogResult dialogo = MessageBox.Show("Desea recibir  el elemento: " + nombrearchivo + " del cliente??", "", MessageBoxButtons.YesNo);
            if (dialogo == DialogResult.Yes)
            {

                try { 
                WebClient cliente = new WebClient();
                cliente.Credentials = new NetworkCredential("anonymous", "");
                cliente.Encoding = Encoding.UTF8;
                cliente.DownloadFile(@"ftp://" + ipdelotro + ":" + puertoarchivosdelotro + pathimagenesdelotro + "/" + linkarchivo.Split('=')[1], @"portraits\" + linkarchivo.Split('=')[1] + ".jpg");
                // @"portraits/" + linkeses[nombreses.IndexOf(listView1.SelectedItems[0].Text)].Split('=')[1] + ".jpg"

                GR3_UiF.Properties.Settings.Default.daemond = "https://i.ytimg.com/vi/" + linkarchivo.Split('=')[1] + "/mqdefault.jpg" + "¤" + @"ftp://" + ipdelotro + ":" + puertoarchivosdelotro + patharchivo + "¤" + nombrearchivo + "¤" + 0 + "¤" + "";
                GR3_UiF.Properties.Settings.Default.Save();
                }
                catch (Exception)
                {
                     dialogo = MessageBox.Show("Error al descargar desea intentar de nuevo?" ,"", MessageBoxButtons.YesNo);
                    if (dialogo == DialogResult.Yes)
                    {
                        descargame(nombrearchivo, linkarchivo, patharchivo);
                    }
                }
            }
        }
        // this.Close();










        private void formsyncoffline_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                servidorftp.Stop();
            if (clientequerry.Connected)
            {
                clientequerry.Client.Send(Encoding.ASCII.GetBytes("acabamos"));
                    instancia.cargartodoafter();
            }
            }
            catch (Exception)
            {

            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (var a in listaitemes)
            {
                if (a.Text.ToLower().Contains(materialSingleLineTextField1.Text.ToLower()))
                {
                    listView1.Items.Add(a);
                }
            }
        }
    }
}
