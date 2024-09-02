using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Named Pipe Client started...");

            while (true)
            {
                using (var client = new NamedPipeClientStream(".", "testpipe", PipeDirection.InOut))
                {
                    client.Connect();

                    using (var reader = new StreamReader(client))
                    using (var writer = new StreamWriter(client) { AutoFlush = true })
                    {
                        string serverMessage = reader.ReadLine();
                        Console.WriteLine("Received from server: " + serverMessage);
                        writer.WriteLine("Hello from the client!");
                    }
                }

                Thread.Sleep(3000);
            }
        }
    }
}
