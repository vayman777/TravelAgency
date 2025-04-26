using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Models;
using TravelAgency.Core.Services;
using TravelAgency.Core.Contracts.Models;

namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITicketService ticketService;
        public HomeController(ITicketService ticketService)
        {
            this.ticketService = ticketService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await ticketService.GetTicketsAsync();
            return View(result.Select(r => new TicketResponse()
            {
                Id = r.Id,
                Direction = r.Direction,
                DepartureDate = r.DepartureDate,
                NumberOfNights = r.NumberOfNights,
                CostPerPerson = r.CostPerPerson,
                PersonCount = r.PersonCount,
                AvailabilityWiFi = r.AvailabilityWiFi,
                Surcharge = r.Surcharge,
                TotalCost = r.TotalCost
            }));
        }

        public IActionResult AddTicket()
        {
            return View();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            try
            {
               var ticket = await ticketService.GetTicketByIdAsync(id);
               await ticketService.UpdateAsync(ticket);
               return View(ticket);
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TicketResponse ticket)
        {
            var ticketDto = new TicketDto()
            {
                Id = ticket.Id,
                Direction = ticket.Direction,
                DepartureDate = ticket.DepartureDate,
                NumberOfNights = ticket.NumberOfNights,
                CostPerPerson = ticket.CostPerPerson,
                PersonCount = ticket.PersonCount,
                AvailabilityWiFi = ticket.AvailabilityWiFi,
                Surcharge = ticket.Surcharge,
                TotalCost = ticket.TotalCost
            };
            await ticketService.UpdateAsync(ticketDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(TicketResponse ticket)
        {
            var ticketDto = new TicketDto()
            {
                Id = ticket.Id,
                Direction = ticket.Direction,
                DepartureDate = ticket.DepartureDate,
                NumberOfNights = ticket.NumberOfNights,
                CostPerPerson = ticket.CostPerPerson,
                PersonCount = ticket.PersonCount,
                AvailabilityWiFi = ticket.AvailabilityWiFi,
                Surcharge = ticket.Surcharge,
                TotalCost = ticket.TotalCost
            };
            await ticketService.CreateAsync(ticketDto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            try
            {
                await ticketService.DeleteAsync(id);
                return RedirectToAction("Index");
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
