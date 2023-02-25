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
    public class ParkingHousesController : Controller
    {
        private readonly ParkingHouseSystemContext _context;

        public ParkingHousesController(ParkingHouseSystemContext context)
        {
            _context = context;
        }

        // GET: ParkingHouses
        public async Task<IActionResult> Index()
        {
              return _context.ParkingHouses != null ? 
                          View(await _context.ParkingHouses.ToListAsync()) :
                          Problem("Entity set 'ParkingHouseSystemContext.ParkingHouses'  is null.");
        }

        // GET: ParkingHouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkingHouses == null)
            {
                return NotFound();
            }

            var parkingHouse = await _context.ParkingHouses
                .FirstOrDefaultAsync(m => m.ParkingHouseId == id);
            if (parkingHouse == null)
            {
                return NotFound();
            }

            return View(parkingHouse);
        }

        // GET: ParkingHouses/Create
        public IActionResult Create()
        {
            ParkingHouseViewModel house = new ParkingHouseViewModel();
            house.ParkingHouseLevels.Add(new ParkingHouseLevel());
            return View(house);
        }

        // POST: ParkingHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParkingHouseViewModel parkingHouseViewModel)
        {
            if (ModelState.IsValid)
            {
                var parkingHouse = new ParkingHouse();
                parkingHouse = parkingHouseViewModel.ParkingHouses;
                parkingHouse.ParkingHouseLevels = parkingHouseViewModel.ParkingHouseLevels;
                _context.Add(parkingHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkingHouseViewModel);
        }

        // GET: ParkingHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingHouses == null)
            {
                return NotFound();
            }

            var parkingHouse = await _context.ParkingHouses.Include(p => p.ParkingHouseLevels)
                                          .Include(p => p.Prices).Where(p => p.ParkingHouseId == id).FirstOrDefaultAsync();
            if (parkingHouse == null)
            {
                return NotFound();
            }

            var parkingHouseViewModel = new ParkingHouseViewModel();
            parkingHouseViewModel.ParkingHouses = parkingHouse;
            parkingHouseViewModel.ParkingHouseLevels = parkingHouse.ParkingHouseLevels;

            return View(parkingHouseViewModel);
        }

        // POST: ParkingHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ParkingHouseViewModel parkingHouseViewModel)
        {
            //if (id != parkingHouseViewModel.ParkingHouses.ParkingHouseId)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                //try
                //{
                //    _context.Update(parkingHouse);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!ParkingHouseExists(parkingHouse.ParkingHouseId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return RedirectToAction(nameof(Index));
            }
            return View(parkingHouseViewModel);
        }

        // GET: ParkingHouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkingHouses == null)
            {
                return NotFound();
            }

            var parkingHouse = await _context.ParkingHouses
                .FirstOrDefaultAsync(m => m.ParkingHouseId == id);
            if (parkingHouse == null)
            {
                return NotFound();
            }

            return View(parkingHouse);
        }

        // POST: ParkingHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkingHouses == null)
            {
                return Problem("Entity set 'ParkingHouseSystemContext.ParkingHouses'  is null.");
            }
            var parkingHouse = await _context.ParkingHouses.FindAsync(id);
            if (parkingHouse != null)
            {
                _context.ParkingHouses.Remove(parkingHouse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingHouseExists(int id)
        {
          return (_context.ParkingHouses?.Any(e => e.ParkingHouseId == id)).GetValueOrDefault();
        }
    }
}
