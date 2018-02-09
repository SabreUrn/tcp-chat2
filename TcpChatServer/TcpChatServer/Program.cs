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
        //private static Dictionary<string, TcpClient> _users; //name, obj

        static void Main(string[] args) {

            //set up basics (NetworkStream?)
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 6789);
            serverSocket.Start();
            Console.WriteLine("Server started.");

            /* multi-clienting
            while(true) {
                connectionSocket = serverSocket.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(DoClient, connectionSocket);
            }
            */

            
            TcpClient connectionSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Connection accepted, server activated.");

            NetworkStream ns = connectionSocket.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            StreamReader sr = new StreamReader(ns);
            ReadFromStream reader = new ReadFromStream(sr);
            WriteToStream writer = new WriteToStream(sw);

            reader.ReadMessage();
        }


        //ReadMessage()
        //WriteMessage()

        //DoClient()
            //client class?
            //add number to client for identification (property?)
            //sign-up where client is asked for own ID?
        /* multi-clienting
        private static void DoClient(object obj) {
            TcpClient client = (TcpClient)obj;
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            StreamReader sr = new StreamReader(ns);
            Console.WriteLine("Client connected.");
        }
        */

    }
}
