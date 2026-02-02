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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successful reply from {host} ({reply.Address}) in {reply.RoundtripTime}) ms");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Ping error: {reply.Status}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
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
            using Ping ping = new();  // Defactor once reference is out of scope
            PingReply reply = await ping.SendPingAsync(host, 3000);
            try
            {
                if (reply.Status == IPStatus.Success)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Successful reply from {host} ({reply.Address}) in {reply.RoundtripTime}) ms");
                    Console.ForegroundColor = ConsoleColor.White;
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Ping error: {reply.Status}");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
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