using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace GR3_UiF
{
    public partial class Save_playlist :MaterialSkin.Controls.MaterialForm
    {
        public Form1 instancia =(Form1) Application.OpenForms["Form1"];
        public List<string> listica = new List<string>();
        public List<string> listicalinks = new List<string>();
        public Save_playlist()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try { 
            if (textBox1.Text.Trim() != "")
            {
                StreamWriter escribidor;
                escribidor = File.CreateText(Application.StartupPath + @"\Saved_playlist\" + textBox1.Text.Trim() );
                string completa = "";
                    string completa2 = "";

                    if (metroToggle1.Checked)
                    {

               
                    foreach (string cada in instancia.lapara)
                {

                        string tutu = cada.Replace(';', ' ');
                            string tutu2 = tutu.Replace('$', ' ').Replace(">", "").Replace("<", "");
                    completa += tutu2 + ";";
                }
                    foreach (string cada in instancia.laparalink)
                {
                    completa2 += cada + ";";
                }
                escribidor.Write(completa+"$"+completa2);
                escribidor.Close();
                    }else
                    {
                        escribidor.Write("  $ ");
                        escribidor.Close();
                    }
                    if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
                    {
                        notificarerrors("Lista de reproduccion guardada con exito");
                      
                    }
                    else
                    {
                       notificarerrors("Playlist saved sucessfull");
                      
                    }
                    this.textBox1.Text = "";
                }
            else
            {

                    if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
                    {
                       notificarerror("Por favor entre un nombre valido para la lista de reproduccion");
                    }
                    else
                    {
                        notificarerror("Please enter a valid playlist name");
                    }
                  
            }
            }catch(Exception)
            {
                if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
                {
                    notificarerror("Error:Nombre invalido");
                }
                else
                {
                    notificarerror("Error:Ivalid name");
                }
             
            }



        }

        private void Save_playlist_Load(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
            {
            this.textBox1.Hint = "Nombre de la lista de reproduccion:";
                this.metroLabel2.Text = "Elementos de la lista";
            }
            else {

                this.textBox1.Hint = "Name of the playlist:";
                this.metroLabel2.Text = "Playlist elements:";
            }
            var aad = new List<string>(instancia.lapara);
            foreach(string aa in listica)
            {
                var aax = aa.Replace('<', ' ');
                aax = aax.Replace('>', ' ');
                aad.Add(aax);
            }
            listica = aad;
            listBox1.DataSource = listica;

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if(metroToggle1.Checked)
            {
                this.MaximumSize = new Size(374,473);
                this.Size = new Size(374, 473);
                this.MinimumSize = new Size(374, 473);
            }
            else
            {
                this.MaximumSize= new Size(374,172);
                this.MinimumSize = new Size(374, 172);
                this.Size = new Size(374, 172);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Load_playlist carga = new Load_playlist();
            carga.localizacion = this.Location;
            carga.Show();
        }
    }
}
