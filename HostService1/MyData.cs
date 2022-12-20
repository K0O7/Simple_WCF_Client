using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HostService1
{
    class MyData
    {
        public static void info()
        {
            Console.WriteLine(DateTime.Now);
            Console.WriteLine("Piotr Duliński, 254500");
            Console.WriteLine(Environment.UserName);
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine(Environment.Version);
            Console.WriteLine(getIPv4Address());
        }

        public static string getIPv4Address()
        {
            IPAddress[] addr = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            return addr[addr.Length - 1].ToString();
        }
    }
}
