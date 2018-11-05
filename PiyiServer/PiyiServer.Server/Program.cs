using System;
using System.Net;
using System.Net.Sockets;
using Nancy.Hosting.Self;

namespace PiyiServer.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var uri = new Uri("http://127.0.0.1");
            var port = "3307";
            var adds = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var ip in adds)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    uri = new Uri("http://" + ip + ":" + port);
                }
            }

            using (var host = new NancyHost(uri))
            {
                host.Start();

                Console.WriteLine(DateTime.Now + " : host [" + uri + "] 启动成功！");
                Console.ReadLine();
            }
        }
    }
}
