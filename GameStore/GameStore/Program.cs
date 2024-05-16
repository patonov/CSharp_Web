using GameStore.Dtos;
using GameStore.EndPoints;
using System.Reflection.Metadata.Ecma335;

namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGameEndpoints();                        

            app.Run();

        }
    }
}
