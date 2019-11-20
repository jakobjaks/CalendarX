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
    public class EventInAreaOfInterestController : Controller
    {
        private readonly AppDbContext _context;

        public EventInAreaOfInterestController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventInAreaOfInterest
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.EventInAreaOfInterests.Include(e => e.AreaOfInterest).Include(e => e.Event);
            return View(await appDbContext.ToListAsync());
        }

        // GET: EventInAreaOfInterest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInAreaOfInterest = await _context.EventInAreaOfInterests
                .Include(e => e.AreaOfInterest)
                .Include(e => e.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventInAreaOfInterest == null)
            {
                return NotFound();
            }

            return View(eventInAreaOfInterest);
        }

        // GET: EventInAreaOfInterest/Create
        public IActionResult Create()
        {
            ViewData["AreaOfInterestId"] = new SelectList(_context.AreaOfInterests, "Id", "Id");
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            return View();
        }

        // POST: EventInAreaOfInterest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,AreaOfInterestId,Id")] EventInAreaOfInterest eventInAreaOfInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventInAreaOfInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaOfInterestId"] = new SelectList(_context.AreaOfInterests, "Id", "Id", eventInAreaOfInterest.AreaOfInterestId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventInAreaOfInterest.EventId);
            return View(eventInAreaOfInterest);
        }

        // GET: EventInAreaOfInterest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInAreaOfInterest = await _context.EventInAreaOfInterests.FindAsync(id);
            if (eventInAreaOfInterest == null)
            {
                return NotFound();
            }
            ViewData["AreaOfInterestId"] = new SelectList(_context.AreaOfInterests, "Id", "Id", eventInAreaOfInterest.AreaOfInterestId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventInAreaOfInterest.EventId);
            return View(eventInAreaOfInterest);
        }

        // POST: EventInAreaOfInterest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,AreaOfInterestId,Id")] EventInAreaOfInterest eventInAreaOfInterest)
        {
            if (id != eventInAreaOfInterest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventInAreaOfInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventInAreaOfInterestExists(eventInAreaOfInterest.Id))
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
            ViewData["AreaOfInterestId"] = new SelectList(_context.AreaOfInterests, "Id", "Id", eventInAreaOfInterest.AreaOfInterestId);
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", eventInAreaOfInterest.EventId);
            return View(eventInAreaOfInterest);
        }

        // GET: EventInAreaOfInterest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInAreaOfInterest = await _context.EventInAreaOfInterests
                .Include(e => e.AreaOfInterest)
                .Include(e => e.Event)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventInAreaOfInterest == null)
            {
                return NotFound();
            }

            return View(eventInAreaOfInterest);
        }

        // POST: EventInAreaOfInterest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventInAreaOfInterest = await _context.EventInAreaOfInterests.FindAsync(id);
            _context.EventInAreaOfInterests.Remove(eventInAreaOfInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventInAreaOfInterestExists(int id)
        {
            return _context.EventInAreaOfInterests.Any(e => e.Id == id);
        }
    }
}
