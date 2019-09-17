using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiLEndpointCall
{
    class Program
    {
        static void Main(string[] args)
        {
            AilAppService appService = new AilAppService();

            /* Ex 1 Execute an endpoint */
            string result = appService.ExecuteEndpoint("Endpoint_Hikers", "");
            Console.WriteLine(result);













            /* Ex 2 Accept a generic object back from the service */
            List<Hiker> hikers = appService.ExecuteEndpoint<List<Hiker>>("Endpoint_Hikers", "");
            hikers.ForEach(a => System.Console.WriteLine($"{a.Name}-{a.TrailName}"));












            /* Ex 3 Basic Authentication call */
            Credentials c = new Credentials() { Username = "myuser", Password = "mypass" };

            List<Hiker> hikerSecure = appService.ExecuteEndpointSecure<List<Hiker>>(c, "Endpoint_Hikers", "");
            hikers.ForEach(a => System.Console.WriteLine($"{a.Name}-{a.TrailName}"));

            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }

    public class Hiker
    {
        public string Name { get; set; }
        public string TrailName { get; set; }

    }

}
