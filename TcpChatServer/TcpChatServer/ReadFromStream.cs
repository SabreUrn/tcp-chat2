using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatServer {
    public class ReadFromStream {
        private static StreamReader _sr;
        private static Thread _oThread;

        public ReadFromStream(StreamReader sr) {
            _sr = sr;
            _oThread = new Thread(Read);
        }
        
        public void ReadMessage() {
            //Task task = new Task(Read);
            _oThread.Start();
        }

        private static void Read() {
            while(true) {
                string message = _sr.ReadLine();
                if(message != null) {
                    Console.WriteLine("Client: " + message);
                    message = null;
                }
            }
        }
    }
}
