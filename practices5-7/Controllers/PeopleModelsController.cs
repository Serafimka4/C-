using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practices5_7.Data;
using practices5_7.Models;

namespace practices5_7.Controllers
{
    public class PeopleModelsController : Controller
    {
        private readonly peopleContext _context;

        public PeopleModelsController(peopleContext context)
        {
            _context = context;
        }

        // GET: PeopleModels
        public async Task<IActionResult> Index()
        {
              return _context.PeopleModel != null ? 
                          View(await _context.PeopleModel.ToListAsync()) :
                          Problem("Entity set 'peopleContext.PeopleModel'  is null.");
        }

        // GET: PeopleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PeopleModel == null)
            {
                return NotFound();
            }

            var peopleModel = await _context.PeopleModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleModel == null)
            {
                return NotFound();
            }

            return View(peopleModel);
        }

        // GET: PeopleModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PeopleModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Awards")] PeopleModel peopleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(peopleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peopleModel);
        }

        // GET: PeopleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PeopleModel == null)
            {
                return NotFound();
            }

            var peopleModel = await _context.PeopleModel.FindAsync(id);
            if (peopleModel == null)
            {
                return NotFound();
            }
            return View(peopleModel);
        }

        // POST: PeopleModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Awards")] PeopleModel peopleModel)
        {
            if (id != peopleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peopleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeopleModelExists(peopleModel.Id))
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
            return View(peopleModel);
        }

        // GET: PeopleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PeopleModel == null)
            {
                return NotFound();
            }

            var peopleModel = await _context.PeopleModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (peopleModel == null)
            {
                return NotFound();
            }

            return View(peopleModel);
        }

        // POST: PeopleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PeopleModel == null)
            {
                return Problem("Entity set 'peopleContext.PeopleModel'  is null.");
            }
            var peopleModel = await _context.PeopleModel.FindAsync(id);
            if (peopleModel != null)
            {
                _context.PeopleModel.Remove(peopleModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeopleModelExists(int id)
        {
          return (_context.PeopleModel?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
