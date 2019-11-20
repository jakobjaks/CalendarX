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
    public class SponsorInEventController : Controller
    {
        private readonly AppDbContext _context;

        public SponsorInEventController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SponsorInEvent
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.SponsorInEvents.Include(s => s.Event).Include(s => s.Organization);
            return View(await appDbContext.ToListAsync());
        }

        // GET: SponsorInEvent/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsorInEvent = await _context.SponsorInEvents
                .Include(s => s.Event)
                .Include(s => s.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponsorInEvent == null)
            {
                return NotFound();
            }

            return View(sponsorInEvent);
        }

        // GET: SponsorInEvent/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id");
            return View();
        }

        // POST: SponsorInEvent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,OrganizationId,Id")] SponsorInEvent sponsorInEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sponsorInEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", sponsorInEvent.EventId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", sponsorInEvent.OrganizationId);
            return View(sponsorInEvent);
        }

        // GET: SponsorInEvent/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsorInEvent = await _context.SponsorInEvents.FindAsync(id);
            if (sponsorInEvent == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", sponsorInEvent.EventId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", sponsorInEvent.OrganizationId);
            return View(sponsorInEvent);
        }

        // POST: SponsorInEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,OrganizationId,Id")] SponsorInEvent sponsorInEvent)
        {
            if (id != sponsorInEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sponsorInEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SponsorInEventExists(sponsorInEvent.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", sponsorInEvent.EventId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", sponsorInEvent.OrganizationId);
            return View(sponsorInEvent);
        }

        // GET: SponsorInEvent/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sponsorInEvent = await _context.SponsorInEvents
                .Include(s => s.Event)
                .Include(s => s.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sponsorInEvent == null)
            {
                return NotFound();
            }

            return View(sponsorInEvent);
        }

        // POST: SponsorInEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sponsorInEvent = await _context.SponsorInEvents.FindAsync(id);
            _context.SponsorInEvents.Remove(sponsorInEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SponsorInEventExists(int id)
        {
            return _context.SponsorInEvents.Any(e => e.Id == id);
        }
    }
}
