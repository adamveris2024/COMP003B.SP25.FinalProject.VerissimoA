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
    public class StaffMembersController : Controller
    {
        private readonly PetAdoptionContext _context;

        public StaffMembersController(PetAdoptionContext context)
        {
            _context = context;
        }

        // GET: StaffMembers
        public async Task<IActionResult> Index()
        {
            var petAdoptionContext = _context.Members.Include(s => s.Shelter);
            return View(await petAdoptionContext.ToListAsync());
        }

        // GET: StaffMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Members
                .Include(s => s.Shelter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: StaffMembers/Create
        public IActionResult Create()
        {
            ViewData["ShelterId"] = new SelectList(_context.Shelters, "ShelterId", "ShelterAddress");
            return View();
        }

        // POST: StaffMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Role,Email,ShelterId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShelterId"] = new SelectList(_context.Shelters, "ShelterId", "ShelterAddress", staff.ShelterId);
            return View(staff);
        }

        // GET: StaffMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Members.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["ShelterId"] = new SelectList(_context.Shelters, "ShelterId", "ShelterAddress", staff.ShelterId);
            return View(staff);
        }

        // POST: StaffMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Role,Email,ShelterId")] Staff staff)
        {
            if (id != staff.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.Id))
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
            ViewData["ShelterId"] = new SelectList(_context.Shelters, "ShelterId", "ShelterAddress", staff.ShelterId);
            return View(staff);
        }

        // GET: StaffMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Members
                .Include(s => s.Shelter)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: StaffMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Members.FindAsync(id);
            if (staff != null)
            {
                _context.Members.Remove(staff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
