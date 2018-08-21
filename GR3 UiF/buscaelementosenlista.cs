using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GR3_UiF
{
    class buscaelementosenlista
    {
        public bool encontroparecido(string link, List<string> listalinks)
        {
            bool encontro = false;
            foreach (string ee in listalinks)
            {
                if (ee == link)
                {
                    encontro = true;
                }
            }
            if (encontro)
            {

                return true;
            }

            else
            {

                return false;
            }
        }
    }
}
