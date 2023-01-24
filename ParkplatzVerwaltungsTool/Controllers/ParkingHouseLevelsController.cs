using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ParkplatzVerwaltungsTool.Models;

namespace ParkplatzVerwaltungsTool.Controllers
{
    public class ParkingHouseLevelsController : Controller
    {
        private readonly ParkingHouseSystemContext _context;

        public ParkingHouseLevelsController(ParkingHouseSystemContext context)
        {
            _context = context;
        }

        // GET: ParkingHouseLevels
        public async Task<IActionResult> Index()
        {
              return _context.ParkingHouseLevels != null ? 
                          View(await _context.ParkingHouseLevels.ToListAsync()) :
                          Problem("Entity set 'ParkingHouseSystemContext.ParkingHouseLevels'  is null.");
        }

        // GET: ParkingHouseLevels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkingHouseLevels == null)
            {
                return NotFound();
            }

            var parkingHouseLevel = await _context.ParkingHouseLevels
                .FirstOrDefaultAsync(m => m.ParkingHouseLevelId == id);
            if (parkingHouseLevel == null)
            {
                return NotFound();
            }

            return View(parkingHouseLevel);
        }

        // GET: ParkingHouseLevels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkingHouseLevels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkingHouseLevelId,ParkingHouseLevelName")] ParkingHouseLevel parkingHouseLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingHouseLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingHouseLevel);
        }

        // GET: ParkingHouseLevels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingHouseLevels == null)
            {
                return NotFound();
            }

            var parkingHouseLevel = await _context.ParkingHouseLevels.FindAsync(id);
            if (parkingHouseLevel == null)
            {
                return NotFound();
            }
            return View(parkingHouseLevel);
        }

        // POST: ParkingHouseLevels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkingHouseLevelId,ParkingHouseLevelName")] ParkingHouseLevel parkingHouseLevel)
        {
            if (id != parkingHouseLevel.ParkingHouseLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingHouseLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingHouseLevelExists(parkingHouseLevel.ParkingHouseLevelId))
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
            return View(parkingHouseLevel);
        }

        // GET: ParkingHouseLevels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkingHouseLevels == null)
            {
                return NotFound();
            }

            var parkingHouseLevel = await _context.ParkingHouseLevels
                .FirstOrDefaultAsync(m => m.ParkingHouseLevelId == id);
            if (parkingHouseLevel == null)
            {
                return NotFound();
            }

            return View(parkingHouseLevel);
        }

        // POST: ParkingHouseLevels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkingHouseLevels == null)
            {
                return Problem("Entity set 'ParkingHouseSystemContext.ParkingHouseLevels'  is null.");
            }
            var parkingHouseLevel = await _context.ParkingHouseLevels.FindAsync(id);
            if (parkingHouseLevel != null)
            {
                _context.ParkingHouseLevels.Remove(parkingHouseLevel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingHouseLevelExists(int id)
        {
          return (_context.ParkingHouseLevels?.Any(e => e.ParkingHouseLevelId == id)).GetValueOrDefault();
        }
    }
}
