using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpRequester
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage message = await client.GetAsync("http://www.swu.bg/university-profile/structure/faculties.aspx");

            string result = await message.Content.ReadAsStringAsync();

            Console.WriteLine(result);
        }
    }
}
