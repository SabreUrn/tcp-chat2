using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatServer {
    public class WriteToStream {
        private static StreamWriter _sw;
        private static Thread _oThread;

        public WriteToStream(StreamWriter sw) {
            _sw = sw;
            _sw.AutoFlush = true;
            _oThread = new Thread(Write);
            _oThread.Start();
        }

        public void WriteMessage() {
            //_oThread = new Thread(Write);
            //_oThread.Start();
        }

        private static void Write() {
            while(true) {
                _sw.WriteLine(Console.ReadLine());
            }
        }
    }
}
