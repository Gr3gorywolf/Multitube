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
    public partial class delete_playlist : MaterialSkin.Controls.MaterialForm
    {
        public string name = "";
        public List<string> plin = new List<string>();
        public delete_playlist()
        {
            InitializeComponent();
        }

        private void delete_playlist_Load(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
            {
              this.metroLabel2.Text="Seleccione una lista de reproduccion";
            }
            else { metroLabel2.Text="Select a playlist"; }
            string[] items = Directory.GetFiles(Application.StartupPath + @"\Saved_playlist");
            foreach (string it in items)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(it));
                plin.Add(Path.GetFileNameWithoutExtension(it));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = listBox1.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            /*
            if (name != "") { 
            File.Delete(Application.StartupPath + @"\Saved_playlist\"+name.Trim());
                if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
                {
                    this.metroLabel2.Text = "Lista eliminada";
                }
                else { metroLabel2.Text = "Playlist deleted"; }
                string[] items = Directory.GetFiles(Application.StartupPath + @"\Saved_playlist");
            listBox1.Items.Clear();
            foreach (string it in items)
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(it));

            }
            }
            else
            {
                    if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa") { 
                    MessageBox.Show("Por favor seleccione una lista de reproduccion");
                    }
                    else { MessageBox.Show("Please select a playlist"); }
                }
            }*/
            if (name.Trim().Length>=1)
            {
                delete_playlistelements dl = new delete_playlistelements();
                dl.name = name;
                dl.Location = this.Location;
                dl.Show();
                this.Close();
            }
            else
            {
               notificarerror("Por favor seleccione un elemento");
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
            name = listBox1.Text;
            if (name.Trim().Length >= 1)
            {
                DialogResult aa = MessageBox.Show("Realmente desea eliminar la lista de reproduccion " + name, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (aa == DialogResult.Yes)
                {
                    File.Delete(Application.StartupPath+@"\Saved_playlist\" + name);
                    notificarerrors("Lista de reproduccion eliminada satisfactoriamente");
                    listBox1.Items.Clear();
                    string[] items = Directory.GetFiles(Application.StartupPath + @"\Saved_playlist");
                    foreach (string it in items)
                    {
                        listBox1.Items.Add(Path.GetFileNameWithoutExtension(it));

                    }
                }
                else
                {
                    notificarerror("operacion cancelada");
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Load_playlist lp = new Load_playlist();
            lp.localizacion = this.Location;
            lp.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            foreach (var a in plin)
            {
                if (a.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listBox1.Items.Add(a);
                }
            }
        }
    }
}

