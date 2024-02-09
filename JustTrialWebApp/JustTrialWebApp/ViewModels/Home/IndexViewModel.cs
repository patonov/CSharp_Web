namespace JustTrialWebApp.ViewModels.Home
{
    public class IndexViewModel
    {
        public string? Message { get; set; }

        public int Year { get; set; }

        public ICollection<string> Names { get; set; } = new List<string>();

        public string? HtmlGreet { get; set; }
    }
}
