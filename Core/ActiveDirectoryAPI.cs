using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices.ActiveDirectory;

namespace ActiveDirectoryManager.Core
{
    class ActiveDirectoryAPI
    {
        public static Domain TryGetDomain()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Domain found: {Domain.GetCurrentDomain()}");
                Console.ForegroundColor = ConsoleColor.White;
                return Domain.GetCurrentDomain();
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception thrown: Check system join status or network connectivity to domain controller(s)");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
        }
    }
}
