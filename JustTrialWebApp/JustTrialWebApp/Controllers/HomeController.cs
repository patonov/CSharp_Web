using JustTrialWebApp.Models;
using JustTrialWebApp.ViewModels.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JustTrialWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private IConfiguration configuration;

        public HomeController(IConfiguration configuration)
        {
           this.configuration = configuration;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                Year = DateTime.UtcNow.Year,
                Message = this.configuration["YouTube:ApiKey"],
                Names = new List<string> { "Pesho", "Gosho", "Misho", "Ai ne me zanimaai veche!" },
                HtmlGreet = "<strong>Hello I am your HTML greet!</strong>"
        };
                

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test() 
        {
            return this.Content(this.configuration["YouTube:ApiKey"]);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
