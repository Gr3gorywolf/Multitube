using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ftpcliente;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using servidorftp;
using ZXing;
using FluentFTP;
using prueba_de_lista_generica;
namespace GR3_UiF
{
    public partial class formsincronizacion : MaterialSkin.Controls.MaterialForm
    {
  
        public string ipadre;
        public string nombrecliente = "";
        public string ipcliente = "";
        public string directoriocliente = "";
        public string playlistemporalnombres = "";
        public string playlistemporallinks = "";
        public string listaactualnombres = "";
        public string listaactuallinks = "";
        public string nombrelistaactual = "";
        public bool hacervisiblelistas = false;
        public bool mensajeroactivo = false;
        public bool ponerplayer = false;
        public List<string> listasservidor = new List<string>();
        public TcpListener servidorarchivos;
        int puertoaleatorio2 = 0;
        public bool detenedor = true;
        public int noitemes = 0;
        public List <string> listasreprodcliente = new List<string>();
        Random rondom = new Random();
        Thread proc;
        Thread proc2;
        int puertoaleatorio = 0;
        TcpClient c;
        TcpClient c2;
        TcpListener oidor;
        public List<string> listacopia= new List<string>();
        public List<string> listacopiacliente = new List<string>();
        public List<ListViewItem> listaitemes = new List<ListViewItem>();
        public List<ListViewItem> listaitemesiz = new List<ListViewItem>();
        public formsincronizacion()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void formsincronizacion_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            pictureBox3.Visible = false;
           
            actualizaryo();
            listView2.View = View.Tile;
            listView1.View = View.Tile;
            puertoaleatorio = rondom.Next(1024, 3000);
          puertoaleatorio2 = rondom.Next(1024, 3000);
            BarcodeWriter escritor = new BarcodeWriter();
            escritor.Options = new ZXing.Common.EncodingOptions
            {
                Height = 600,
                Width = 600
            };
            escritor.Format = BarcodeFormat.QR_CODE;
            pictureBox4.Image = escritor.Write(getearip() +";"+puertoaleatorio);

            servidorarchivos = new TcpListener(IPAddress.Any, puertoaleatorio2);
            servidorarchivos.Start();
            oidor = new TcpListener(IPAddress.Any,puertoaleatorio);
            oidor.Start();
            metroLabel5.Text = Environment.MachineName;
           proc = new Thread(new ThreadStart(oir));
            proc.IsBackground = true;
            proc.Start();
            proc2 = new Thread(new ThreadStart(cojerarchivo));
            proc2.IsBackground = true;
            proc2.Start();


        }

        public void actualizarcliente()
        {
          
            listView2.Clear();
            listaitemesiz.Clear();
            listacopiacliente.Clear();
      foreach(string a in listasreprodcliente)
            {
                ListViewItem lvitem = new ListViewItem();
                lvitem.Text = a;
                lvitem.ImageIndex = 0;
              listView2.Items.Add(lvitem);
                listacopiacliente.Add(a);
                listaitemesiz.Add(lvitem);
            }
     

        }
        public string getearip()
        {
            IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
            string ipadree = "";
            foreach (IPAddress ip in localIPs)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {

                    ipadree = ip.ToString();
                    

                }


            }
            return ipadree;
        }

        public void actualizaryo()
        {
         
            listView1.Clear();
            listasservidor.Clear();
            listaitemes.Clear();
            listacopia.Clear();
            foreach (string i in Directory.GetFiles(Application.StartupPath + @"\Saved_playlist"))
            {
                ListViewItem item = new ListViewItem();
                item.Text =Path.GetFileNameWithoutExtension( i);
                listacopia.Add(Path.GetFileNameWithoutExtension(i));
                item.ImageIndex = 0;
                listView1.Items.Add(item);
                listasservidor.Add(i);
            
                listaitemes.Add(item);
            }
          

        }

        public void cojerarchivo() {


            while (c2 == null)
            {
                c2 = servidorarchivos.AcceptTcpClient();
            }
         
        
         
            bool cojio = false;
            byte[] buffer = new byte[120000];
            var strim = c2.GetStream();
            int o = 0;
            string lalistacompletita = "";
            mensajeroactivo = true;
            while (true)
            {

       
            while (strim.DataAvailable)
            {
                o = strim.Read(buffer, o, buffer.Length);
                lalistacompletita += Encoding.UTF8.GetString(buffer, 0, o);
            
                cojio = true;
            }
            if (cojio == true)
            {
                StreamWriter sw =File.CreateText(Application.StartupPath + @"\Saved_playlist\" + nombrelistaactual);
                sw.WriteLine(lalistacompletita);
                sw.Close();
                
                    cojio = false;
                    buffer = new byte[120000];
                   strim = c2.GetStream();
                   o = 0;
                   lalistacompletita = "";
                    actualizaryo();

                }
                Thread.Sleep(100);
            }

        }






        public void oir()
        {
            bool recibiendolista = false;
         




            while (c==null)
            {
                c = oidor.AcceptTcpClient();
            }

            NetworkStream stream = c.GetStream();
            byte[] buffering = new byte[120000];
            int tamaño = 0;

         
            hacervisiblelistas = true;
            c.Client.Send(Encoding.UTF8.GetBytes("conectarservidor$" + puertoaleatorio2 + ";" + getearip().ToString()));
            
            try {
            while ((tamaño = stream.Read(buffering, 0,buffering.Length)) != 0 && c.Client.Connected==true && detenedor==true){

                string captured = Encoding.UTF8.GetString(buffering, 0, tamaño);
                    string tipo = captured.Split('$')[0];
                if (captured.Length > 0 && tipo=="Data" && recibiendolista==false)
                {
                       
                    nombrecliente = captured.Split('$')[1];
                    ipcliente = captured.Split('$')[2];
                        directoriocliente = captured.Split('$')[3];
                        metroLabel4.Text = nombrecliente;
                  
                    }
                else
                        if(captured.Length>0 && tipo == "Listas" && recibiendolista == false)
                    {
                    
                        listasreprodcliente = captured.Split('$')[1].Split(';').ToList();
                        listasreprodcliente.RemoveAt(listasreprodcliente.Count - 1);

                        actualizarcliente();


                    }
                    else
                        if (captured.Length > 0 && tipo == "desconectarse" && recibiendolista == false)
                    {

                        this.Close();

                    }
                    else
                     if (captured.Length > 0 && tipo == "Elementos" && recibiendolista == false)
                    {

                   
                      
                        this.metroLabel9.Text =int.Parse( captured.Split('$')[1])-1+" Elementos";
                        


                    }
                    else
                    if (captured.Length > 0 && tipo == "Nombrelista" && recibiendolista == false)
                    {
                        nombrelistaactual = captured.Split('$')[1];                      
                    }
                    else
                    if (captured.Length > 0 && tipo == "listaactual" && recibiendolista == false)
                    {
                      
                        playlistemporalnombres = captured.Split('$')[1];
                        playlistemporallinks = captured.Split('$')[2];
                    
                     playlistemporalnombres = playlistemporalnombres.Remove(playlistemporalnombres.Length-1 , 1);
                       playlistemporallinks = playlistemporallinks.Remove(playlistemporallinks.Length-1 , 1);
                        this.metroLabel12.Text = playlistemporallinks.Split(';').Length+"  Elementos";
                        ponerplayer = true;
                        captured = "";
                    }






                }
            }
            catch (Exception e)
            {
             DialogResult rr=   MessageBox.Show("Ocurrio un problema  desea salir??"+e.Message,"",MessageBoxButtons.YesNo);
                if (rr == DialogResult.Yes)
                {
                    this.Close();
                }
                else
                {

                }

            }

            }

     

        private void pictureBox3_Click(object sender, EventArgs e)
        {
         
            GR3_UiF.Properties.Settings.Default.lista = playlistemporalnombres;
            GR3_UiF.Properties.Settings.Default.listalinks = playlistemporallinks;
            GR3_UiF.Properties.Settings.Default.Save();
        }

        private void formsincronizacion_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void listView2_DragDrop(object sender, DragEventArgs e)
        {

            e.Effect = DragDropEffects.Move;
        }

        private void listView2_DragEnter(object sender, DragEventArgs e)
        {
           
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {

            listView1.DoDragDrop(listView1.SelectedItems, DragDropEffects.Copy);
      

        }

        private void listView1_Click(object sender, EventArgs e)
        {

         
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

         

        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            List<string> archivos = new List<string>();
        
            foreach (string i in Directory.GetFiles(Application.StartupPath + @"\Saved_playlist"))
            {
                archivos.Add(i);
            }
            var elementoactual = archivos[listacopia.IndexOf(e.Item.Text)];
            StreamReader sr = new StreamReader(elementoactual);
            noitemes = sr.ReadLine().Split('$')[0].Split(';').Length;
            pictureBox5.Visible = true;
            metroLabel6.Visible = true;
            metroLabel8.Visible = true;
            metroLabel8.Text = noitemes-1 + " Elementos";
        }

        private void listView2_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try
            {
              
                c.Client.Send(Encoding.UTF8.GetBytes("gettearelementos$" + listasreprodcliente.IndexOf(e.Item.Text)));
                this.metroLabel7.Visible = true;
                this.metroLabel9.Visible = true;
                mmg.Visible = true;
            }
            catch(Exception z)
            {
                MessageBox.Show(z.Message);
                listasreprodcliente.Clear();
                listView1.Clear();
               notificarerror("Error al sincronizar con el dispositivo....La ventana se cerrara");
                this.Close();
              
            }
          
      

        }

        private void formsincronizacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (c != null && SocketExtensions.IsConnected(c))
            {
                c.Client.Send(Encoding.UTF8.GetBytes("desconectarse$  "));
                c.Client.Disconnect(false);
            }
            if (c2 != null && SocketExtensions.IsConnected(c2))
            {
                c2.Client.Disconnect(false);
            }
            detenedor = false;
    

         

        }

        private void mmg_Click(object sender, EventArgs e)
        {
            try {
                
                nombrelistaactual = listView2.SelectedItems[0].Text;
            c.Client.Send(Encoding.UTF8.GetBytes("recibirlista$" + listacopiacliente.IndexOf(listView2.SelectedItems[0].Text)));
            }
            catch (Exception)
            {
              notificarerror("Ocurrio un problema al enviar la lista al cliente");
            }
            this.metroLabel7.Visible = false;
            this.metroLabel9.Visible = false;
            mmg.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            try
            {
                var elementoactual = listasservidor[listacopia.IndexOf(listView1.SelectedItems[0].Text)];

                if (c2.Client.Connected == true && c.Client.Connected==true)
            {
                    c.Client.Send(Encoding.UTF8.GetBytes("nombrelista$"+Path.GetFileNameWithoutExtension(elementoactual)));

                    c2.Client.Send(Encoding.UTF8.GetBytes(File.ReadAllText(elementoactual)));
            }
            }
            catch (Exception)
            {
             
              notificarerror("Ocurrio un problema al enviar la lista al cliente");
            }
            pictureBox5.Visible = false;
            metroLabel6.Visible = false;
            metroLabel8.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
         
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hacervisiblelistas)
            {
                listView1.Visible = true;
                listView2.Visible = true;
                pictureBox2.Visible = true;
                pictureBox1.Visible = true;
                this.MaximumSize = new Size(786, 523);
                this.MinimumSize = new Size(786, 523);
                this.Size = new Size(786, 523);
                pictureBox4.Visible = false;
                metroLabel1.Visible = false;
                metroLabel2.Visible = false;


                metroLabel4.Visible = true;
                metroLabel5.Visible = true;
                hacervisiblelistas = false;
               
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (mensajeroactivo)
            {
                c.Client.Send(Encoding.UTF8.GetBytes("minombre$" + Environment.MachineName));
                Thread.Sleep(50);
                c.Client.Send(Encoding.UTF8.GetBytes("listareprodactual$" + Environment.MachineName));
              
              
                mensajeroactivo = false;
            }
            if (ponerplayer)
            {
                this.pictureBox3.Visible = true;

                this.metroLabel10.Visible = true;
                this.metroLabel12.Visible = true;
                ponerplayer = false;
            }
         
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
       
        }

        public void notificarerror(string texto)
        {
            foreach (Control aa in this.Controls)
            {
                if (aa.Size == new Size(271, 60))
                {
                    this.Invoke((MethodInvoker)delegate {
                        this.Controls.Remove(aa);// runs on UI thread
                    });

                }
            }
            var prri = new MonoFlat.MonoFlat_NotificationBox();
            prri.Location = new Point(this.Size.Width - 286, 65);
            prri.Size = new Size(271, 60);
            prri.Image = GR3_UiF.Properties.Resources.youtube_logo;
            prri.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Error;
            prri.RoundCorners = true;
            prri.Anchor = AnchorStyles.Top;
            prri.Anchor = AnchorStyles.Right;
            this.Invoke((MethodInvoker)delegate {
                this.Controls.Add(prri);// runs on UI thread
            });
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
                    this.Invoke((MethodInvoker)delegate {
                        this.Controls.Remove(aa);// runs on UI thread
                    });

                }
            }
            var prri = new MonoFlat.MonoFlat_NotificationBox();
            prri.Location = new Point(this.Size.Width - 286,65);
            prri.Size = new Size(271, 60);
            prri.Image = GR3_UiF.Properties.Resources.youtube_logo;
            prri.NotificationType = MonoFlat.MonoFlat_NotificationBox.Type.Success;
            prri.RoundCorners = true;
            prri.Anchor = AnchorStyles.Top;
            prri.Anchor = AnchorStyles.Right;
            this.Invoke((MethodInvoker)delegate {
                this.Controls.Add(prri);// runs on UI thread
            });
            prri.BringToFront();
            prri.BringToFront();
            prri.BringToFront();
            prri.Text = texto;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
      
            listView1.Items.Clear();
            foreach (var a in listaitemes)
            {
                if (a.Text.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listView1.Items.Add(a);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            foreach (var a in listaitemesiz)
            {
                if (a.Text.ToLower().Contains(textBox2.Text.ToLower()))
                {
                    listView2.Items.Add(a);
                }
            }
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
