using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace dk.via._420Connect.DataServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            SocketClient();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static void SocketClient()
        {
            Debug.WriteLine("Starting client..");

            TcpClient client = new TcpClient("localhost", 4012);

            NetworkStream stream = client.GetStream();

            byte[] dataToServer = Encoding.ASCII.GetBytes("Hello from client");
            stream.Write(dataToServer, 0, dataToServer.Length);

            byte[] dataFromServer = new byte[1024];
            int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
            string response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
            Debug.WriteLine(response);

            stream.Close();
            client.Close();
        }
    }
}
