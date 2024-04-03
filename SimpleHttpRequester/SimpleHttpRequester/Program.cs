using System;
using System.Net.Http;
using System.Text;

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



            var activationUrl = "https://mail.bg/auth/lgn";

            var postData = "user=patonec@mail.bg&pass=urungel!great";
            StringContent uhuu = new StringContent(postData, Encoding.UTF8, "application/json"); 
            
            var response = await client.PostAsync(activationUrl, uhuu);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                Console.WriteLine(result);
            }

        }
    }
}
