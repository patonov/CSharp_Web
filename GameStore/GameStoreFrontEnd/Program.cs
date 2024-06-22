using GameStoreFrontEnd.Clients;
using GameStoreFrontEnd.Components;

namespace GameStoreFrontEnd
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var gameStoreApiUrl = builder.Configuration["GameStoreApiUrl"] ??
                throw new Exception("GameStoreApiUrl is not properly set.");

            builder.Services.AddHttpClient<GameClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));

            builder.Services.AddHttpClient<GenreClient>(client => client.BaseAddress = new Uri(gameStoreApiUrl));

            builder.Services.AddSingleton<GameClient>();
            builder.Services.AddSingleton<GenreClient>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
