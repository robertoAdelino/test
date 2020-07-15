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
    public class ProdutosSupermercadosController : Controller
    {
        private readonly ZeroDbContext _context;

        public ProdutosSupermercadosController(ZeroDbContext context)
        {
            _context = context;
        }

        // GET: ProdutosSupermercados
        public async Task<IActionResult> Index()
        {
            var zeroDbContext = _context.ProdutosSupermercado.Include(p => p.Supermercado).Include(p => p.Tipo);
            return View(await zeroDbContext.ToListAsync());
        }

        // GET: ProdutosSupermercados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosSupermercado = await _context.ProdutosSupermercado
                .Include(p => p.Supermercado)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.IDProdutosSupermercado == id);
            if (produtosSupermercado == null)
            {
                return NotFound();
            }

            return View(produtosSupermercado);
        }

        // GET: ProdutosSupermercados/Create
        public IActionResult Create()
        {
            ViewData["IDSupermercado"] = new SelectList(_context.Supermercado, "IDSupermercado", "Email");
            ViewData["IDTipo"] = new SelectList(_context.Tipo, "IDTipo", "Nome");
            return View();
        }

        // POST: ProdutosSupermercados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDProdutosSupermercado,Nome,Quantidade,IDSupermercado,IDTipo")] ProdutosSupermercado produtosSupermercado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtosSupermercado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDSupermercado"] = new SelectList(_context.Supermercado, "IDSupermercado", "Email", produtosSupermercado.IDSupermercado);
            ViewData["IDTipo"] = new SelectList(_context.Tipo, "IDTipo", "Nome", produtosSupermercado.IDTipo);
            return View(produtosSupermercado);
        }

        // GET: ProdutosSupermercados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosSupermercado = await _context.ProdutosSupermercado.FindAsync(id);
            if (produtosSupermercado == null)
            {
                return NotFound();
            }
            ViewData["IDSupermercado"] = new SelectList(_context.Supermercado, "IDSupermercado", "Email", produtosSupermercado.IDSupermercado);
            ViewData["IDTipo"] = new SelectList(_context.Tipo, "IDTipo", "Nome", produtosSupermercado.IDTipo);
            return View(produtosSupermercado);
        }

        // POST: ProdutosSupermercados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDProdutosSupermercado,Nome,Quantidade,IDSupermercado,IDTipo")] ProdutosSupermercado produtosSupermercado)
        {
            if (id != produtosSupermercado.IDProdutosSupermercado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtosSupermercado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosSupermercadoExists(produtosSupermercado.IDProdutosSupermercado))
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
            ViewData["IDSupermercado"] = new SelectList(_context.Supermercado, "IDSupermercado", "Email", produtosSupermercado.IDSupermercado);
            ViewData["IDTipo"] = new SelectList(_context.Tipo, "IDTipo", "Nome", produtosSupermercado.IDTipo);
            return View(produtosSupermercado);
        }

        // GET: ProdutosSupermercados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtosSupermercado = await _context.ProdutosSupermercado
                .Include(p => p.Supermercado)
                .Include(p => p.Tipo)
                .FirstOrDefaultAsync(m => m.IDProdutosSupermercado == id);
            if (produtosSupermercado == null)
            {
                return NotFound();
            }

            return View(produtosSupermercado);
        }

        // POST: ProdutosSupermercados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtosSupermercado = await _context.ProdutosSupermercado.FindAsync(id);
            _context.ProdutosSupermercado.Remove(produtosSupermercado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosSupermercadoExists(int id)
        {
            return _context.ProdutosSupermercado.Any(e => e.IDProdutosSupermercado == id);
        }
    }
}
