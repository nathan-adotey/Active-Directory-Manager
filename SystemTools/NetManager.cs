using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;

namespace ActiveDirectoryManager.SystemTools
{
    public class NetManager // Performs simple system-level networking functions
    {
        // Ping host
        public static bool PingHost(string host)
        {
            using Ping ping = new();  // Defactor once reference is out of scope
            PingReply reply = ping.Send(host, 3000);
            try
            {   
                if (reply.Status == IPStatus.Success)
                {
                    // Successful reply from host
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successful reply from {host} ({reply.Address}) in {reply.RoundtripTime}) ms");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
                else
                {
                    // Prompt if host is unreachable
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Ping error: {reply.Status}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
            // Throw any exception
            catch (PingException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception thrown: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }

        // ASYNC task ping host
        public static async Task<bool> PingHostAsync(string host)
        {
            // Defactor once the reference is out of scope
            using Ping ping = new();  
            
            // Await for a reply before constructing a PingReply object
            PingReply reply = await ping.SendPingAsync(host, 3000);
            try
            {
                if (reply.Status == IPStatus.Success)
                {
                    // Successful reply from host
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successful reply from {host} ({reply.Address}) in {reply.RoundtripTime}) ms");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
                else
                {
                    // Prompt if host is unreachable
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Ping error: {reply.Status}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
            // Throw any exception
            catch (PingException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Exception thrown: {ex.Message}");
                Console.ForegroundColor = ConsoleColor.White;
                return false;
            }
        }
    }
}