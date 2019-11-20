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
    public class AdministrativeUnitController : Controller
    {
        private readonly AppDbContext _context;
    
        
        public AdministrativeUnitController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdministrativeUnit
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdministrativeUnits.ToListAsync());
        }

        // GET: AdministrativeUnit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUnit = await _context.AdministrativeUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrativeUnit == null)
            {
                return NotFound();
            }

            return View(administrativeUnit);
        }

        // GET: AdministrativeUnit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdministrativeUnit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] AdministrativeUnit administrativeUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrativeUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrativeUnit);
        }

        // GET: AdministrativeUnit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUnit = await _context.AdministrativeUnits.FindAsync(id);
            if (administrativeUnit == null)
            {
                return NotFound();
            }
            return View(administrativeUnit);
        }

        // POST: AdministrativeUnit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] AdministrativeUnit administrativeUnit)
        {
            if (id != administrativeUnit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrativeUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministrativeUnitExists(administrativeUnit.Id))
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
            return View(administrativeUnit);
        }

        // GET: AdministrativeUnit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrativeUnit = await _context.AdministrativeUnits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrativeUnit == null)
            {
                return NotFound();
            }

            return View(administrativeUnit);
        }

        // POST: AdministrativeUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrativeUnit = await _context.AdministrativeUnits.FindAsync(id);
            _context.AdministrativeUnits.Remove(administrativeUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministrativeUnitExists(int id)
        {
            return _context.AdministrativeUnits.Any(e => e.Id == id);
        }
    }
}
