using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatClient {
    public class ReadFromStream {
        private static StreamReader _sr;
        private static Thread _oThread;

        public ReadFromStream(StreamReader sr) {
            _sr = sr;
            _oThread = new Thread(Read);
        }

        public void ReadMessage() {
            _oThread.Start();
        }

        private static void Read() {
            while (true) {
                string message = _sr.ReadLine();
                if (message != null) {
                    Console.WriteLine("Server: " + message);
                    message = null;
                }
            }
        }
    }
}
