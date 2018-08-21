using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GR3_UiF
{
    public partial class Downloader2 :MaterialSkin.Controls.MaterialForm
    {
        public string imgurl = "";
        public string link = "";
        public string titulo = "";
       public bool modoenform = false;
        public Downloader2()
        {
            InitializeComponent();
        }

        private void Downloader2_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            pictureBox3.ImageLocation = imgurl;
            this.metroLabel5.Text = titulo;
            this.linkLabel1.Text = link;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (metroLabel5.Text.Length >= 60&&modoenform==false)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(metroLabel5.Text);
                char ch = sb[0];
                sb.Remove(0, 1);
                sb.Insert(sb.Length, ch);
                metroLabel5.Text = sb.ToString();
                metroLabel5.Refresh();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {/*
            Fdescarga lapara = new Fdescarga();

            lapara.imagen = pictureBox3.ImageLocation;
            lapara.link = linkLabel1.Text.Trim();
            lapara.nombre = metroLabel5.Text.Trim();
            lapara.calidad = 0;
            lapara.vidomp3 = "";
            lapara.Show();
            if (modoenform == false) { this.Close(); }
         
            descar.imagen = daemond.Split('¤')[0];
            descar.link = daemond.Split('¤')[1];
            descar.nombre = daemond.Split('¤')[2];
            descar.calidad = int.Parse(daemond.Split('¤')[3]);
            descar.vidomp3 = daemond.Split('¤')[4];
            */
            GR3_UiF.Properties.Settings.Default.daemond = pictureBox3.ImageLocation + "¤" + linkLabel1.Text.Trim() + "¤" + metroLabel5.Text.Trim() + "¤" + 0 + "¤" + "";
            GR3_UiF.Properties.Settings.Default.Save();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*
            Fdescarga lapara = new Fdescarga();

            lapara.imagen = pictureBox3.ImageLocation;
            lapara.link = linkLabel1.Text.Trim();
            lapara.calidad = 360;
            lapara.vidomp3 = "video";
            lapara.nombre = metroLabel5.Text.Trim();
            lapara.Show();
            if (modoenform == false) { this.Close(); }*/
            GR3_UiF.Properties.Settings.Default.daemond = pictureBox3.ImageLocation + "¤" + linkLabel1.Text.Trim() + "¤" + metroLabel5.Text.Trim() + "¤" +360 + "¤" + "video";
            GR3_UiF.Properties.Settings.Default.Save();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            /*
            Fdescarga lapara = new Fdescarga();

            lapara.imagen = pictureBox3.ImageLocation;
            lapara.link = linkLabel1.Text.Trim();
            lapara.calidad = 720;
            lapara.vidomp3 = "video";
            lapara.nombre = metroLabel5.Text.Trim();
            lapara.Show();
            if (modoenform == false) { this.Close(); }*/
            GR3_UiF.Properties.Settings.Default.daemond = pictureBox3.ImageLocation + "¤" + linkLabel1.Text.Trim() + "¤" + metroLabel5.Text.Trim() + "¤" + 720 + "¤" + "video";
            GR3_UiF.Properties.Settings.Default.Save();
            this.Close();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            /*
            Formlistadescarga aaaa = new Formlistadescarga();
            aaaa.Location = this.Location;
            aaaa.Show();*/
            GR3_UiF.Properties.Settings.Default.daemoninvoke = true;
            GR3_UiF.Properties.Settings.Default.Save();
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.daemonr == "Si"){
                notificarerror("El elemento ya se esta descargando");
                GR3_UiF.Properties.Settings.Default.daemonr = "No";
                GR3_UiF.Properties.Settings.Default.Save();
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
    }
}
