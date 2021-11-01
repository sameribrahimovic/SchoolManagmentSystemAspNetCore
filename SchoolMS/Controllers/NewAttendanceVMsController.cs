using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolMS.Data;
using SchoolMS.Data.ViewModels;

namespace SchoolMS.Controllers
{
    public class NewAttendanceVMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewAttendanceVMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewAttendanceVMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.NewAttendanceVM.ToListAsync());
        }

        // GET: NewAttendanceVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newAttendanceVM = await _context.NewAttendanceVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newAttendanceVM == null)
            {
                return NotFound();
            }

            return View(newAttendanceVM);
        }

        // GET: NewAttendanceVMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewAttendanceVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,StudentId,DateAdded")] NewAttendanceVM newAttendanceVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newAttendanceVM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(newAttendanceVM);
        }

        // GET: NewAttendanceVMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newAttendanceVM = await _context.NewAttendanceVM.FindAsync(id);
            if (newAttendanceVM == null)
            {
                return NotFound();
            }
            return View(newAttendanceVM);
        }

        // POST: NewAttendanceVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,StudentId,DateAdded")] NewAttendanceVM newAttendanceVM)
        {
            if (id != newAttendanceVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newAttendanceVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewAttendanceVMExists(newAttendanceVM.Id))
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
            return View(newAttendanceVM);
        }

        // GET: NewAttendanceVMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newAttendanceVM = await _context.NewAttendanceVM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newAttendanceVM == null)
            {
                return NotFound();
            }

            return View(newAttendanceVM);
        }

        // POST: NewAttendanceVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newAttendanceVM = await _context.NewAttendanceVM.FindAsync(id);
            _context.NewAttendanceVM.Remove(newAttendanceVM);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewAttendanceVMExists(int id)
        {
            return _context.NewAttendanceVM.Any(e => e.Id == id);
        }
    }
}
