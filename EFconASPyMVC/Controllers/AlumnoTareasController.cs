using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFconASPyMVC.Context;
using EFconASPyMVC.Models;

namespace EFconASPyMVC.Controllers
{
    public class AlumnoTareasController : Controller
    {
        private readonly MyDbContext _context;

        public AlumnoTareasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: AlumnoTareas
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.AlumnoTareas.Include(a => a.Alumno).Include(a => a.Tarea);
            return View(await myDbContext.ToListAsync());
        }

        // GET: AlumnoTareas/Details/5
        public async Task<IActionResult> Details(int? tareaId, int? alumnoId)
        {
            if (tareaId == null || alumnoId == null)
            {
                return NotFound();
            }

            var alumnoTareas = await _context.AlumnoTareas
                .Include(a => a.Alumno)
                .Include(a => a.Tarea)
                .FirstOrDefaultAsync(m => m.TareaId == tareaId && m.AlumnoId == alumnoId);
            if (alumnoTareas == null)
            {
                return NotFound();
            }

            return View(alumnoTareas);
        }

        // GET: AlumnoTareas/Create
        public IActionResult Create()
        {
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "Id", "Id");
            ViewData["TareaId"] = new SelectList(_context.Tareas, "Id", "Id");
            return View();
        }

        // POST: AlumnoTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumnoId,TareaId,Activo")] AlumnoTareas alumnoTareas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnoTareas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "Id", "Id", alumnoTareas.AlumnoId);
            ViewData["TareaId"] = new SelectList(_context.Tareas, "Id", "Id", alumnoTareas.TareaId);
            return View(alumnoTareas);
        }

        // GET: AlumnoTareas/Edit/5
        public async Task<IActionResult> Edit(int? tareaId, int? alumnoId)
        {
            if (tareaId == null || alumnoId == null)
            {
                return NotFound();
            }

            var alumnoTareas = await _context.AlumnoTareas.FindAsync(tareaId, alumnoId);
            if (alumnoTareas == null)
            {
                return NotFound();
            }
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "Id", "Id", alumnoTareas.AlumnoId);
            ViewData["TareaId"] = new SelectList(_context.Tareas, "Id", "Id", alumnoTareas.TareaId);
            return View(alumnoTareas);
        }

        // POST: AlumnoTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int tareaId, int alumnoId, [Bind("AlumnoId,TareaId,Activo")] AlumnoTareas alumnoTareas)
        {
            if (tareaId != alumnoTareas.TareaId || alumnoId != alumnoTareas.AlumnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnoTareas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoTareasExists(alumnoTareas.TareaId, alumnoTareas.AlumnoId))
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
            ViewData["AlumnoId"] = new SelectList(_context.Alumnos, "Id", "Id", alumnoTareas.AlumnoId);
            ViewData["TareaId"] = new SelectList(_context.Tareas, "Id", "Id", alumnoTareas.TareaId);
            return View(alumnoTareas);
        }

        // GET: AlumnoTareas/Delete/5
        public async Task<IActionResult> Delete(int? tareaId, int? alumnoId)
        {
            if (tareaId == null || alumnoId == null)
            {
                return NotFound();
            }

            var alumnoTareas = await _context.AlumnoTareas
                .Include(a => a.Alumno)
                .Include(a => a.Tarea)
                .FirstOrDefaultAsync(m => m.TareaId == tareaId && m.AlumnoId == alumnoId);
            if (alumnoTareas == null)
            {
                return NotFound();
            }

            return View(alumnoTareas);
        }

        // POST: AlumnoTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int tareaId, int alumnoId)
        {
            var alumnoTareas = await _context.AlumnoTareas.FindAsync(tareaId, alumnoId);
            _context.AlumnoTareas.Remove(alumnoTareas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoTareasExists(int tareaId, int alumnoId)
        {
            return _context.AlumnoTareas.Any(e => e.TareaId == tareaId && e.AlumnoId == alumnoId);
        }
    }
}
