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
    public partial class Configs : MaterialSkin.Controls.MaterialForm
    {
        public int calidad;
        public FolderBrowserDialog dialogo;
        public string path;
        public FolderBrowserDialog dialogo2;
        public string path2;
        public bool rutaalterna = false;
        public string lenguaje;
        Form1 instancia = (Form1)Application.OpenForms["form1"];
        public Configs()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
              dialogo = new FolderBrowserDialog();
            DialogResult resultado = dialogo.ShowDialog();
            path= dialogo.SelectedPath.ToString();
            try
            {

           
            var test = File.Create(dialogo.SelectedPath.ToString() + @"\" + "Test.gr3");
                test.Close();
            File.Delete(dialogo.SelectedPath.ToString() + @"\" + "Test.gr3");
             
            }
            catch (Exception)
            {
                if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
                {
                   notificarerror("Invalid path");
                }
                else
                {
                   notificarerror("Ruta invalida");
                }

                path = "";

            }
            label3.Text = path;
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
            prri.Location = new Point(this.Size.Width - 286, 60);
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
            prri.Location = new Point(this.Size.Width - 286,60);
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
        private void comboBox1_Validated(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(calidad != GR3_UiF.Properties.Settings.Default.caldidad_defecto)
            {
                if (instancia.linkLabel1.Text.Trim().Length > 0)
                {
                    instancia.reproducir(instancia.linkLabel1.Text);
                }
            }
            GR3_UiF.Properties.Settings.Default.caldidad_defecto = calidad;
            GR3_UiF.Properties.Settings.Default.lugar_descarga = path;
            GR3_UiF.Properties.Settings.Default.rutaalterna = rutaalterna;
            GR3_UiF.Properties.Settings.Default.rutaalternastr = path2;
            GR3_UiF.Properties.Settings.Default.modominion = metroToggle2.Checked;
            GR3_UiF.Properties.Settings.Default.sobre = metroToggle3.Checked;
            GR3_UiF.Properties.Settings.Default.Navegadorn = metroToggle4.Checked;
            GR3_UiF.Properties.Settings.Default.Notificaciones = metroToggle5.Checked;
            GR3_UiF.Properties.Settings.Default.ventanaenventana = metroToggle6.Checked;

            if (lenguaje!= "") { 
            GR3_UiF.Properties.Settings.Default.lenguaje = lenguaje;
            }
            label3.Text = path;

            GR3_UiF.Properties.Settings.Default.Save();
         
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                this.label1.Text = "Player default quality";
                this.label2.Text = "Default downlad folder";
                this.label6.Text = "Copy downloaded file to other path or usb?";
                this.label5.Text = "Copy path";
                this.label7.Text = "Enter to mini mode when client is connected?";
                this.label9.Text = "Over other windows";
                this.label10.Text = "Native web browser";
                this.label11.Text = "Enable notifications";
                this.label12.Text = "Language";
                this.label13.Text = "Open menus in main window?";
             notificarerrors("Configurations saved");

            }
            else
               if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
            {
                this.label1.Text = "Calidad del reproductor por defecto";
                this.label2.Text = "Carpeta por defecto de descargas";
                this.label6.Text = "Copiar archivo descargado a otra ruta o usb?";
                this.label5.Text = "Ruta de copiado";
                this.label7.Text = "Entrar en  mini cuando el cliente este conectado?";
                this.label9.Text = "Sobre otras ventanas?";
                this.label10.Text = "Navegador nativo?";
                this.label11.Text = "Activar notificaciones?";
                this.label13.Text = "Abrir menúes en ventana principal?";
                this.label12.Text = "Lenguaje";
            notificarerrors("Configuraciones guardadas");

            }
        }
       

        private void Configs_Load(object sender, EventArgs e)
        {
          
            label3.Text = GR3_UiF.Properties.Settings.Default.lugar_descarga;
            path2 = GR3_UiF.Properties.Settings.Default.rutaalternastr;
            path = GR3_UiF.Properties.Settings.Default.lugar_descarga;
            calidad = GR3_UiF.Properties.Settings.Default.caldidad_defecto;
            label8.Text = GR3_UiF.Properties.Settings.Default.rutaalternastr;
            metroToggle1.Checked = GR3_UiF.Properties.Settings.Default.rutaalterna;
            metroToggle2.Checked = GR3_UiF.Properties.Settings.Default.modominion;
            metroToggle3.Checked = GR3_UiF.Properties.Settings.Default.sobre;
            metroToggle4.Checked = GR3_UiF.Properties.Settings.Default.Navegadorn;
            metroToggle5.Checked = GR3_UiF.Properties.Settings.Default.Notificaciones;
            metroComboBox2.Text = GR3_UiF.Properties.Settings.Default.lenguaje;
            metroToggle6.Checked = GR3_UiF.Properties.Settings.Default.ventanaenventana;
            lenguaje = GR3_UiF.Properties.Settings.Default.lenguaje;
            if (metroToggle1.Checked == true)
            {
                pictureBox3.Visible = true;
                label5.Visible = true;
                label8.Visible = true;

            }
            else
            {
                pictureBox3.Visible = false;
                label5.Visible = false;
                label8.Visible = false;
            }
            if (calidad!=0)
            {
                this.label4.Text = calidad.ToString()+"p";
                metroComboBox1.Text = GR3_UiF.Properties.Settings.Default.caldidad_defecto + "p";
            }
           else
            {
                this.label4.Text = "Solo audio";
                  metroComboBox1.Text = "Solo audio";

            }
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                this.label1.Text = "Player default quality";
                this.label2.Text = "Default downlad folder";
                this.label6.Text = "Copy downloaded file to other path or usb?";
                this.label5.Text = "Copy path";
                this.label7.Text = "Enter to mini mode when client is connected?";
                this.label9.Text = "Over other windows";
                this.label10.Text = "Native web browser";
                this.label11.Text = "Enable notifications";
                this.label12.Text = "Language";
                this.label13.Text = "Open menus in main window?";
             

            }
            else
              if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
            {
                this.label1.Text = "Calidad del reproductor por defecto";
                this.label2.Text = "Carpeta por defecto de descargas";
                this.label6.Text = "Copiar archivo descargado a otra ruta o usb?";
                this.label5.Text = "Ruta de copiado";
                this.label7.Text = "Entrar en  mini cuando el cliente este conectado?";
                this.label9.Text = "Sobre otras ventanas?";
                this.label10.Text = "Navegador nativo?";
                this.label11.Text = "Activar notificaciones?";
                this.label13.Text = "Abrir menúes en ventana principal?";
                this.label12.Text = "Lenguaje";
          

            }
            this.CenterToParent();

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            dialogo2 = new FolderBrowserDialog();
            DialogResult resultado2 = dialogo2.ShowDialog();
            path2 = dialogo2.SelectedPath.ToString();
            try
            {


                var test = File.Create(dialogo2.SelectedPath.ToString() + @"\" + "Test.gr3");
                test.Close();
                File.Delete(dialogo2.SelectedPath.ToString() + @"\" + "Test.gr3");
                //label3.Text = dialogo2.SelectedPath.ToString();
            }
            catch (Exception)
            {
                if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
                {
                  notificarerror("Invalid path");
                }
                else
                {
                   notificarerror("Ruta invalida");
                }
               
                path2 = "";

            }
            label8.Text = path2;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {
            rutaalterna = metroToggle1.Checked;
            if (metroToggle1.Checked == true)
            {
                pictureBox3.Visible = true;
                label5.Visible = true;
                label8.Visible = true;

            }
            else
            {
                pictureBox3.Visible = false;
                label5.Visible = false;
                label8.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            this.Refresh();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {

            this.pictureBox2.BorderStyle = BorderStyle.None;
            this.Refresh();
        }

        private void metroComboBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox2.Text == "360p")
            {
                calidad = 360;
            }
            else
                  if (metroComboBox2.Text == "720p")
            {
                calidad = 720;
            }
            else
            if (metroComboBox2.Text == "Solo audio")
            {
                calidad = 0;
            }
            this.label4.Text = metroComboBox1.Text;

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.Text == "Españól")
            {
                lenguaje = "spa";
            }
            else
                  if (metroComboBox1.Text == "English")
            {
                lenguaje = "eng";
            }

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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            GR3_UiF.Properties.Settings.Default.Reset();
          
            GR3_UiF.Properties.Settings.Default.Save();
            GR3_UiF.Properties.Settings.Default.lugar_descarga = Application.StartupPath + @"\descargas";
            GR3_UiF.Properties.Settings.Default.Save();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            GR3_UiF.Properties.Settings.Default.Reset();

            GR3_UiF.Properties.Settings.Default.Save();
            GR3_UiF.Properties.Settings.Default.lugar_descarga = Application.StartupPath + @"\descargas";
            GR3_UiF.Properties.Settings.Default.Save();
        }
    }
    }

