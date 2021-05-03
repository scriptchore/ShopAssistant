using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CozyLounge.Data;
using CozyLounge.Models;

namespace CozyLounge.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesPersons.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersons = await _context.SalesPersons
                .FirstOrDefaultAsync(m => m.SalesPersonId == id);
            if (salesPersons == null)
            {
                return NotFound();
            }

            return View(salesPersons);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesPersonId,CreatedAt,FullName,UserName,IsAdmin,Phone,Gender,Address,Password,IsActive")] SalesPersons salesPersons)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesPersons);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesPersons);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersons = await _context.SalesPersons.FindAsync(id);
            if (salesPersons == null)
            {
                return NotFound();
            }
            return View(salesPersons);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesPersonId,CreatedAt,FullName,UserName,IsAdmin,Phone,Gender,Address,Password,IsActive")] SalesPersons salesPersons)
        {
            if (id != salesPersons.SalesPersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesPersons);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesPersonsExists(salesPersons.SalesPersonId))
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
            return View(salesPersons);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesPersons = await _context.SalesPersons
                .FirstOrDefaultAsync(m => m.SalesPersonId == id);
            if (salesPersons == null)
            {
                return NotFound();
            }

            return View(salesPersons);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesPersons = await _context.SalesPersons.FindAsync(id);
            _context.SalesPersons.Remove(salesPersons);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesPersonsExists(int id)
        {
            return _context.SalesPersons.Any(e => e.SalesPersonId == id);
        }
    }
}
