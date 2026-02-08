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
            // Attempt to retrieve current domain credentials
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Domain found: {Domain.GetCurrentDomain()}");
                Console.ForegroundColor = ConsoleColor.White;
                return Domain.GetCurrentDomain();
            }
            // Exception thrown if an Active Directory object could not be constructed/located
            catch (ActiveDirectoryObjectNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception thrown: Could not find an available domain. Check join status or network settings and try again");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
        }
    }
}