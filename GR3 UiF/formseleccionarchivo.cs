using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace GR3_UiF
{
    public partial class formseleccionarchivo : MaterialSkin.Controls.MaterialForm
    {
      public  Bitmap imagen = null;
       public string titulo = null;

        public formseleccionarchivo()
        {
            InitializeComponent();
        }

        private void formseleccionarchivo_Load(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = imagen;
            label1.Text = "    "+titulo;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private static string RemoveIllegalPathCharacters(string path)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
            var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            return r.Replace(path, "");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
      
            System.Text.StringBuilder sb = new System.Text.StringBuilder(RemoveIllegalPathCharacters(label1.Text));
            int total = sb.Length;
            if (total >= 20)
            {

                char ch = sb[0];
                sb.Remove(0, 1);
                sb.Insert(sb.Length, ch);
                label1.Text = sb.ToString();
                label1.Refresh();
            }
        }
    }
}
