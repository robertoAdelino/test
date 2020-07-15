using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ZeroWaste.Models;

namespace ZeroWaste.Controllers
{
    public class RefeicoesRestaurantesController : Controller
    {
        private readonly ZeroDbContext _context;

        public RefeicoesRestaurantesController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: RefeicoesRestaurantes
        public async Task<IActionResult> Index()
        {
            var zeroDbContext = _context.RefeicoesRestaurante.Include(r => r.Restaurante);
            return View(await zeroDbContext.ToListAsync());
        }

        // GET: RefeicoesRestaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeicoesRestaurante = await _context.RefeicoesRestaurante
                .Include(r => r.Restaurante)
                .FirstOrDefaultAsync(m => m.IDRefeicoesRestaurante == id);
            if (refeicoesRestaurante == null)
            {
                return NotFound();
            }

            return View(refeicoesRestaurante);
        }

        // GET: RefeicoesRestaurantes/Create
        public IActionResult Create()
        {
            ViewData["IDRestaurante"] = new SelectList(_context.Restaurante, "IDRestaurante", "Email");
            return View();
        }

        // POST: RefeicoesRestaurantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDRefeicoesRestaurante,Nome,Quantidade,IDRestaurante")] RefeicoesRestaurante refeicoesRestaurante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refeicoesRestaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDRestaurante"] = new SelectList(_context.Restaurante, "IDRestaurante", "Email", refeicoesRestaurante.IDRestaurante);
            return View(refeicoesRestaurante);
        }

        // GET: RefeicoesRestaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeicoesRestaurante = await _context.RefeicoesRestaurante.FindAsync(id);
            if (refeicoesRestaurante == null)
            {
                return NotFound();
            }
            ViewData["IDRestaurante"] = new SelectList(_context.Restaurante, "IDRestaurante", "Email", refeicoesRestaurante.IDRestaurante);
            return View(refeicoesRestaurante);
        }

        // POST: RefeicoesRestaurantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDRefeicoesRestaurante,Nome,Quantidade,IDRestaurante")] RefeicoesRestaurante refeicoesRestaurante)
        {
            if (id != refeicoesRestaurante.IDRefeicoesRestaurante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refeicoesRestaurante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RefeicoesRestauranteExists(refeicoesRestaurante.IDRefeicoesRestaurante))
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
            ViewData["IDRestaurante"] = new SelectList(_context.Restaurante, "IDRestaurante", "Email", refeicoesRestaurante.IDRestaurante);
            return View(refeicoesRestaurante);
        }

        // GET: RefeicoesRestaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refeicoesRestaurante = await _context.RefeicoesRestaurante
                .Include(r => r.Restaurante)
                .FirstOrDefaultAsync(m => m.IDRefeicoesRestaurante == id);
            if (refeicoesRestaurante == null)
            {
                return NotFound();
            }

            return View(refeicoesRestaurante);
        }

        // POST: RefeicoesRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refeicoesRestaurante = await _context.RefeicoesRestaurante.FindAsync(id);
            _context.RefeicoesRestaurante.Remove(refeicoesRestaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RefeicoesRestauranteExists(int id)
        {
            return _context.RefeicoesRestaurante.Any(e => e.IDRefeicoesRestaurante == id);
        }
    }
}
