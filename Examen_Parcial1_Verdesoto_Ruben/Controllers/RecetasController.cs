using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Examen_Parcial1_Verdesoto_Ruben.Data;
using Examen_Parcial1_Verdesoto_Ruben.Models;

namespace Examen_Parcial1_Verdesoto_Ruben.Controllers
{
    public class RecetasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recetas.ToListAsync());
        }

        // GET: Recetas/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Id_Chef = new SelectList(await _context.Chefs.ToListAsync(), "Id_Chef", "Nombre");
            ViewBag.Ingredientes = new SelectList(await _context.Ingredientes.ToListAsync(), "Ingrediente_Id", "Nombre");
            return View();
        }

        // POST: Recetas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Receta_Id,Nombre,Descripcion,Tiempo_Preparacion,Dificultad,Id_Chef")] Receta receta, List<int> selectedIngredientes)
        {
            if (ModelState.IsValid)
            {
                   if (selectedIngredientes != null)
                {
                    receta.Ingredientes = new List<Ingrediente>();
                    foreach (var ingredienteId in selectedIngredientes)
                    {
                        var ingrediente = await _context.Ingredientes.FindAsync(ingredienteId);
                        if (ingrediente != null)
                        {
                            receta.Ingredientes.Add(ingrediente);
                        }
                    }
                }
                _context.Add(receta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));   
            }       
            ViewBag.Id_Chef = new SelectList(await _context.Chefs.ToListAsync(), "Id_Chef", "Nombre", receta.Id_Chef);
            ViewBag.Ingredientes = new SelectList(await _context.Ingredientes.ToListAsync(), "Ingrediente_Id", "Nombre");
            return View(receta);
        }
        // GET: Recetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Recetas.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }
            return View(receta);
        }

        // POST: Recetas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Receta_Id,Nombre,Descripcion,Tiempo_Preparacion,Dificultad,Id_Chef")] Receta receta, List<int> selectedIngredientes)
        {
            if (id != receta.Receta_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Aquí puedes agregar la lógica para actualizar los ingredientes si es necesario
                _context.Update(receta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Id_Chef = new SelectList(await _context.Chefs.ToListAsync(), "Id_Chef", "Nombre", receta.Id_Chef);
            ViewBag.Ingredientes = new SelectList(await _context.Ingredientes.ToListAsync(), "Ingrediente_Id", "Nombre");
            return View(receta);
        }

        // GET: Recetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receta = await _context.Recetas
                .FirstOrDefaultAsync(m => m.Receta_Id == id);
            if (receta == null)
            {
                return NotFound();
            }

            return View(receta);
        }

        // POST: Recetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receta = await _context.Recetas.FindAsync(id);
            if (receta != null)
            {
                _context.Recetas.Remove(receta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetaExists(int id)
        {
            return _context.Recetas.Any(e => e.Receta_Id == id);
        }
    }
}