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
    public partial class delete_playlistelements :MaterialSkin.Controls.MaterialForm
    {
        public string name = "";
        public string nombrelemento = "";
        
        List<string> links = new List<string>();
        List<string> nombres = new List<string>();
        public delete_playlistelements()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string notperma = " " + metroLabel2.Text;
            System.Text.StringBuilder sb = new System.Text.StringBuilder(metroLabel2.Text);
            int total = sb.Length;
            char ch = sb[0];
            sb.Remove(0, 1);
            sb.Insert(sb.Length, ch);
            metroLabel2.Text = sb.ToString();
            metroLabel2.Refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Load_playlist2 lp = new Load_playlist2();
            lp.name = name;
            lp.localizacion = this.Location;
            lp.Show();
        }

        private void delete_playlistelements_Load(object sender, EventArgs e)
        {
           
            var a = Directory.GetFiles(Application.StartupPath + @"\Saved_playlist");
            List<string> a2 = new List<string>();
            foreach (string ee in a)
            {
                a2.Add(Path.GetFileNameWithoutExtension(ee));
            }

            string todo = File.ReadAllText(a[a2.IndexOf(name)]);
            if (todo.Split('$')[0].Trim() != ""&& todo.Split('$')[1].Trim() != "")
            {
              
        
            string linkspuros = todo.Split('$')[1];
            linkspuros = linkspuros.Remove(linkspuros.Length-1 , 1);
            string nombrespuros = todo.Split('$')[0];
            nombrespuros = nombrespuros.Remove(nombrespuros.Length-1 , 1);

            links = linkspuros.Split(';').ToList();
               nombres = nombrespuros.Split(';').ToList();
       
            listBox1.DataSource = nombres;
                if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
                {
                    metroLabel2.Text = " Seleccione elementos para eliminar o eliminar lista completa dandole click a siguiente";
                }
                else
                  if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
                {
                    metroLabel2.Text = " Select playlist elements to delete or click to next to delete the complete playlist";
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         

            DialogResult dl=   MessageBox.Show("Realmente desea eliminar esta lista de reproduccion??","",MessageBoxButtons.OKCancel);
            if (dl == DialogResult.OK)
            {
                File.Delete(Application.StartupPath + @"\Saved_playlist\" + name.Trim());
               notificarerrors("Lista de reproduccion eliminada");
                this.Close();
            }else
            {

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
        private void listBox1_Click(object sender, EventArgs e)
        {
            nombrelemento = listBox1.Text;
            if (nombrelemento.Length > 0)
            {

          
            DialogResult dialogo = MessageBox.Show("Desea eliminar el elemento: " + nombrelemento + "de la lista de reproduccion??", "", MessageBoxButtons.YesNo);
            if (dialogo == DialogResult.Yes)
            {
                links.RemoveAt(nombres.IndexOf(nombrelemento));
                nombres.RemoveAt(nombres.IndexOf(nombrelemento));
                string linkeses = "";
                string nombreses = "";
                foreach(string i in links)
                {
                    linkeses += i + ";";
                }
                foreach (string i in nombres)
                {
                    nombreses += i + ";";
                }
                File.Delete(Application.StartupPath + @"\Saved_playlist\" + name);
                StreamWriter escritor = File.CreateText(Application.StartupPath + @"\Saved_playlist\" + name);
                escritor.Write(nombreses + "$" + linkeses);
                escritor.Close();
             
               notificarerrors("elemento eliminado satisfactoriamente");
                listBox1.DataSource = null;
                listBox1.DataSource = nombres;
            }
            else
            {

            }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            foreach (var a in nombres)
            {
                if (a.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listBox1.Items.Add(a);
                }
            }
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}
