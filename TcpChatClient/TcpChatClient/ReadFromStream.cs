using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatClient {
    /// <summary>
    /// Reads data as strings from a StreamReader in a separate thread.
    /// </summary>
    public class ReadFromStream {
        private static StreamReader _sr;
        private static Thread _oThread;

        /// <summary>
        /// Initialises a new instance of ReadFromStream for the specified StreamReader and starts the thread.
        /// </summary>
        /// <param name="sr">StreamReader created with a NetworkStream.</param>
        public ReadFromStream(StreamReader sr) {
            _sr = sr;
            _oThread = new Thread(Read);

            _oThread.Start();
        }

        /// <summary>
        /// Infinitely reads from the StreamReader for use with its own thread.
        /// </summary>
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
