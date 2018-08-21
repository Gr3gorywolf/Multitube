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
    public partial class configuraciones : MaterialSkin.Controls.MaterialForm
    {
        public Color colol = GR3_UiF.Properties.Settings.Default.colorm;
        public Color colol2 = GR3_UiF.Properties.Settings.Default.color_barra;
        public Color colol3= GR3_UiF.Properties.Settings.Default.color_barra;
        public Color colol4 = GR3_UiF.Properties.Settings.Default.Color_app;
        public configuraciones()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
          

        }

        private void configuraciones_FormClosing(object sender, FormClosingEventArgs e)
        {
          
       
        }

        private void button2_Click(object sender, EventArgs e)
        {

          
        }

        private void configuraciones_Load(object sender, EventArgs e)
        {
            this.CenterToParent();
            metroTile39.BackColor=GR3_UiF.Properties.Settings.Default.colorm;
            metroTile40.BackColor = GR3_UiF.Properties.Settings.Default.color_barra;
            metroToggle1.Checked = GR3_UiF.Properties.Settings.Default.color_marcoon;
            metroTile60.BackColor = GR3_UiF.Properties.Settings.Default.color_marco;
            metroTile61.BackColor = GR3_UiF.Properties.Settings.Default.Color_app;
            if (GR3_UiF.Properties.Settings.Default.color_marcoon==true)
            {
                panel1.Visible = true;
            }
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                this.label1.Text = "Titlebar color";
                this.label2.Text = "Video frame Solid color?";
                this.label4.Text = "Vide frame color";
                this.label5.Text = "Client color(App)";
                this.label3.Text = "Side menu color";
            }
           
        }
        public void notificarerror(string texto)
        {
            foreach (Control aa in this.Controls)
            {
                if (aa.Size == new Size(271, 60))
                {
                    this.Invoke((MethodInvoker)delegate {
                        panel1.Controls.Remove(aa);// runs on UI thread
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
                        panel1.Controls.Remove(aa);// runs on UI thread
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GR3_UiF.Properties.Settings.Default.colorm = colol;
            GR3_UiF.Properties.Settings.Default.color_barra = colol2;
            GR3_UiF.Properties.Settings.Default.color_marco = colol3;
            GR3_UiF.Properties.Settings.Default.color_marcoon = metroToggle1.Checked;
            GR3_UiF.Properties.Settings.Default.Color_app = colol4;
            GR3_UiF.Properties.Settings.Default.Color_appchange = true;
            GR3_UiF.Properties.Settings.Default.Save();
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                notificarerrors("Configurations applied and saved");
            }
            else
            {
               notificarerrors("Configuraciones aplicadas y guardadas");
            }
            }

        private void button2_Click_1(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void metroTile14_Click(object sender, EventArgs e)
        {
            colol = metroTile14.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            colol = metroTile1.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            colol = metroTile2.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            colol = metroTile3.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            colol = metroTile4.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            colol = metroTile5.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            colol = metroTile6.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile7_Click(object sender, EventArgs e)
        {
            colol = metroTile7.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile8_Click(object sender, EventArgs e)
        {
            colol = metroTile8.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            colol = metroTile9.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile10_Click(object sender, EventArgs e)
        {
            colol = metroTile10.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile11_Click(object sender, EventArgs e)
        {
            colol = metroTile11.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile12_Click(object sender, EventArgs e)
        {
            colol = metroTile12.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile13_Click(object sender, EventArgs e)
        {
            colol = metroTile13.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile19_Click(object sender, EventArgs e)
        {
            colol = metroTile19.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile18_Click(object sender, EventArgs e)
        {
            colol = metroTile18.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile17_Click(object sender, EventArgs e)
        {
            colol = metroTile17.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile16_Click(object sender, EventArgs e)
        {
            colol = metroTile16.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile15_Click(object sender, EventArgs e)
        {
            colol = metroTile15.BackColor;
            this.metroTile39.BackColor = colol;
        }

        private void metroTile38_Click(object sender, EventArgs e)
        {
            colol2 = metroTile38.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile37_Click(object sender, EventArgs e)
        {
            colol2 = metroTile37.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile36_Click(object sender, EventArgs e)
        {
            colol2 = metroTile36.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile35_Click(object sender, EventArgs e)
        {
            colol2 = metroTile35.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile34_Click(object sender, EventArgs e)
        {
            colol2 = metroTile34.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile33_Click(object sender, EventArgs e)
        {
            colol2 = metroTile33.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile32_Click(object sender, EventArgs e)
        {
            colol2 = metroTile32.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile31_Click(object sender, EventArgs e)
        {
            colol2 = metroTile31.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile30_Click(object sender, EventArgs e)
        {
            colol2 = metroTile30.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile29_Click(object sender, EventArgs e)
        {
            colol2 = metroTile29.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile28_Click(object sender, EventArgs e)
        {
            colol2 = metroTile28.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile27_Click(object sender, EventArgs e)
        {
            colol2 = metroTile27.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile26_Click(object sender, EventArgs e)
        {
            colol2 = metroTile26.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile25_Click(object sender, EventArgs e)
        {
            colol2 = metroTile25.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile24_Click(object sender, EventArgs e)
        {
            colol2 = metroTile24.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile23_Click(object sender, EventArgs e)
        {
            colol2 = metroTile23.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile22_Click(object sender, EventArgs e)
        {
            colol2 = metroTile22.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile21_Click(object sender, EventArgs e)
        {
            colol2 = metroTile21.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroTile20_Click(object sender, EventArgs e)
        {
            colol2 = metroTile20.BackColor;
            metroTile40.BackColor = colol2;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            colol2 = Color.Black;
            metroTile40.BackColor = colol2;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            colol = Color.Black;
            metroTile39.BackColor = colol;
       
        }

        private void metroTile59_Click(object sender, EventArgs e)
        {
            colol3 = metroTile59.BackColor;
            metroTile60.BackColor = colol3;

        }

        private void metroTile58_Click(object sender, EventArgs e)
        {
            colol3 = metroTile58.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile57_Click(object sender, EventArgs e)
        {
            colol3 = metroTile57.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile56_Click(object sender, EventArgs e)
        {
            colol3 = metroTile56.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile55_Click(object sender, EventArgs e)
        {
            colol3 = metroTile55.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile54_Click(object sender, EventArgs e)
        {
            colol3 = metroTile54.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile53_Click(object sender, EventArgs e)
        {
            colol3 = metroTile53.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile52_Click(object sender, EventArgs e)
        {
            colol3 = metroTile52.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile51_Click(object sender, EventArgs e)
        {
            colol3 = metroTile51.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile50_Click(object sender, EventArgs e)
        {
            colol3 = metroTile50.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile49_Click(object sender, EventArgs e)
        {
            colol3 = metroTile49.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile48_Click(object sender, EventArgs e)
        {
            colol3 = metroTile48.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile47_Click(object sender, EventArgs e)
        {
            colol3 = metroTile47.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile46_Click(object sender, EventArgs e)
        {
            colol3 = metroTile46.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile45_Click(object sender, EventArgs e)
        {
            colol3 = metroTile45.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile44_Click(object sender, EventArgs e)
        {
            colol3 = metroTile44.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile43_Click(object sender, EventArgs e)
        {
            colol3 = metroTile43.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile42_Click(object sender, EventArgs e)
        {
            colol3 = metroTile42.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroTile41_Click(object sender, EventArgs e)
        {
            colol3 = metroTile41.BackColor;
            metroTile60.BackColor = colol3;
        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            if(this.metroToggle1.Checked==true)
            {
                this.panel1.Visible = true;
            }
            else
               if (this.metroToggle1.Checked == false)
            {
                this.panel1.Visible = false;
            }

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            colol3 = Color.Black;
            metroTile60.BackColor = colol3;
        }

        private void metroTile68_Click(object sender, EventArgs e)
        {
            colol4 = metroTile68.BackColor;
            metroTile61.BackColor = colol4;
        }

        private void metroTile67_Click(object sender, EventArgs e)
        {
            colol4 = metroTile67.BackColor;
            metroTile61.BackColor = colol4;
        }

        private void metroTile66_Click(object sender, EventArgs e)
        {
        
        }

        private void metroTile65_Click(object sender, EventArgs e)
        {
            colol4 = metroTile65.BackColor;
            metroTile61.BackColor = colol4;
        }

        private void metroTile64_Click(object sender, EventArgs e)
        {
            colol4 = metroTile64.BackColor;
            metroTile61.BackColor = colol4;
        }

        private void metroTile63_Click(object sender, EventArgs e)
        {
            colol4 = metroTile63.BackColor;
            metroTile61.BackColor = colol4;
        }

        private void metroTile62_Click(object sender, EventArgs e)
        {
         
        }

        private void metroTile71_Click(object sender, EventArgs e)
        {
            colol4 = metroTile71.BackColor;
            metroTile61.BackColor = colol4;
        }

        private void metroTile70_Click(object sender, EventArgs e)
        {
            colol4 = metroTile70.BackColor;
            metroTile61.BackColor = colol4;
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            colol4 = Color.Black;
            metroTile61.BackColor = colol4;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            GR3_UiF.Properties.Settings.Default.colorm = colol;
            GR3_UiF.Properties.Settings.Default.color_barra = colol2;
            GR3_UiF.Properties.Settings.Default.color_marco = colol3;
            GR3_UiF.Properties.Settings.Default.color_marcoon = metroToggle1.Checked;
            GR3_UiF.Properties.Settings.Default.Color_app = colol4;
            GR3_UiF.Properties.Settings.Default.Color_appchange = true;
            GR3_UiF.Properties.Settings.Default.Save();
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                notificarerrors("Configurations applied and saved");
            }
            else
            {
                notificarerrors("Configuraciones aplicadas y guardadas");
            }
        }
    }
    }

