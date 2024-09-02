using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Named Pipe Server started...");

            while (true)
            {
                using (var server = new NamedPipeServerStream("testpipe", PipeDirection.InOut))
                {
                    server.WaitForConnection();

                    using (var reader = new StreamReader(server))
                    using (var writer = new StreamWriter(server) { AutoFlush = true })
                    {
                        writer.WriteLine("Hello from the server!");
                        string clientMessage = reader.ReadLine();
                        Console.WriteLine("Received from client: " + clientMessage);
                    }
                }
            }
        }
    }
}
