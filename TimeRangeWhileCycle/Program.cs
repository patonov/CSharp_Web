using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Timers;

namespace TimeRangeWhileCycle
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var startTime = DateTime.Now;
            var endTime = startTime.AddHours(3);
            var currentTime = startTime;

            HttpClient client = new HttpClient();
            var future = startTime.AddSeconds(30);

            while (currentTime <= endTime)
            {
                if (DateTime.Now.ToString() == future.ToString())
                {
                    HttpResponseMessage message =
                     await client.GetAsync("https://fcsapi.com/api-v3/forex/latest?symbol=EUR/USD&access_key=R0zdzWGUdSz0xu5iIzhZl");

                    string result = await message.Content.ReadAsStringAsync();

                    Console.WriteLine(result);
                    Console.WriteLine("==============================================");

                    future = currentTime.AddSeconds(30);

                }
                currentTime = DateTime.Now;

            }


        }
    }
}
