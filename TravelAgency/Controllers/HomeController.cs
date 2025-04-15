using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TravelAgency.Models;
using TravelAgency.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {
        private readonly TravelAgencyDbContext _context;
        public HomeController(TravelAgencyDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index(Ticket ticket)
        {
            IEnumerable<Ticket> TicketList = _context.Tickets;
            return View(TicketList);
        }

        public IActionResult AddTicket()
        {
            return View();
        }


        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id != null)
            {
                Ticket? ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
                if (ticket != null) return View(ticket);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket(Ticket ticket)
        {
            ticket.TotalCost = (ticket.CostPerPerson * ticket.PersonCount) + ticket.Surcharge;

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id != null)
            {
                Ticket? ticket = await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
                if (ticket != null)
                {
                    _context.Tickets.Remove(ticket);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
