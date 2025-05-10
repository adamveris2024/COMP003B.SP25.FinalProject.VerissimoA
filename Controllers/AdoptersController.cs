using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.SP25.FinalProject.VerissimoA.Data;
using COMP003B.SP25.FinalProject.VerissimoA.Models;

namespace COMP003B.SP25.FinalProject.VerissimoA.Controllers
{
    public class AdoptersController : Controller
    {
        private readonly PetAdoptionContext _context;

        public AdoptersController(PetAdoptionContext context)
        {
            _context = context;
        }

        // GET: Adopters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Adopters.ToListAsync());
        }

        // GET: Adopters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopter = await _context.Adopters
                .FirstOrDefaultAsync(m => m.AdopterId == id);
            if (adopter == null)
            {
                return NotFound();
            }

            return View(adopter);
        }

        // GET: Adopters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adopters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AdopterId,AdopterName,AdopterEmail,AdopterAddress,AdopterPhone")] Adopter adopter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adopter);
        }

        // GET: Adopters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopter = await _context.Adopters.FindAsync(id);
            if (adopter == null)
            {
                return NotFound();
            }
            return View(adopter);
        }

        // POST: Adopters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdopterId,AdopterName,AdopterEmail,AdopterAddress,AdopterPhone")] Adopter adopter)
        {
            if (id != adopter.AdopterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adopter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdopterExists(adopter.AdopterId))
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
            return View(adopter);
        }

        // GET: Adopters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adopter = await _context.Adopters
                .FirstOrDefaultAsync(m => m.AdopterId == id);
            if (adopter == null)
            {
                return NotFound();
            }

            return View(adopter);
        }

        // POST: Adopters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopter = await _context.Adopters.FindAsync(id);
            if (adopter != null)
            {
                _context.Adopters.Remove(adopter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdopterExists(int id)
        {
            return _context.Adopters.Any(e => e.AdopterId == id);
        }
    }
}
