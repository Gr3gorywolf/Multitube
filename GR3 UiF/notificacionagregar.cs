using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
 using System.Text.RegularExpressions;
namespace GR3_UiF
{
    
    public partial class notificacionagregar : Form
    {
        public int startPosX = Screen.PrimaryScreen.WorkingArea.Width -256;
        public int startPosY = Screen.PrimaryScreen.WorkingArea.Height-281;
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
        public string nombre;
        public string link;
        

        public notificacionagregar()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void notificacionagregar_Load(object sender, EventArgs e)
        {
            pictureBox2.ImageLocation = @"https://i.ytimg.com/vi/" + link.Split('=')[1] + "/hqdefault.jpg";
            label1.Text ="    " +nombre;
            this.Location = new Point(startPosX, startPosY);
            this.Size = new Size(this.Size.Width, 1);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            metroProgressBar1.Value =metroProgressBar1.Value- 10;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            this.Close();
        }
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
           
            System.Text.StringBuilder sb = new System.Text.StringBuilder(RemoveIllegalPathCharacters(label1.Text));
            int total = sb.Length;
            if (total >= 35)
            {

                char ch = sb[0];
                sb.Remove(0, 1);
                sb.Insert(sb.Length, ch);
                label1.Text = sb.ToString();
                label1.Refresh();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if(this.Size.Height< 281)
            {
                this.Size = new Size(this.Size.Width, this.Size.Height + 8);
            }
        }
    }
}
