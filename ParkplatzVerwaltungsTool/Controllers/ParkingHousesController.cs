using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
            if (_context.ParkingHouses != null)
            {
                return View(await _context.ParkingHouses.ToListAsync());
            }
            else
            {
                return View(Problem("Entity set 'ParkingHouseSystemContext.ParkingHouses'  is null."));
            }
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
            ParkingHouseViewModel model = new ParkingHouseViewModel();
            model.ParkingHouses = new ParkingHouse();
            model.ParkingHouseLevels = new ParkingHouseLevel();
            model.ParkingPlaces = new ParkingPlace();
            return View();
        }

        // POST: ParkingHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParkingHouses,ParkingHouseLevels,ParkingPlaces")] ParkingHouseViewModel parkingHouseViewModel)
        {
            if (parkingHouseViewModel.ParkingHouses.ParkingHouseName != null && parkingHouseViewModel.ParkingHouseLevels.ParkingHouseLevelName != null && parkingHouseViewModel.ParkingPlaces.ParkingPlaceNumber != null)
            {
                parkingHouseViewModel.ParkingHouseLevels.ParkingPlaces.Add(parkingHouseViewModel.ParkingPlaces);
                parkingHouseViewModel.ParkingHouses.ParkingHouseLevels.Add(parkingHouseViewModel.ParkingHouseLevels);
                _context.ParkingPlaces.Add(parkingHouseViewModel.ParkingPlaces);
                _context.ParkingHouseLevels.Add(parkingHouseViewModel.ParkingHouseLevels);
                _context.ParkingHouses.Add(parkingHouseViewModel.ParkingHouses);
                await _context.SaveChangesAsync();
            }
            else if (parkingHouseViewModel.ParkingHouses.ParkingHouseName != null && parkingHouseViewModel.ParkingHouseLevels.ParkingHouseLevelName != null)
            {
                parkingHouseViewModel.ParkingHouses.ParkingHouseLevels.Add(parkingHouseViewModel.ParkingHouseLevels);
                _context.ParkingHouseLevels.Add(parkingHouseViewModel.ParkingHouseLevels);
                _context.ParkingHouses.Add(parkingHouseViewModel.ParkingHouses);
                await _context.SaveChangesAsync();
            }
            else if (parkingHouseViewModel.ParkingHouses.ParkingHouseName != null)
            {
                _context.ParkingHouses.Add(parkingHouseViewModel.ParkingHouses);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ParkingHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkingHouses == null)
            {
                return NotFound();
            }

            var parkingHouseViewModel = new ParkingHouseViewModel();

            var parkingHouse = await _context.ParkingHouses.FindAsync(id);
            if (parkingHouse == null)
            {
                return NotFound();
            }
            parkingHouseViewModel.ParkingHouses= parkingHouse;
            parkingHouseViewModel.ParkingHouseLevels = parkingHouse.ParkingHouseLevels.FirstOrDefault();
            parkingHouseViewModel.ParkingPlaces = await _context.ParkingPlaces.FindAsync();
            return View(parkingHouseViewModel);
        }

        // POST: ParkingHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParkingHouseId,ParkingHouseName")] ParkingHouse parkingHouse)
        {
            if (id != parkingHouse.ParkingHouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingHouseExists(parkingHouse.ParkingHouseId))
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
            return View(parkingHouse);
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

        public IActionResult AddLevel(int parkingHouseId)
        {
            var parkingHouse = _context.ParkingHouses.Find(parkingHouseId);
            if (parkingHouse != null)
            {
                var newLevel = new ParkingHouseLevel { ParkingHouseLevelName = "New Level" };
                parkingHouse.ParkingHouseLevels.Add(newLevel);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = parkingHouseId });
            }
            return NotFound();
        }
    }
}
