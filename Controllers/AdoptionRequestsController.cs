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
    public class AdoptionRequestsController : Controller
    {
        private readonly PetAdoptionContext _context;

        public AdoptionRequestsController(PetAdoptionContext context)
        {
            _context = context;
        }

        // GET: AdoptionRequests
        public async Task<IActionResult> Index()
        {
            var petAdoptionContext = _context.AdoptionRequests.Include(a => a.Adopter).Include(a => a.Animal);
            return View(await petAdoptionContext.ToListAsync());
        }

        // GET: AdoptionRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionRequest = await _context.AdoptionRequests
                .Include(a => a.Adopter)
                .Include(a => a.Animal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionRequest == null)
            {
                return NotFound();
            }

            return View(adoptionRequest);
        }

        // GET: AdoptionRequests/Create
        public IActionResult Create()
        {
            ViewData["AdopterId"] = new SelectList(_context.Adopters, "AdopterId", "AdopterName");
            ViewData["AnimalId"] = new SelectList(_context.Animals, "AnimalId", "AnimalDescription");
            return View();
        }

        // POST: AdoptionRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnimalId,AdopterId,Status,DateRequested")] AdoptionRequest adoptionRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adoptionRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdopterId"] = new SelectList(_context.Adopters, "AdopterId", "AdopterName", adoptionRequest.AdopterId);
            ViewData["AnimalId"] = new SelectList(_context.Animals, "AnimalId", "AnimalDescription", adoptionRequest.AnimalId);
            return View(adoptionRequest);
        }

        // GET: AdoptionRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionRequest = await _context.AdoptionRequests.FindAsync(id);
            if (adoptionRequest == null)
            {
                return NotFound();
            }
            ViewData["AdopterId"] = new SelectList(_context.Adopters, "AdopterId", "AdopterName", adoptionRequest.AdopterId);
            ViewData["AnimalId"] = new SelectList(_context.Animals, "AnimalId", "AnimalDescription", adoptionRequest.AnimalId);
            return View(adoptionRequest);
        }

        // POST: AdoptionRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimalId,AdopterId,Status,DateRequested")] AdoptionRequest adoptionRequest)
        {
            if (id != adoptionRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adoptionRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdoptionRequestExists(adoptionRequest.Id))
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
            ViewData["AdopterId"] = new SelectList(_context.Adopters, "AdopterId", "AdopterName", adoptionRequest.AdopterId);
            ViewData["AnimalId"] = new SelectList(_context.Animals, "AnimalId", "AnimalDescription", adoptionRequest.AnimalId);
            return View(adoptionRequest);
        }

        // GET: AdoptionRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var adoptionRequest = await _context.AdoptionRequests
                .Include(a => a.Adopter)
                .Include(a => a.Animal)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adoptionRequest == null)
            {
                return NotFound();
            }

            return View(adoptionRequest);
        }

        // POST: AdoptionRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adoptionRequest = await _context.AdoptionRequests.FindAsync(id);
            if (adoptionRequest != null)
            {
                _context.AdoptionRequests.Remove(adoptionRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdoptionRequestExists(int id)
        {
            return _context.AdoptionRequests.Any(e => e.Id == id);
        }
    }
}
