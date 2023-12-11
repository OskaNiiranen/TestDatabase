using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Controllers
{
    public class TestitauluController : Controller
    {
        private readonly FreeAzureSqlContext _context;

        public TestitauluController(FreeAzureSqlContext context)
        {
            _context = context;
        }

        // GET: Testitaulu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testitaulu.ToListAsync());
        }

        // GET: Testitaulu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testitaulu = await _context.Testitaulu
                .FirstOrDefaultAsync(m => m.TestitauluId == id);
            if (testitaulu == null)
            {
                return NotFound();
            }

            return View(testitaulu);
        }

        // GET: Testitaulu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testitaulu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TestitauluId,PersonId,Etunimi,Sukunimi,Age")] Testitaulu testitaulu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testitaulu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testitaulu);
        }

        // GET: Testitaulu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testitaulu = await _context.Testitaulu.FindAsync(id);
            if (testitaulu == null)
            {
                return NotFound();
            }
            return View(testitaulu);
        }

        // POST: Testitaulu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TestitauluId,PersonId,Etunimi,Sukunimi,Age")] Testitaulu testitaulu)
        {
            if (id != testitaulu.TestitauluId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testitaulu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestitauluExists(testitaulu.TestitauluId))
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
            return View(testitaulu);
        }

        // GET: Testitaulu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testitaulu = await _context.Testitaulu
                .FirstOrDefaultAsync(m => m.TestitauluId == id);
            if (testitaulu == null)
            {
                return NotFound();
            }

            return View(testitaulu);
        }

        // POST: Testitaulu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testitaulu = await _context.Testitaulu.FindAsync(id);
            if (testitaulu != null)
            {
                _context.Testitaulu.Remove(testitaulu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestitauluExists(int id)
        {
            return _context.Testitaulu.Any(e => e.TestitauluId == id);
        }
    }
}
