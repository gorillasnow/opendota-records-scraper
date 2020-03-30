using System;
using System.IO;
using System.Net;

namespace HTTP_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpWebRequest testReq = (HttpWebRequest)WebRequest.Create("https://www.google.com/");
            WebResponse testResp = testReq.GetResponse();
            Console.WriteLine(((HttpWebResponse)testResp).StatusDescription);
            //  https://docs.microsoft.com/en-us/dotnet/framework/network-programming/how-to-request-data-using-the-webrequest-class
            // Get the stream containing content returned by the server.
            Stream dataStream = testResp.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            testResp.Close();
        }
    }
}