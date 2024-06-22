using GameStoreFrontEnd.Models;

namespace GameStoreFrontEnd.Clients
{
    public class GenreClient(HttpClient httpClient)
    {
        public async Task<Genre[]> GetGenresAsync()
            => await httpClient.GetFromJsonAsync<Genre[]>("genres") ?? []; 
    }
}
