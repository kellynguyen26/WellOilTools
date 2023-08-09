using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OilWellToolsUI.DbContexts;
using OilWellToolsUI.Models;

namespace OilWellToolsUI.Controllers
{
    public class OilWellToolsController : Controller
    {
        private readonly OilWellToolContext _context;

        public OilWellToolsController(OilWellToolContext context)
        {
            _context = context;
        }

        // GET: OilWellTools
        public async Task<IActionResult> Index()
        {
              return _context.Tools != null ? 
                          View(await _context.Tools.ToListAsync()) :
                          Problem("Entity set 'OilWellToolContext.Tools'  is null.");
        }

        // GET: OilWellTools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tools == null)
            {
                return NotFound();
            }

            var oilWellTool = await _context.Tools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oilWellTool == null)
            {
                return NotFound();
            }

            return View(oilWellTool);
        }

        // GET: OilWellTools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OilWellTools/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetType,Weight,Length,Diameter,ServiceDueDate,Location")] OilWellTool oilWellTool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oilWellTool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oilWellTool);
        }

        // GET: OilWellTools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tools == null)
            {
                return NotFound();
            }

            var oilWellTool = await _context.Tools.FindAsync(id);
            if (oilWellTool == null)
            {
                return NotFound();
            }
            return View(oilWellTool);
        }

        // POST: OilWellTools/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetType,Weight,Length,Diameter,ServiceDueDate,Location")] OilWellTool oilWellTool)
        {
            if (id != oilWellTool.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oilWellTool);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OilWellToolExists(oilWellTool.Id))
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
            return View(oilWellTool);
        }

        // GET: OilWellTools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tools == null)
            {
                return NotFound();
            }

            var oilWellTool = await _context.Tools
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oilWellTool == null)
            {
                return NotFound();
            }

            return View(oilWellTool);
        }

        // POST: OilWellTools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tools == null)
            {
                return Problem("Entity set 'OilWellToolContext.Tools'  is null.");
            }
            var oilWellTool = await _context.Tools.FindAsync(id);
            if (oilWellTool != null)
            {
                _context.Tools.Remove(oilWellTool);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OilWellToolExists(int id)
        {
          return (_context.Tools?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
