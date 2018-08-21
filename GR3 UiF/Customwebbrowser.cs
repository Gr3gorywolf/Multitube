using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoutubeSearch;
using System.IO;
using System.Net;
using System.Threading;
using System.Text.RegularExpressions;

namespace GR3_UiF
{
    public partial class Customwebbrowser : MaterialSkin.Controls.MaterialForm
    {
        public bool buscando = false;
        public int index = 0;
        public List<prueba_de_lista_generica.Videos> vireos;
        public bool parar = false;
        public string termino;
        public Customwebbrowser()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (buscando == false)
            {
                parar = true;
                Thread proceso = new Thread(new ThreadStart(buscar));
                termino = textBox1.Text;
                textBox1.Text = "";
                proceso.Start();
            }
        }

        private void Customwebbrowser_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            metroListView1.SmallImageList = imageList1;
            metroListView1.View = View.List;
          
              
        
        }
        public void buscar()
        {
            buscando = true;
           
            if (metroListView1.Items.Count > 0)
            {
                metroListView1.Items.Clear();
                vireos.Clear();
                imageList1.Images.Clear();
            }
            VideoSearch buscavideos = new VideoSearch();
            vireos = new List<prueba_de_lista_generica.Videos>();
          
          
          
           
           
            index = 0;         
           
            foreach (var ec in buscavideos.SearchQuery(termino, 2))
            {

                if (parar == true)
                { 


                    prueba_de_lista_generica.Videos video = new prueba_de_lista_generica.Videos();
                video.nombre =limpiarstrings( ec.Title);
                video.url = ec.Url;
                video.tiempo = ec.Duration;
                Byte[] biteimagen = new WebClient().DownloadData(ec.Thumbnail);

                using (MemoryStream memoria = new MemoryStream(biteimagen))
                {
                    video.imagen = Image.FromStream(memoria);
                }
                vireos.Add(video);
                imageList1.Images.Add(video.imagen);
                ListViewItem item = new ListViewItem();
                item.ImageIndex = index;
                item.Text =limpiarstrings( RemoveIllegalPathCharacters(ec.Title));

             
                metroListView1.Items.Add(item);

              
              
                   
              
                index++;
                }

            }
            parar = false;
            if (vireos.Count == 0)
            {
                notificarerror("No se encontraron resultados");
            }
            /*
            if (index >= 10)
            {
                metroScrollBar1.MaximumSize = metroListView1.MaximumSize;
                metroScrollBar1.LargeChange = 70;
            }
            else
            if (index >= 25)
            {
                metroScrollBar1.MaximumSize = metroListView1.MaximumSize;
                metroScrollBar1.LargeChange = 50;
            }
            else
                  if (index >= 50)
            {
                metroScrollBar1.MaximumSize = metroListView1.MaximumSize;
                metroScrollBar1.LargeChange = 10;
            }*/


                //  metroListView1.Visible = true;
                //this.metroProgressSpinner1.Visible = false;
            
            buscando = false;
        }
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }

        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        /*
            try
            {
                metroListView1.SetScrollPosition(metroScrollBar1.Value);

            }
            catch (Exception)
            {

            }*/
        }
        public string limpiarstrings(string limpieza)
        {
            return limpieza.Replace("quot;", "").Replace("amp;", "");
        }
        private void metroListView1_MouseClick(object sender, MouseEventArgs e)
        {
            int indice = metroListView1.SelectedItems[0].ImageIndex;
            customdialog dialogo = new customdialog();
            dialogo.Location = this.Location;
            string[] cadenita2 = vireos[indice].url.Split('=');
            dialogo.imagen = cadenita2[1]; 
            dialogo.url = vireos[indice].url;

            dialogo.ShowDialog();
           
        }

        private void metroListView1_ScrollPositionChanged(MetroFramework.Controls.MetroListView listview, int pos)
        {

        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
           this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            this.Refresh();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
           this.pictureBox1.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        { if (buscando == false) { 
            parar = true;
               
                Thread proceso = new Thread(new ThreadStart(buscar));
                termino = "";
                textBox1.Text = "";
                proceso.Start();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 13)
            {
                if (buscando==false)
                { 
                parar = true;
                Thread proceso = new Thread(new ThreadStart(buscar));
                    termino = textBox1.Text;
                    textBox1.Text = "";
                proceso.Start();
                }
            }
        }

        private void pictureBox24_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox24_MouseDown(object sender, MouseEventArgs e)
        {
            if (textBox1.TextLength >= 2)
            {
                StringBuilder ss = new StringBuilder(textBox1.Text);
                ss.Remove(textBox1.TextLength - 2, 2);
                textBox1.Text = ss.ToString();
            }
            else
            if (textBox1.TextLength == 1)
            {
                textBox1.Text = "";
            }
        }
        public void notificarerror(string texto)
        {
            foreach (Control  aa in this.Controls)
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
            foreach (Control  aa in this.Controls)
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
    }
}
