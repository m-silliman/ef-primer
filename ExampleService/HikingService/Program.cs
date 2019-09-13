using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikingService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Microsoft.Owin.Hosting.WebApp.Start<Startup>("http://localhost:12345"))
            {
                Console.WriteLine("Listening on port: 12345");
                Console.ReadLine();
            }
        }
    }
}
