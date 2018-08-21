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
    public partial class Load_playlist : MaterialSkin.Controls.MaterialForm

    {
        public Point localizacion;
        public string name = "";
        public List<string> lista = new List<string>();
        public List<string> listalinks = new List<string>();
        public List<string> listaelementos = new List<string>();
        public Load_playlist()
        {
            InitializeComponent();
        }

        private void Load_playlist_Load(object sender, EventArgs e)
        {
            /*   if (localizacion!=new Point(0, 0))
               {
                   this.Location = localizacion;
               }*/
            this.CenterToParent();
        string[]items=Directory.GetFiles(Application.StartupPath + @"\Saved_playlist");
         foreach(string it in items)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(it));
                listaelementos.Add(Path.GetFileNameWithoutExtension(it));
            }
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = listBox1.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (name != "") { 
            Load_playlist2 turr = new Load_playlist2();
            turr.name = name;
                turr.localizacion = this.Location;
            turr.Show();
            this.Close();
            }
            else { 
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
            {
               notificarerror("Por favor seleccione una lista");
            }
            else { notificarerror("Please select a list"); }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {




            name = listBox1.Text;
           

            if (name != "")
            {



              var  tupara = File.OpenText(Application.StartupPath + @"\Saved_playlist\" + name);
           

            var lista = tupara.ReadToEnd();
            if (lista.Split('$')[0].Trim().Length == 0 && lista.Split('$')[1].Trim().Length == 0)
            {
                notificarerror("La lista esta vacia");
           

                }
                else
                {

                    Load_playlist2 turr = new Load_playlist2();
                    turr.name = name;
                    turr.localizacion = this.Location;
                    turr.Show();
                    this.Close();
                }


            }
            else
            {
                if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
                {
                   notificarerror("Por favor seleccione una lista");
                }
                else { notificarerror("Please select a list"); }
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (File.Exists("fablist.gr3lst"))
            {
                Load_playlist2 turr = new Load_playlist2();
                turr.name = "¤¤¤¤¤¤nameeexx¤¤¤¤¤¤¤¤¤§" + "fablist";
                turr.localizacion = this.Location;
                turr.Show();
                this.Close();
            }
            else
            {
                if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
                {
                   notificarerror("No Tiene  favoritos aun");
                }
                else { notificarerror("You dont have favorites yet"); }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            Save_playlist pls = new Save_playlist();
            pls.listica = lista;
            pls.listicalinks = listalinks;
            pls.Location = this.Location;
            pls.Show();
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

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            delete_playlist dl = new delete_playlist();
            dl.Location = this.Location;
            dl.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach(var a in listaelementos)
            {
                if (a.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listBox1.Items.Add(a);
                }
            }
        

        }
    }
}
