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
    public class PermamentUsersController : Controller
    {
        private readonly ParkingHouseSystemContext _context;

        public PermamentUsersController(ParkingHouseSystemContext context)
        {
            _context = context;
        }

        // GET: PermamentUsers
        public async Task<IActionResult> Index()
        {
              return _context.PermamentUsers != null ? 
                          View(await _context.PermamentUsers.ToListAsync()) :
                          Problem("Entity set 'ParkingHouseSystemContext.PermamentUsers'  is null.");
        }

        // GET: PermamentUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PermamentUsers == null)
            {
                return NotFound();
            }

            var permamentUser = await _context.PermamentUsers
                .FirstOrDefaultAsync(m => m.PermamentUserId == id);
            if (permamentUser == null)
            {
                return NotFound();
            }

            return View(permamentUser);
        }

        // GET: PermamentUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PermamentUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PermamentUserId,PermamentUserName,PlateNumber,ParkingPlaceNumber,LastPayDate")] PermamentUser permamentUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permamentUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permamentUser);
        }

        // GET: PermamentUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PermamentUsers == null)
            {
                return NotFound();
            }

            var permamentUser = await _context.PermamentUsers.FindAsync(id);
            if (permamentUser == null)
            {
                return NotFound();
            }
            return View(permamentUser);
        }

        // POST: PermamentUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PermamentUserId,PermamentUserName,PlateNumber,ParkingPlaceNumber,LastPayDate")] PermamentUser permamentUser)
        {
            if (id != permamentUser.PermamentUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permamentUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermamentUserExists(permamentUser.PermamentUserId))
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
            return View(permamentUser);
        }

        // GET: PermamentUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PermamentUsers == null)
            {
                return NotFound();
            }

            var permamentUser = await _context.PermamentUsers
                .FirstOrDefaultAsync(m => m.PermamentUserId == id);
            if (permamentUser == null)
            {
                return NotFound();
            }

            return View(permamentUser);
        }

        // POST: PermamentUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PermamentUsers == null)
            {
                return Problem("Entity set 'ParkingHouseSystemContext.PermamentUsers'  is null.");
            }
            var permamentUser = await _context.PermamentUsers.FindAsync(id);
            if (permamentUser != null)
            {
                _context.PermamentUsers.Remove(permamentUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermamentUserExists(int id)
        {
          return (_context.PermamentUsers?.Any(e => e.PermamentUserId == id)).GetValueOrDefault();
        }
    }
}
