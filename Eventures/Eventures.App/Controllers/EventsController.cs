using Eventures.App.Data;
using Eventures.App.Domain;
using Eventures.App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace Eventures.App.Controllers
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;

        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Create()
        {
            return this.View();
        }
        
        [HttpPost]
        public IActionResult Create(EventCreateBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                Event eventForDB = new Event
                {
                    Name = bindingModel.Name,
                    Place = bindingModel.Place,
                    Start = bindingModel.Start,
                    End = bindingModel.End,
                    TotalTickets = bindingModel.TotalTickets,
                    PricePerTicket = bindingModel.PricePerTicket
                };

                context.Events.Add(eventForDB);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }

            return this.View();
        }

        public IActionResult All()
        {
            List<EventAllViewModel> events = context.Events
                    .Select(eventFromDB => new EventAllViewModel
                    {
                        Name = eventFromDB.Name,
                        Place = eventFromDB.Place,
                        Start = eventFromDB.Start.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                        End = eventFromDB.End.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture)
                    }).ToList();

            return this.View(events);
        }
    }
}
