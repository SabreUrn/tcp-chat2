using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpChatServer {
    class Program {
        static void Main(string[] args) {

            //set up basics (NetworkStream?)
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 6789);
            TcpClient connectionSocket;
            serverSocket.Start();

            while(true) {
                connectionSocket = serverSocket.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(DoClient, connectionSocket);
            }
        }

        static void Run() {
            //listen for clients
            //DoClient() where client properties are initialised
            //
        }


        //ReadMessage()
        //WriteMessage()

        //DoClient()
            //client class?
            //add number to client for identification (property?)
            //sign-up where client is asked for own ID?
        private static void DoClient(object obj) {
            TcpClient client = (TcpClient)obj;
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            StreamReader sr = new StreamReader(ns);
        }
    }
}
