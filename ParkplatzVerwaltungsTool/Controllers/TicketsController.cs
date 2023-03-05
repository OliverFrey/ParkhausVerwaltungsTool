using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkplatzVerwaltungsTool.Models;

namespace ParkplatzVerwaltungsTool.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ParkingHouseSystemContext _context;

        public TicketsController(ParkingHouseSystemContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
              return _context.Tickets != null ? 
                          View(await _context.Tickets.ToListAsync()) :
                          Problem("Entity set 'ParkingHouseSystemContext.Tickets'  is null.");
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketId,EntryTime,ExitDate,TotalCost,ParkingHouseId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TicketId,EntryTime,ExitDate,TotalCost,ParkingHouseId")] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tickets == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tickets == null)
            {
                return Problem("Entity set 'ParkingHouseSystemContext.Tickets'  is null.");
            }
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
          return (_context.Tickets?.Any(e => e.TicketId == id)).GetValueOrDefault();
        }


        //Hier wird auf Knopfdruck ein neues Ticket erstellt.
        public async Task<IActionResult> CreateTicket(ParkingPlace parkingPlace)
        {
            Ticket newTicket = new Ticket();
            newTicket.EntryTime = DateTime.Now;
            newTicket.ParkingPlaceId = parkingPlace.ParkingPlaceId;
            _context.Add(newTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Hier wird das Ticket abgeschlossen und der Preis berechnet
        public async Task<IActionResult> CloseTicket(Ticket ticket)
        {
            ticket.ExitDate = DateTime.Now;

            ticket.TotalCost = CalculateTotalCost(ticket);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public double CalculateTotalCost(Ticket ticket)
        {
            var totalCost = 0.0;
            var prices = _context.Prices.Where(p => p.ParkingHouseId == ticket.ParkingHouseId);
            var parkingTime = ticket.ExitDate - ticket.EntryTime;


            TimeSpan oneDayInHours = TimeSpan.Parse("23:59:59");
            if (parkingTime >= oneDayInHours)
            {
                //Calculate based on DayPrices
            }
            else
            {
                //Calculate based on HourPrices
            }



            return totalCost;
        }
    }
}
