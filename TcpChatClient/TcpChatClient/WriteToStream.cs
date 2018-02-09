using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatClient {
    public class WriteToStream {
        private static StreamWriter _sw;
        private static Thread _oThread;

        public WriteToStream(StreamWriter sw) {
            _sw = sw;
            _sw.AutoFlush = true;
        }

        public void WriteMessage() {
            //string message = Console.ReadLine();
            //Write(message);
            _oThread = new Thread(Write);
            _oThread.Start();
        }

        private static void Write() {
            while (true) {
                _sw.WriteLine(Console.ReadLine());
            }
        }
    }
}
