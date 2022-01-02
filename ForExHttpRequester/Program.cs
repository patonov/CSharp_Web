using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForExHttpRequester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage message = 
                await client.GetAsync("https://fcsapi.com/api-v3/forex/latest?symbol=EUR/USD&access_key=R0zdzWGUdSz0xu5iIzhZl");

            string result = await message.Content.ReadAsStringAsync();

            Console.WriteLine(result);
        }
    }
}
