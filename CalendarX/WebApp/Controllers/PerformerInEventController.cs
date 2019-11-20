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
    public class PerformerInEventController : Controller
    {
        private readonly AppDbContext _context;

        public PerformerInEventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PerformerInEvent
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.PerformerInEvents.Include(p => p.Event).Include(p => p.Performer);
            return View(await appDbContext.ToListAsync());
        }

        // GET: PerformerInEvent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performerInEvent = await _context.PerformerInEvents
                .Include(p => p.Event)
                .Include(p => p.Performer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performerInEvent == null)
            {
                return NotFound();
            }

            return View(performerInEvent);
        }

        // GET: PerformerInEvent/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["PerformerId"] = new SelectList(_context.Performers, "Id", "Id");
            return View();
        }

        // POST: PerformerInEvent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PerformerId,EventId,Description,Name,Id")] PerformerInEvent performerInEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(performerInEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", performerInEvent.EventId);
            ViewData["PerformerId"] = new SelectList(_context.Performers, "Id", "Id", performerInEvent.PerformerId);
            return View(performerInEvent);
        }

        // GET: PerformerInEvent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performerInEvent = await _context.PerformerInEvents.FindAsync(id);
            if (performerInEvent == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", performerInEvent.EventId);
            ViewData["PerformerId"] = new SelectList(_context.Performers, "Id", "Id", performerInEvent.PerformerId);
            return View(performerInEvent);
        }

        // POST: PerformerInEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PerformerId,EventId,Description,Name,Id")] PerformerInEvent performerInEvent)
        {
            if (id != performerInEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(performerInEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerformerInEventExists(performerInEvent.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", performerInEvent.EventId);
            ViewData["PerformerId"] = new SelectList(_context.Performers, "Id", "Id", performerInEvent.PerformerId);
            return View(performerInEvent);
        }

        // GET: PerformerInEvent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var performerInEvent = await _context.PerformerInEvents
                .Include(p => p.Event)
                .Include(p => p.Performer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (performerInEvent == null)
            {
                return NotFound();
            }

            return View(performerInEvent);
        }

        // POST: PerformerInEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var performerInEvent = await _context.PerformerInEvents.FindAsync(id);
            _context.PerformerInEvents.Remove(performerInEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerformerInEventExists(int id)
        {
            return _context.PerformerInEvents.Any(e => e.Id == id);
        }
    }
}
