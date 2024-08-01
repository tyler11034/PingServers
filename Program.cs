using System;
using System.Net.NetworkInformation;

namespace Tyler_sServerPingApp
{
    class Server
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Server(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }

    class Program
    {
        static void Main()
        {
            Server[] servers = {
                new Server("_NAME_", "_Address_"),
            };

            foreach (var server in servers)
            {
                PingServer(server);
            }

            Console.ReadLine(); // Keep the console window open
        }

        static void PingServer(Server server)
        {
            using Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(server.Address);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine($"{server.Name}, {server.Address} is reachable. Response time: {reply.RoundtripTime} ms");
                }
                else
                {
                    Console.WriteLine($"{server.Name}, {server.Address} is unreachable. Error: {reply.Status}");
                }
            }
            catch (PingException ex)
            {
                Console.WriteLine($"Error pinging {server.Name}, {server.Address}: {ex.Message}");
            }
        }
    }
}
