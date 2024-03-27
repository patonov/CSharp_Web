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

        public IActionResult All()
        {
            List<EventAllViewModel> events = context.Events
                    .Select(eventFromDB => new EventAllViewModel
                    {
                        Name = eventFromDB.Name,
                        Place = eventFromDB.Place,
                        Start = eventFromDB.Start.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                        End = eventFromDB.End.ToString("dd-MMM-yyyy HH:mm", CultureInfo.InvariantCulture),
                        Owner = eventFromDB.Owner.UserName
                    }).ToList();

            return this.View(events);
        }

        [HttpPost]
        public IActionResult Create(EventCreateBindingModel bindingModel)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                Event eventForDB = new Event
                {
                    Name = bindingModel.Name,
                    Place = bindingModel.Place,
                    Start = bindingModel.Start,
                    End = bindingModel.End,
                    TotalTickets = bindingModel.TotalTickets,
                    PricePerTicket = bindingModel.PricePerTicket,
                    OwnerId = currentUserId
                };

                context.Events.Add(eventForDB);
                context.SaveChanges();

                return this.RedirectToAction("All");
            }

            return this.View();
        }
    }
}
