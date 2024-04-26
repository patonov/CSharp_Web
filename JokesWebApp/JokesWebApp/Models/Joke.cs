namespace JokesWebApp.Models
{
    public class Joke
    {
        public Joke()
        {
            
        }

        public int Id { get; set; }

        public string JokeQuestion { get; set; } = null!;

        public string JokeAnswer { get; set; } = null!;
    }
}
