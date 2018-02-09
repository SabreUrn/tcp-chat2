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
        private static Dictionary<string, TcpClient> _users; //name, obj
        private static TcpListener serverSocket = new TcpListener(IPAddress.Any, 6789);


        static void Main(string[] args) {
            //set up basics (NetworkStream?)
            _users = new Dictionary<string, TcpClient>();
            StartServer();
            //TcpListener serverSocket = new TcpListener(IPAddress.Any, 6789);
            //serverSocket.Start();
            //Console.WriteLine("Server started.");

            //TcpClient connectionSocket;
            //while(true) {

                //connectionSocket = serverSocket.AcceptTcpClient();
                //ThreadPool.QueueUserWorkItem(DoClient, connectionSocket);
            //}

            Console.ReadKey();


        }

        private static void StartServer() {
            serverSocket.Start();
            Console.WriteLine("Server started.");
            AcceptConnection();
        }

        private static void AcceptConnection() {
            serverSocket.BeginAcceptTcpClient(DoClient, serverSocket);

        }

        //DoClient()
        //client class?
        //add number to client for identification (property?)
        //sign-up where client is asked for own ID?
        private static void DoClient(IAsyncResult result) {
            AcceptConnection();
            TcpClient client = serverSocket.EndAcceptTcpClient(result);
            string clientName = $"Client {_users.Count + 1}";
            _users.Add(clientName, client);
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true;
            StreamReader sr = new StreamReader(ns);
            ReadFromStream reader = new ReadFromStream(sr, clientName);
            WriteToStream writer = new WriteToStream(sw, clientName);


            Console.WriteLine("Client connected.");
        }

    }
}
