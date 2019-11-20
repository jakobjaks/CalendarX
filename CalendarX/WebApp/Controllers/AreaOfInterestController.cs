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
    public class AreaOfInterestController : Controller
    {
        private readonly AppDbContext _context;

        public AreaOfInterestController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AreaOfInterest
        public async Task<IActionResult> Index()
        {
            return View(await _context.AreaOfInterests.ToListAsync());
        }

        // GET: AreaOfInterest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaOfInterest = await _context.AreaOfInterests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaOfInterest == null)
            {
                return NotFound();
            }

            return View(areaOfInterest);
        }

        // GET: AreaOfInterest/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AreaOfInterest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] AreaOfInterest areaOfInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(areaOfInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(areaOfInterest);
        }

        // GET: AreaOfInterest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaOfInterest = await _context.AreaOfInterests.FindAsync(id);
            if (areaOfInterest == null)
            {
                return NotFound();
            }
            return View(areaOfInterest);
        }

        // POST: AreaOfInterest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] AreaOfInterest areaOfInterest)
        {
            if (id != areaOfInterest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(areaOfInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaOfInterestExists(areaOfInterest.Id))
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
            return View(areaOfInterest);
        }

        // GET: AreaOfInterest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var areaOfInterest = await _context.AreaOfInterests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (areaOfInterest == null)
            {
                return NotFound();
            }

            return View(areaOfInterest);
        }

        // POST: AreaOfInterest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var areaOfInterest = await _context.AreaOfInterests.FindAsync(id);
            _context.AreaOfInterests.Remove(areaOfInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AreaOfInterestExists(int id)
        {
            return _context.AreaOfInterests.Any(e => e.Id == id);
        }
    }
}
