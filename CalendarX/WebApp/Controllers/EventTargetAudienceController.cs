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
    public class EventTargetAudienceController : Controller
    {
        private readonly AppDbContext _context;

        public EventTargetAudienceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventTargetAudience
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EventTargetAudiences.Include(e => e.Event).Include(e => e.TargetAudience);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EventTargetAudience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTargetAudience = await _context.EventTargetAudiences
                .Include(e => e.Event)
                .Include(e => e.TargetAudience)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventTargetAudience == null)
            {
                return NotFound();
            }

            return View(eventTargetAudience);
        }

        // GET: EventTargetAudience/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["TargetAudienceId"] = new SelectList(_context.TargetAudiences, "Id", "Id");
            return View();
        }

        // POST: EventTargetAudience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,TargetAudienceId,Id")] EventTargetAudience eventTargetAudience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventTargetAudience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventTargetAudience.EventId);
            ViewData["TargetAudienceId"] = new SelectList(_context.TargetAudiences, "Id", "Id", eventTargetAudience.TargetAudienceId);
            return View(eventTargetAudience);
        }

        // GET: EventTargetAudience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTargetAudience = await _context.EventTargetAudiences.FindAsync(id);
            if (eventTargetAudience == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventTargetAudience.EventId);
            ViewData["TargetAudienceId"] = new SelectList(_context.TargetAudiences, "Id", "Id", eventTargetAudience.TargetAudienceId);
            return View(eventTargetAudience);
        }

        // POST: EventTargetAudience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,TargetAudienceId,Id")] EventTargetAudience eventTargetAudience)
        {
            if (id != eventTargetAudience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventTargetAudience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventTargetAudienceExists(eventTargetAudience.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventTargetAudience.EventId);
            ViewData["TargetAudienceId"] = new SelectList(_context.TargetAudiences, "Id", "Id", eventTargetAudience.TargetAudienceId);
            return View(eventTargetAudience);
        }

        // GET: EventTargetAudience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventTargetAudience = await _context.EventTargetAudiences
                .Include(e => e.Event)
                .Include(e => e.TargetAudience)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventTargetAudience == null)
            {
                return NotFound();
            }

            return View(eventTargetAudience);
        }

        // POST: EventTargetAudience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventTargetAudience = await _context.EventTargetAudiences.FindAsync(id);
            _context.EventTargetAudiences.Remove(eventTargetAudience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventTargetAudienceExists(int id)
        {
            return _context.EventTargetAudiences.Any(e => e.Id == id);
        }
    }
}
