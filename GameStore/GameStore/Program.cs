using GameStore.Data;
using GameStore.Dtos;
using GameStore.EndPoints;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace GameStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 
               
            builder.Services.AddDbContext<GameStoreDbContext>(options => options.UseSqlServer(connectionString));

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            app.MapGameEndpoints(); 
            
            app.MigrateDb();

            app.Run();

        }
    }
}
