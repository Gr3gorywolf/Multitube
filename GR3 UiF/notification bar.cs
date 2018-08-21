using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace GR3_UiF
{
    public partial class notification_bar : Form
    {
        public int startPosX = Screen.PrimaryScreen.WorkingArea.Width-499;
        public int startPosY = 1 ;
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0001;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        System.Text.StringBuilder sb;
        [DllImport("user32.dll")]
   
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        /// <summary>
        /// /
        /// </summary>
        ///  
        public Random randomize = new Random();
     
        public string imagen;
        public string titulo;
        public string link;
     
        public int contador = 0;
        public notification_bar()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabel1.Text);
          
        }

        private void notification_bar_Load(object sender, EventArgs e)
        {
       
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                this.label2.Text = "Playing...";
              

            }
            else
              if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
            {
                this.label2.Text = "Reproduciendo...";
             

            }

            // SetDesktopLocation(startPosX, startPosY);
            SetWindowPos(this.Handle, HWND_TOPMOST, startPosX, startPosY, 7, 7, TOPMOST_FLAGS);
            pictureBox1.ImageLocation = imagen;
 
            label1.Text = "      "+ titulo;
            linkLabel1.Text = link;
            this.WindowState = FormWindowState.Normal;

            sb = new System.Text.StringBuilder(label1.Text);
       
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
       
            int total = sb.Length;
            if (total >= 30)
            {

                char ch = sb[0];
                sb.Remove(0, 1);
                sb.Insert(sb.Length, ch);
                label1.Text = sb.ToString();
                label1.Refresh();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void notification_bar_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.Close();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
          if(this.Size.Width< 500)
            {

                this.Size =new Size( this.Size.Width + 10,92);
            }
            if (this.Size.Width >= 500)
            {
                this.Size = new Size(500, 92);
            }

        }
    }
}
