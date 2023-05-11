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
    public class AnimalsController : Controller
    {
        private readonly AnimalContext _context;

        public AnimalsController(AnimalContext context)
        {
            _context = context;
        }

        // GET: Animals
        public async Task<IActionResult> Index()
        {
              return _context.AnimalModel != null ? 
                          View(await _context.AnimalModel.ToListAsync()) :
                          Problem("Entity set 'AnimalContext.AnimalModel'  is null.");
        }

        // GET: Animals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AnimalModel == null)
            {
                return NotFound();
            }

            var animalModel = await _context.AnimalModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalModel == null)
            {
                return NotFound();
            }

            return View(animalModel);
        }

        // GET: Animals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SpeciesId,BirthDate")] AnimalModel animalModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animalModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(animalModel);
        }

        // GET: Animals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AnimalModel == null)
            {
                return NotFound();
            }

            var animalModel = await _context.AnimalModel.FindAsync(id);
            if (animalModel == null)
            {
                return NotFound();
            }
            return View(animalModel);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SpeciesId,BirthDate")] AnimalModel animalModel)
        {
            if (id != animalModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animalModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalModelExists(animalModel.Id))
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
            return View(animalModel);
        }

        // GET: Animals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AnimalModel == null)
            {
                return NotFound();
            }

            var animalModel = await _context.AnimalModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animalModel == null)
            {
                return NotFound();
            }

            return View(animalModel);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AnimalModel == null)
            {
                return Problem("Entity set 'AnimalContext.AnimalModel'  is null.");
            }
            var animalModel = await _context.AnimalModel.FindAsync(id);
            if (animalModel != null)
            {
                _context.AnimalModel.Remove(animalModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalModelExists(int id)
        {
          return (_context.AnimalModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
