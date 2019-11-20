using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class EventInLocationController : Controller
    {
        private readonly AppDbContext _context;

        public EventInLocationController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventInLocation
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EventInLocations.Include(e => e.Event).Include(e => e.Location);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EventInLocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInLocation = await _context.EventInLocations
                .Include(e => e.Event)
                .Include(e => e.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventInLocation == null)
            {
                return NotFound();
            }

            return View(eventInLocation);
        }

        // GET: EventInLocation/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id");
            return View();
        }

        // POST: EventInLocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,LocationId,Id")] EventInLocation eventInLocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventInLocation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventInLocation.EventId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", eventInLocation.LocationId);
            return View(eventInLocation);
        }

        // GET: EventInLocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInLocation = await _context.EventInLocations.FindAsync(id);
            if (eventInLocation == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventInLocation.EventId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", eventInLocation.LocationId);
            return View(eventInLocation);
        }

        // POST: EventInLocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,LocationId,Id")] EventInLocation eventInLocation)
        {
            if (id != eventInLocation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventInLocation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventInLocationExists(eventInLocation.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventInLocation.EventId);
            ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Id", eventInLocation.LocationId);
            return View(eventInLocation);
        }

        // GET: EventInLocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInLocation = await _context.EventInLocations
                .Include(e => e.Event)
                .Include(e => e.Location)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventInLocation == null)
            {
                return NotFound();
            }

            return View(eventInLocation);
        }

        // POST: EventInLocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventInLocation = await _context.EventInLocations.FindAsync(id);
            _context.EventInLocations.Remove(eventInLocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventInLocationExists(int id)
        {
            return _context.EventInLocations.Any(e => e.Id == id);
        }
    }
}
