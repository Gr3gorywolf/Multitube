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
    public partial class Load_playlist2 : MaterialSkin.Controls.MaterialForm
    {
        public string lista;
        public string name;
        public string[] lista2;
        public string[] lista3;
        public string listilla1 = "";
        public string listilla2 = "";
        public Point localizacion;
        public bool nodepurify = false;
        List<string> str = new List<string>();
        StreamReader tupara2;
        public Load_playlist2()
        {
            InitializeComponent();
        }

        private void Load_playlist2_Load(object sender, EventArgs e)
        {
            this.Location = localizacion;
            StreamReader tupara;
            
           
         if(name.StartsWith("¤¤¤¤¤¤nameeexx¤¤¤¤¤¤¤¤¤§") )
            {
                tupara = File.OpenText(name.Split('§')[1]+".gr3lst");
                nodepurify = true;
                this.pictureBox3.Location = new Point(pictureBox3.Location.X - 30, pictureBox3.Location.Y);
                this.pictureBox4.Visible = false;

            }
            else
            {
                tupara = File.OpenText(Application.StartupPath + @"\Saved_playlist\" + name);
            }
         
            lista = tupara.ReadToEnd();
            if (lista.Split('$')[0].Trim().Length == 0 && lista.Split('$')[1].Trim().Length == 0)
            {
               notificarerror("La lista esta vacia");
                this.Close();

            }
            else
            {
                listilla1 = lista.Split('$')[0];
                listilla2 = lista.Split('$')[1];
              
             
                lista2 = listilla1.Split(';');
                lista3 = listilla2.Split(';');
                int indez = 0;
           
                foreach (string it in lista2)
                {
                    if (it.StartsWith(">"))
                    {
                        string papu = it;
                        StringBuilder ee = new StringBuilder(papu);
                        ee.Replace('>', ' ');
                        ee.Replace('<', ' ');

                        lista2.SetValue(ee.ToString(), indez);


                    }
                    else
                    {
                        if (nodepurify)
                        {
                             str = lista2.ToList();                        
                            listBox1.DataSource = str;
                        }
                        else
                        {
                                str = lista2.ToList();
                        str.RemoveAt(lista2.Length - 1);
                            listBox1.DataSource = str;
                        }
                    
                    }

                    indez++;
                }
            }
         
          
       
          
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Load_playlist cargar = new Load_playlist();
            cargar.localizacion = this.Location;
            cargar.Show();
            this.Close();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            customdialog dialoguin = new customdialog();
            dialoguin.Location = this.Location;
            dialoguin.url = lista3[lista2.ToList().IndexOf(listBox1.Text)];
            dialoguin.imagen = lista3[lista2.ToList().IndexOf(listBox1.Text)].Split('=')[1];
            dialoguin.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
       
    }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
            delete_playlistelements eliminador = new delete_playlistelements();
            eliminador.name = name;
            eliminador.Location = this.Location;
            eliminador.Show();
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            string listica = "";
            foreach (string itt in lista2)
            {
                listica += itt + ";";
            }
            StringBuilder sb = new StringBuilder(listica);
            sb.Remove(sb.Length - 1, 1);
            if (!nodepurify)
            {
                GR3_UiF.Properties.Settings.Default.lista = sb.ToString().Remove(sb.ToString().Length - 1);
                GR3_UiF.Properties.Settings.Default.listalinks = listilla2.Remove(listilla2.Length - 1).ToString();
                GR3_UiF.Properties.Settings.Default.Save();
            }
            else
            {
                GR3_UiF.Properties.Settings.Default.lista = sb.ToString();
                GR3_UiF.Properties.Settings.Default.listalinks = listilla2;
                GR3_UiF.Properties.Settings.Default.Save();
            }


            this.Close();
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
            prri.Location = new Point(this.Size.Width - 286, 1);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.Items.Clear();
            foreach (var a in str)
            {
                if (a.ToLower().Contains(textBox1.Text.ToLower()))
                {
                    listBox1.Items.Add(a);
                }
            }
        }
    }
}
