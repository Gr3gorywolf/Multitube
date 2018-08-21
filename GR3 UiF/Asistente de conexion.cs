using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZXing;
using System.Net.Sockets;
using prueba_de_lista_generica;


namespace GR3_UiF
{
  
    public partial class Asistente_de_conexion : MaterialSkin.Controls.MaterialForm
    {
       
       public List<TcpClient> clientes = new List<TcpClient>();
        public string ip = "";
        public Asistente_de_conexion()
        {
            InitializeComponent();
        }
        
        private void Asistente_de_conexion_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            foreach (var cli in clientes)
            {
                if (SocketExtensions.IsConnected(cli)== true) { 
                listBox1.Items.Add("📱=" + cli.Client.RemoteEndPoint.ToString());
                }
            }
            if(GR3_UiF.Properties.Settings.Default.lenguaje=="spa")
            {
                this.label1.Text = "para conectar al servidor introduce:";
                this.label3.Text = "O escanea el siguiente codigo";
                this.label4.Text = "Clientes conectados:";
            }
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                this.label1.Text = "To connect to server enter:";
                this.label3.Text = "Or scan the following code";
                this.label4.Text = "Connected clients:";
            }
            label2.Text = ip;
            pictureBox1.Image = GetQRCode();
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
            return writer.Write(ip);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

            if(this.Size!= new Size(680, 450))
            {
                this.MaximumSize= new Size(680, 450);
                this.Size = new Size(680, 450);
            }
            else
            {
                this.MaximumSize = new Size(346, 450);
                this.Size = new Size(346, 450);
            }
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
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

