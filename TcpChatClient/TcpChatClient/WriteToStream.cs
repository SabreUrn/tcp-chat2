using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatClient {
    /// <summary>
    /// Writes data as strings to a StreamWriter in a separate thread.
    /// </summary>
    public class WriteToStream {
        private static StreamWriter _sw;
        private static Thread _oThread;

        /// <summary>
        /// Initialises a new instance of WriteToStream for the specified StreamWriter.
        /// </summary>
        /// <param name="sw">StreamWriter created with a NetworkStream.</param>
        public WriteToStream(StreamWriter sw) {
            _sw = sw;
            _sw.AutoFlush = true;
            _oThread = new Thread(Write);
            _oThread.Start();
        }

        /// <summary>
        /// Infinitely writes to the StreamWriter for use with its own thread.
        /// </summary>
        private static void Write() {
            while (true) {
                _sw.WriteLine(Console.ReadLine());
            }
        }
    }
}
