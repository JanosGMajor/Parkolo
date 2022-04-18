using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Parkolo.Data;
using Parkolo.Models;

namespace Parkolo.Controllers
{
    public class KeszletekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KeszletekController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Keszletek
        public async Task<IActionResult> Index(string AlvazSzamKeres, string TipusKeres)
        {
            var adatok = _context.Keszlet.Select(x => x);
            Keres keres = new Keres();

            if (!string.IsNullOrEmpty(AlvazSzamKeres))
            {
                keres.AlvazSzamKeres = AlvazSzamKeres;
                adatok = adatok.Where(x => x.AlvazSzam.Contains(AlvazSzamKeres));
            }

            if (!string.IsNullOrEmpty(TipusKeres))
            {
                keres.TipusKeres = TipusKeres;
                adatok = adatok.Where(x => x.Tipus.Equals(TipusKeres));
            }

            keres.KeszletLista = await adatok.ToListAsync();
            keres.TipusSelect = new SelectList(await _context.Keszlet.Select(x => x.Tipus).Distinct().ToListAsync());

            return View(keres);
        }

        // GET: Keszletek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keszlet = await _context.Keszlet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keszlet == null)
            {
                return NotFound();
            }

            return View(keszlet);
        }

        // GET: Keszletek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Keszletek/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AlvazSzam,Tipus,KulcsSzam,Pozicio")] Keszlet keszlet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keszlet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keszlet);
        }

        // GET: Keszletek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keszlet = await _context.Keszlet.FindAsync(id);
            if (keszlet == null)
            {
                return NotFound();
            }
            return View(keszlet);
        }

        // POST: Keszletek/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AlvazSzam,Tipus,KulcsSzam,Pozicio")] Keszlet keszlet)
        {
            if (id != keszlet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keszlet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeszletExists(keszlet.Id))
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
            return View(keszlet);
        }

        // GET: Keszletek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var keszlet = await _context.Keszlet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (keszlet == null)
            {
                return NotFound();
            }

            return View(keszlet);
        }

        // POST: Keszletek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var keszlet = await _context.Keszlet.FindAsync(id);
            _context.Keszlet.Remove(keszlet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeszletExists(int id)
        {
            return _context.Keszlet.Any(e => e.Id == id);
        }
    }
}
