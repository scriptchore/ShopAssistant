using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CozyLounge.Data;
using CozyLounge.Models;
using static CozyLounge.Helper;

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
        public  IActionResult Index()
        {
            return View();
        }

        // GET: Users
        public async Task<IActionResult> Users()  
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
        [NoDirectAccess] 
        public async Task<IActionResult> AddOrEdit(int id = 0)   
        {
            if(id == 0)
            {
                return View(new SalesPersons());
            }
            else
            {
                var salesPersons = await _context.SalesPersons.FindAsync(id);
                if (salesPersons == null)
                {
                    return NotFound();
                }
                return View(salesPersons);
            }


            
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("SalesPersonId,CreatedAt,FullName,UserName,IsAdmin,Phone,Gender,Address,Password,IsActive")] SalesPersons salesPersons)
        {
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
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewUsers", _context.SalesPersons.ToList()) });

            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", salesPersons) });
        }



        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesPersons = await _context.SalesPersons.FindAsync(id);
            _context.SalesPersons.Remove(salesPersons);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewUsers", _context.SalesPersons.ToList()) });
        }

        private bool SalesPersonsExists(int id)
        {
            return _context.SalesPersons.Any(e => e.SalesPersonId == id);
        }
    }
}
