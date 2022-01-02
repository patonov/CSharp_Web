using System;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalDemoServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            const string NewLine = "\r\n";

            TcpListener listener = new TcpListener(IPAddress.Loopback, 1234);
            listener.Start();

            while (true)
            {
                TcpClient tcpClient = listener.AcceptTcpClient();
                using NetworkStream networkStream = tcpClient.GetStream();
                
                    byte[] requestedBytes = new byte[1000000];
                    int bytesRead = networkStream.Read(requestedBytes, 0, requestedBytes.Length);
                    string request = Encoding.UTF8.GetString(requestedBytes, 0, bytesRead);

                    string responseText = @"<form method='post'> 
                                    <input type=date name='date' />
                                    <input type=text name='username' />
                                    <input type=password name='password' />
                                    <input type=submit value='login' />
                                    </form>";

                       string response = "HTTP/1.0 200 OK" + NewLine +
                       "Server: PatonovServer/1.0" + NewLine +
                       "Content-Type: text/html" + NewLine +
                       "Content-Lenght: " + responseText.Length + NewLine +
                       NewLine +
                       responseText;

                //string response = "HTTP/1.0 307 OK" + NewLine +
                    //"Server: PatonovServer/1.0" + NewLine +
                   // "Content-Type: text/html" + NewLine +
                   // "Location: https://google.com" + NewLine +
                   // "Content-Lenght: " + responseText.Length + NewLine +
                   // NewLine +
                   // responseText;
                    
                    byte[] responseBytes = Encoding.UTF8.GetBytes(response);
                    networkStream.Write(responseBytes, 0, responseBytes.Length);

                    Console.WriteLine(request);
                    Console.WriteLine(new string('=', 60));
                
            }

        }


    }
}

