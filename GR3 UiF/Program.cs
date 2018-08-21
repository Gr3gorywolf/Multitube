using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
namespace GR3_UiF
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string aa = "";
            var elarray = 0;
            var etrin = "";
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3"))
            {
               etrin = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\downloadlog.gr3");
            }
       
            if (etrin.Length > 20)
            {
                elarray = etrin.Split('$').Length;
            }
          
           
           
            if (GR3_UiF.Properties.Settings.Default.lenguaje.Trim()=="")
            {
                Application.Run(new languajeselector());
            }
            else
            {

                if (elarray > 1)
                {
                    Application.Run(new Selector_de_modo());
                }
                else
                {
                    Application.Run(new Form1());

                }

            }

          
        }
    }
}
