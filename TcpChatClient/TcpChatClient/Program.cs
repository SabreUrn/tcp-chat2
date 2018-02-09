using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpChatClient {
    class Program {
        static void Main(string[] args) {
            //set up basics
            TcpClient clientSocket = WaitForServer();
            Console.WriteLine("Connected to server.");

            NetworkStream ns = clientSocket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            StreamReader sr = new StreamReader(ns);
            ReadFromStream reader = new ReadFromStream(sr);
            WriteToStream writer = new WriteToStream(sw);
            Console.WriteLine("Stream established.");

            reader.ReadMessage();
        }

        //WaitForServer()
        /// <summary>
        /// Attempts to connect to server.
        /// Catches SocketException and retries connection every 5 seconds until connection is achieved.
        /// </summary>
        /// <returns>Returns a TcpClient connected to server.</returns>
        private static TcpClient WaitForServer() {
            TcpClient clientSocket = new TcpClient();
            bool serverFound = false;

            while(!serverFound) {
                try {
                    clientSocket = new TcpClient("localhost", 6789);
                    serverFound = true;
                } catch(SocketException) {
                    Console.WriteLine("Cannot find server. Check if server is running.");
                    Console.WriteLine("Retrying in 5 seconds.");
                    System.Threading.Thread.Sleep(5000);
                }
            }

            return clientSocket;
        }
    }
}
