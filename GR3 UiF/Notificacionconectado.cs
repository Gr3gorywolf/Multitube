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

    public partial class Notificacionconectado : Form
    {
        public int startPosX = 1;
        public int startPosY = 1;
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

        public Notificacionconectado()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Notificacionconectado_Load(object sender, EventArgs e)
        {
            if (GR3_UiF.Properties.Settings.Default.lenguaje == "eng")
            {
                this.metroLabel1.Text = "New device connected";


            }
            else
             if (GR3_UiF.Properties.Settings.Default.lenguaje == "spa")
            {
                this.metroLabel1.Text = "Nuevo dispositivo conectado";


            }
            SetWindowPos(this.Handle, HWND_TOPMOST, startPosX, startPosY, 7, 7, TOPMOST_FLAGS);
        }
    }
}
