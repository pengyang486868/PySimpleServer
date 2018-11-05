using System;
using System.IO;
using System.Net;
using System.Text;

namespace PiyiClient.TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = "http://192.168.1.41:3307/";
            var pattern = "Hello/hel";

            //var request = (HttpWebRequest)WebRequest.Create(server + pattern);
            var request = WebRequest.Create(server + pattern);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            var response = request.GetResponse();
            var stream = response.GetResponseStream();

            if (stream != null)
            {
                var sr = new StreamReader(stream, Encoding.UTF8);
                var retString = sr.ReadToEnd();
                sr.Close();
                stream.Close();

                Console.WriteLine(retString);
            }

            Console.ReadKey();
        }
    }
}
