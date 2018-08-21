using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GR3_UiF
{
    public partial class Volumedialog : Form
    {
        public int porciento;
        public int startPosX = Screen.PrimaryScreen.WorkingArea.Width - Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.73);
        public int startPosY = Screen.PrimaryScreen.WorkingArea.Height - Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height);
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0001;
        private const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        public Volumedialog()
        {
            InitializeComponent();
        }

        private void metroScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Volumedialog_Load(object sender, EventArgs e)
        {
            SetWindowPos(this.Handle, HWND_TOPMOST, startPosX, startPosY, 7, 7, TOPMOST_FLAGS);
            this.metroTrackBar1.Value = porciento;
            this.label1.Text = porciento + "%";
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.BringToFront();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            this.Close();
         
        }
    }
}
