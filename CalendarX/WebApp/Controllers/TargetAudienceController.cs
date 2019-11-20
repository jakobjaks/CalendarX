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
    public class TargetAudienceController : Controller
    {
        private readonly AppDbContext _context;

        public TargetAudienceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TargetAudience
        public async Task<IActionResult> Index()
        {
            return View(await _context.TargetAudiences.ToListAsync());
        }

        // GET: TargetAudience/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetAudience = await _context.TargetAudiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetAudience == null)
            {
                return NotFound();
            }

            return View(targetAudience);
        }

        // GET: TargetAudience/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TargetAudience/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] TargetAudience targetAudience)
        {
            if (ModelState.IsValid)
            {
                _context.Add(targetAudience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(targetAudience);
        }

        // GET: TargetAudience/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetAudience = await _context.TargetAudiences.FindAsync(id);
            if (targetAudience == null)
            {
                return NotFound();
            }
            return View(targetAudience);
        }

        // POST: TargetAudience/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] TargetAudience targetAudience)
        {
            if (id != targetAudience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(targetAudience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TargetAudienceExists(targetAudience.Id))
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
            return View(targetAudience);
        }

        // GET: TargetAudience/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetAudience = await _context.TargetAudiences
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetAudience == null)
            {
                return NotFound();
            }

            return View(targetAudience);
        }

        // POST: TargetAudience/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var targetAudience = await _context.TargetAudiences.FindAsync(id);
            _context.TargetAudiences.Remove(targetAudience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TargetAudienceExists(int id)
        {
            return _context.TargetAudiences.Any(e => e.Id == id);
        }
    }
}
