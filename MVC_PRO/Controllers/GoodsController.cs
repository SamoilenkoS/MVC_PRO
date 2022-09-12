using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi_DAL;
using WebApi_DAL.Entities;

namespace MVC_PRO.Controllers
{
    public class GoodsController : Controller
    {
        private readonly GWContext _context;

        public GoodsController(GWContext context)
        {
            _context = context;
        }

        // GET: Goods
        public async Task<IActionResult> Index()
        {
              return _context.Goods != null ? 
                          View(await _context.Goods.ToListAsync()) :
                          Problem("Entity set 'GWContext.Goods'  is null.");
        }

        // GET: Goods/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // GET: Goods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Goods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Price,CreatedAt")] Good good)
        {
            if (ModelState.IsValid)
            {
                good.Id = Guid.NewGuid();
                _context.Add(good);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(good);
        }

        // GET: Goods/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var good = await _context.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }
            return View(good);
        }

        // POST: Goods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Price,CreatedAt")] Good good)
        {
            if (id != good.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(good);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoodExists(good.Id))
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
            return View(good);
        }

        // GET: Goods/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Goods == null)
            {
                return NotFound();
            }

            var good = await _context.Goods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return View(good);
        }

        // POST: Goods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Goods == null)
            {
                return Problem("Entity set 'GWContext.Goods'  is null.");
            }
            var good = await _context.Goods.FindAsync(id);
            if (good != null)
            {
                _context.Goods.Remove(good);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GoodExists(Guid id)
        {
          return (_context.Goods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
