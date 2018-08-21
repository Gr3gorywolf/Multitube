using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
namespace GR3_UiF
{
   public class claseanimaciones
    {

        public void animar(PictureBox pieza, int height, int with)
        {



            System.Windows.Forms.Timer timel = new System.Windows.Forms.Timer();
            timel.Enabled = true;
            timel.Interval = 10;
            int count = 0;
            timel.Tick += delegate {
                if (count < 4)
                {
                    count++;
                    pieza.Size = new Size(height, pieza.Width - Convert.ToInt32(with * 0.10));

                }
                else
                {
                    timel.Enabled = false;
                    System.Windows.Forms.Timer timel2 = new System.Windows.Forms.Timer();
                    timel2.Enabled = true;
                    timel2.Interval = 10;
                    int count2 = 0;
                    timel2.Tick += delegate
                    {
                        if (count2 < 4)
                        {
                            count2++;

                            pieza.Size = new Size(height, pieza.Width + Convert.ToInt32(with * 0.10));
                        }
                        else
                        {
                            timel2.Enabled = false;
                            pieza.Size = new Size(height, with);
                        }
                    };

                    timel2.Start();

                }

            };
            timel.Start();

        }

    }
}
