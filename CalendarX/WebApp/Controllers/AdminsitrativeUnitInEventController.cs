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
    public class AdminsitrativeUnitInEventController : Controller
    {
        private readonly AppDbContext _context;

        public AdminsitrativeUnitInEventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdminsitrativeUnitInEvent
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AdministrativeUnitInEvents.Include(a => a.AdministrativeUnit).Include(a => a.Event);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AdminsitrativeUnitInEvent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUnitInEvent = await _context.AdministrativeUnitInEvents
                .Include(a => a.AdministrativeUnit)
                .Include(a => a.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrativeUnitInEvent == null)
            {
                return NotFound();
            }

            return View(administrativeUnitInEvent);
        }

        // GET: AdminsitrativeUnitInEvent/Create
        public IActionResult Create()
        {
            ViewData["AdministrativeUnitId"] = new SelectList(_context.AdministrativeUnits, "Id", "Id");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            return View();
        }

        // POST: AdminsitrativeUnitInEvent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdministrativeUnitId,EventId,Id")] AdministrativeUnitInEvent administrativeUnitInEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrativeUnitInEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdministrativeUnitId"] = new SelectList(_context.AdministrativeUnits, "Id", "Id", administrativeUnitInEvent.AdministrativeUnitId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", administrativeUnitInEvent.EventId);
            return View(administrativeUnitInEvent);
        }

        // GET: AdminsitrativeUnitInEvent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUnitInEvent = await _context.AdministrativeUnitInEvents.FindAsync(id);
            if (administrativeUnitInEvent == null)
            {
                return NotFound();
            }
            ViewData["AdministrativeUnitId"] = new SelectList(_context.AdministrativeUnits, "Id", "Id", administrativeUnitInEvent.AdministrativeUnitId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", administrativeUnitInEvent.EventId);
            return View(administrativeUnitInEvent);
        }

        // POST: AdminsitrativeUnitInEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdministrativeUnitId,EventId,Id")] AdministrativeUnitInEvent administrativeUnitInEvent)
        {
            if (id != administrativeUnitInEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrativeUnitInEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrativeUnitInEventExists(administrativeUnitInEvent.Id))
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
            ViewData["AdministrativeUnitId"] = new SelectList(_context.AdministrativeUnits, "Id", "Id", administrativeUnitInEvent.AdministrativeUnitId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", administrativeUnitInEvent.EventId);
            return View(administrativeUnitInEvent);
        }

        // GET: AdminsitrativeUnitInEvent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUnitInEvent = await _context.AdministrativeUnitInEvents
                .Include(a => a.AdministrativeUnit)
                .Include(a => a.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrativeUnitInEvent == null)
            {
                return NotFound();
            }

            return View(administrativeUnitInEvent);
        }

        // POST: AdminsitrativeUnitInEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrativeUnitInEvent = await _context.AdministrativeUnitInEvents.FindAsync(id);
            _context.AdministrativeUnitInEvents.Remove(administrativeUnitInEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrativeUnitInEventExists(int id)
        {
            return _context.AdministrativeUnitInEvents.Any(e => e.Id == id);
        }
    }
}
