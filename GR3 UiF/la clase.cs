using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace prueba_de_lista_generica
{
    public class Videos
    {
      public  string url { get; set; }
        public string nombre { get; set; }
       public Image imagen { get; set; }
       public string tiempo { get; set; }
    }
    static class SocketExtensions
    {
        public static bool IsConnected(this TcpClient socket)
        {
            try
            {
                return !(socket.Client.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (Exception) { return false; }
        }
    }
}
