using System;
using System.Net.Http;

namespace SimpleHttpRequester
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "MyConsoleBrowser/1.0");

            HttpResponseMessage message = await client.GetAsync("https://www.swu.bg/bg/");

            string content = await message.Content.ReadAsStringAsync();

            //Console.WriteLine(content);

            File.WriteAllText("../../../index.html", content);

        }
    }
}
