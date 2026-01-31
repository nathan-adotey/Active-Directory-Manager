using System;
using System.Collections.Generic;
using System.Text;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ActiveDirectoryManager.SystemTools
{
    class NetManager // Performs simple system-level networking functions
    {
        public bool useDNS;
        NetManager() 
        {
            useDNS = true;
        }
        
        // ASYNC ping task with by hostname 
        public static async Task<bool> ValidateDomainAvailability(string domainName)
        {
            using Ping ping = new();
            try
            {
                PingReply re = await ping.SendPingAsync(domainName, 5000);
                if ((re != null) || re.Status == IPStatus.Success)
                {
                    Console.WriteLine($"Successful reply from {domainName}");
                    Console.WriteLine($"{domainName} ({re.Address})");
                    Console.WriteLine($"Reply time ({re.RoundtripTime}) ms");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Ping error: {re.Status}");
                    return false;
                }
            }
            catch (PingException ex)
            {
                Console.WriteLine($"Exception thrown: {ex.Message}");
                return false;
            }
        }
    }
}
