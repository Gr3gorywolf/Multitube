using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace GR3_UiF
{
    public partial class agregarelementoaplaylist : Form
    {
        public bool selected = false;
        public List<string> listalistas = new List<string>();
        public List<string> listacopia = new List<string>();
        public string nombreelemento = "";
        public string linkelemento = "";
        public string temporal1 = "";
        public List<ListViewItem> listaitems = new List<ListViewItem>();
        public agregarelementoaplaylist()
        {
            InitializeComponent();
        }

        private void agregarelementoaplaylist_Load(object sender, EventArgs e)
        {
       
            actualizaryo();
            metroLabel2.Text ="    " +nombreelemento;
            temporal1 =  metroLabel2.Text;
            linkLabel1.Text = linkelemento;
          pictureBox2.ImageLocation = @"https://i.ytimg.com/vi/" + linkelemento.Split('=')[1] + "/hqdefault.jpg";
            this.TopMost = true;
        }
        public void actualizaryo()
        {
            listacopia.Clear();
            listView1.Clear();
            listaitems.Clear();
            foreach (string i in Directory.GetFiles(Application.StartupPath + @"\Saved_playlist"))
            {
                listalistas.Add(i);
                ListViewItem item = new ListViewItem();
                item.Text = Path.GetFileNameWithoutExtension(i);
                listacopia.Add(Path.GetFileNameWithoutExtension(i));
                item.ImageIndex = 0;
                listView1.Items.Add(item);
             
                listaitems.Add(item);
            
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


         


            if (selected==true)
            {
               var elementoactual = listalistas[listacopia.IndexOf(listView1.SelectedItems[0].Text)];
                DialogResult dialogo = MessageBox.Show("Desea realmente agregar " + nombreelemento + " A la lista de reproduccion  " + Path.GetFileNameWithoutExtension(elementoactual),"",MessageBoxButtons.YesNo);
                if (dialogo == DialogResult.Yes)
                {

             


            string stringcompleta = "";
            string stringlinks = "";
            string stringnombres = "";
            string data = File.ReadAllText(elementoactual);
            List<string> listanames = new List<string>();
            List<string> listalinks = new List<string>();
            try
            {
                listanames = data.Split('$')[0].Split(';').ToList();
                listalinks = data.Split('$')[1].Split(';').ToList();
                listalinks.RemoveAt(listalinks.Count - 1);
                listanames.RemoveAt(listanames.Count - 1);
            }
            catch (Exception)
            {
                        listanames = data.Split('$')[0].Split(';').ToList();
                        listalinks = data.Split('$')[1].Split(';').ToList();
                    }
                    GR3_UiF.buscaelementosenlista aa = new buscaelementosenlista();
          if (!aa.encontroparecido(linkelemento, listalinks)) { 
           
            listanames.Add(nombreelemento);
            listalinks.Add(linkelemento);
            foreach(string it in listanames)
            {
                stringnombres += it + ";";
            }
            foreach(string it2 in listalinks)
            {
                stringlinks += it2 + ";";
            }
            stringcompleta = stringnombres + "$" + stringlinks;
            StreamWriter escritor = File.CreateText(elementoactual);
            escritor.Write(stringcompleta);
            escritor.Close();

           notificarerrors("Elemento agregado exitosamente");
            this.Close();
                }
             
                else
                {
                    notificarerror("El elemento ya existe en la lista");
                }
            }
            else
            {
               notificarerror("Por favor seleccione un item para luego agregarlo");
            }
          }

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
            prri.Location = new Point(this.Size.Width- 286,  1);
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
            prri.Location = new Point(this.Size.Width - 286, 1);
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
        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            selected = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StringBuilder sb1 = new StringBuilder(metroLabel2.Text);
            try
            {
                if (temporal1.Length >= 45)
                {
                    char ch = metroLabel2.Text.ToCharArray()[0];
                    sb1.Remove(0, 1);
                    sb1.Insert(sb1.Length, ch);
                    metroLabel2.Text = sb1.ToString();
                }
                else
                {
                    if (temporal1.Length > 1)
                    {
                        metroLabel2.Text = temporal1;
                    }
                }

            }
            catch (Exception)
            {
                metroLabel2.Text = temporal1;
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (var a in listaitems)
            {
                if (a.Text.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listView1.Items.Add(a);
                }
            }
        }
    }
}
