using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZooDatabase.Data;
using ZooDatabase.Models;

namespace ZooDatabase.Controllers
{
    public class SpeciesController : Controller
    {
        private readonly SpeciesContext _context;

        public SpeciesController(SpeciesContext context)
        {
            _context = context;
        }

        // GET: Species
        public async Task<IActionResult> Index()
        {
              return _context.SpeciesModel != null ? 
                          View(await _context.SpeciesModel.ToListAsync()) :
                          Problem("Entity set 'SpeciesContext.SpeciesModel'  is null.");
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SpeciesModel == null)
            {
                return NotFound();
            }

            var speciesModel = await _context.SpeciesModel
                .FirstOrDefaultAsync(m => m.SpeciesId == id);
            if (speciesModel == null)
            {
                return NotFound();
            }

            return View(speciesModel);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpeciesId,SpeciesName,Species,Diet,IsEndangered")] SpeciesModel speciesModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speciesModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(speciesModel);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SpeciesModel == null)
            {
                return NotFound();
            }

            var speciesModel = await _context.SpeciesModel.FindAsync(id);
            if (speciesModel == null)
            {
                return NotFound();
            }
            return View(speciesModel);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpeciesId,SpeciesName,Species,Diet,IsEndangered")] SpeciesModel speciesModel)
        {
            if (id != speciesModel.SpeciesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speciesModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeciesModelExists(speciesModel.SpeciesId))
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
            return View(speciesModel);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SpeciesModel == null)
            {
                return NotFound();
            }

            var speciesModel = await _context.SpeciesModel
                .FirstOrDefaultAsync(m => m.SpeciesId == id);
            if (speciesModel == null)
            {
                return NotFound();
            }

            return View(speciesModel);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SpeciesModel == null)
            {
                return Problem("Entity set 'SpeciesContext.SpeciesModel'  is null.");
            }
            var speciesModel = await _context.SpeciesModel.FindAsync(id);
            if (speciesModel != null)
            {
                _context.SpeciesModel.Remove(speciesModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeciesModelExists(int id)
        {
          return (_context.SpeciesModel?.Any(e => e.SpeciesId == id)).GetValueOrDefault();
        }
    }
}
