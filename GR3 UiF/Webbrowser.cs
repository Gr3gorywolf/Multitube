using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace GR3_UiF
{
    public partial class Webbrowser : Form
    {

        public Thread tuparra;
        public string url;
     
        public string imgurl;
        public bool activated = false;
        public string retornador;

        public Webbrowser()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           
          if(activated==true)
            {
                activated = false;
                customdialog dialogo = new customdialog();
                dialogo.Location = this.Location;
                dialogo.imagen = imgurl;
                dialogo.url = url;

                dialogo.ShowDialog();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("https://www.youtube.com/");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoBack();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.webBrowser1.GoForward();
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string[] cadenita = webBrowser1.Url.OriginalString.Split('/');
            //https://www.youtube.com/watch?v=NXQPCowmbD8


            if (cadenita[3].StartsWith("watch"))
            {
               
              
                string[] cadenita2 = webBrowser1.Url.OriginalString.Split('=');
                imgurl = cadenita2[1];
                 url= webBrowser1.Url.OriginalString;
                webBrowser1.GoBack();
                activated = true;
               
            }










        }

        private void Webbrowser_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate("https://www.youtube.com/");
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string buscar = this.textBox1.Text;
            string[] desglosar = buscar.Split(' ');//three days grace 
            string completa = "";
            for (int i = 0; i < desglosar.Length; i++)
            {
                completa += desglosar[i] + "+";
            }
            webBrowser1.Navigate("https://www.youtube.com/results?search_query=" + completa);

          
            this.textBox1.Text = "";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                string buscar = this.textBox1.Text;
            string[] desglosar = buscar.Split(' ');//three days grace 
            string completa = "";
            for (int i = 0; i < desglosar.Length; i++)
            {
                completa += desglosar[i] + "+";
            }
            webBrowser1.Navigate("https://www.youtube.com/results?search_query=" + completa);
               
            this.textBox1.Text = "";
            }
        }
               private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }
       

        private void pictureBox5_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
          
        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
         
          
        }
      

        private void pictureBox8_Click(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
           
       

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
          
          
        }

        private void webBrowser1_NewWindow(object sender, CancelEventArgs e)
        {
         
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.sendingdiscover == true)
            {
                GR3_UiF.Properties.Settings.Default.sendingdiscover = false;
                GR3_UiF.Properties.Settings.Default.Save();

                this.Close();
            }
        }
    }
}

