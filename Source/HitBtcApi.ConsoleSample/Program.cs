using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitBtcApi.ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HitBtcApi.Core.StreamingApiClient();
            client.StartAsync().Wait();
            System.Console.WriteLine("Press Any Key to end.");
            System.Console.ReadKey();
        }
    }
}
