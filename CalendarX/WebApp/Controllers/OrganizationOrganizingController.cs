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
    public class OrganizationOrganizingController : Controller
    {
        private readonly AppDbContext _context;

        public OrganizationOrganizingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OrganizationOrganizing
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.OrganizationOrganizings.Include(o => o.Event).Include(o => o.Organization);
            return View(await appDbContext.ToListAsync());
        }

        // GET: OrganizationOrganizing/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationOrganizing = await _context.OrganizationOrganizings
                .Include(o => o.Event)
                .Include(o => o.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationOrganizing == null)
            {
                return NotFound();
            }

            return View(organizationOrganizing);
        }

        // GET: OrganizationOrganizing/Create
        public IActionResult Create()
        {
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id");
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id");
            return View();
        }

        // POST: OrganizationOrganizing/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,OrganizationId,Id")] OrganizationOrganizing organizationOrganizing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organizationOrganizing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", organizationOrganizing.EventId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", organizationOrganizing.OrganizationId);
            return View(organizationOrganizing);
        }

        // GET: OrganizationOrganizing/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationOrganizing = await _context.OrganizationOrganizings.FindAsync(id);
            if (organizationOrganizing == null)
            {
                return NotFound();
            }
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", organizationOrganizing.EventId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", organizationOrganizing.OrganizationId);
            return View(organizationOrganizing);
        }

        // POST: OrganizationOrganizing/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,OrganizationId,Id")] OrganizationOrganizing organizationOrganizing)
        {
            if (id != organizationOrganizing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizationOrganizing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizationOrganizingExists(organizationOrganizing.Id))
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
            ViewData["EventId"] = new SelectList(_context.Events, "Id", "Id", organizationOrganizing.EventId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "Id", organizationOrganizing.OrganizationId);
            return View(organizationOrganizing);
        }

        // GET: OrganizationOrganizing/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizationOrganizing = await _context.OrganizationOrganizings
                .Include(o => o.Event)
                .Include(o => o.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organizationOrganizing == null)
            {
                return NotFound();
            }

            return View(organizationOrganizing);
        }

        // POST: OrganizationOrganizing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organizationOrganizing = await _context.OrganizationOrganizings.FindAsync(id);
            _context.OrganizationOrganizings.Remove(organizationOrganizing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizationOrganizingExists(int id)
        {
            return _context.OrganizationOrganizings.Any(e => e.Id == id);
        }
    }
}
