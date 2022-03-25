using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TesteEntrevista.Data;
using TesteEntrevista.Models;

namespace TesteEntrevista.Controllers
{
   public class CaminhoesController : Controller
   {
      private readonly ApplicationDbContext _context;

      public CaminhoesController(ApplicationDbContext context)
      {
         _context = context;
      }

      // GET: Caminhoes
      public async Task<IActionResult> Index()
      {
        return View(await _context.Caminhao.Where(x => x.AnoFab == DateTime.Now.Year && x.AnoMod >= DateTime.Now.Year 
                                                                                     && (x.Modelo == "FM" || x.Modelo == "FH")).OrderBy(p => p.Placa).ToListAsync());
      }

      // GET: Caminhoes/Details/5
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null) { return NotFound(); }                                                                            // Se não recebeu o ID retorna informação na tela
         var caminhao = await _context.Caminhao.FirstOrDefaultAsync(m => m.Id == id);                                      // Localiza o registro com o id recebido
         if (caminhao == null) { return NotFound(); }                                                                      // Se não localizou o ID retorna informação na tela

         return View(caminhao);                                                                                            // Retorna os dados localizado para a view
      }

      // GET: Caminhoes/Create
      public IActionResult Create()
      {
         return View();
      }

      // POST: Caminhoes/Create
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,Placa,Modelo,AnoFab,AnoMod")] Caminhao caminhao)
      {
         if (ModelState.IsValid)
         {
            _context.Add(caminhao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         }
         return View(caminhao);
      }

      // GET: Caminhoes/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null) { return NotFound(); }                                                                            // Se não recebeu o ID retorna informação na tela
         var caminhao = await _context.Caminhao.FindAsync(id);                                                             // Localiza o registro com o id recebido
         if (caminhao == null) { return NotFound(); }                                                                      // Se não localizou o ID retorna informação na tela

         return View(caminhao);                                                                                            // Retorna os dados localizado para a view
      }

      // POST: Caminhoes/Edit/5
      // To protect from overposting attacks, enable the specific properties you want to bind to.
      // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Modelo,AnoFab,AnoMod")] Caminhao caminhao)
      {
         if (id != caminhao.Id)
         {
            return NotFound();
         }

         if (ModelState.IsValid)
         {
            try
            {
               _context.Update(caminhao);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!CaminhaoExists(caminhao.Id))
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
         return View(caminhao);
      }

      // GET: Caminhoes/Delete/5
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null) { return NotFound(); }                                                                            // Se não recebeu o ID retorna informação na tela
         var caminhao = await _context.Caminhao.FirstOrDefaultAsync(m => m.Id == id);                                      // Localiza o registro com o id recebido
         if (caminhao == null) { return NotFound(); }                                                                      // Se não localizou o ID retorna informação na tela

         return View(caminhao);                                                                                            // Retorna os dados localizado para a view
      }

      // POST: Caminhoes/Delete/5
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         var caminhao = await _context.Caminhao.FindAsync(id);
         _context.Caminhao.Remove(caminhao);
         await _context.SaveChangesAsync();
         return RedirectToAction(nameof(Index));
      }

      private bool CaminhaoExists(int id)
      {
         return _context.Caminhao.Any(e => e.Id == id);
      }
   }
}
