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

      /// <summary>
      /// Executa na pagina index
      /// </summary>
      /// <returns>Lista dos veiculos cadastrados</returns>
      public async Task<IActionResult> Index()
      {
        return View(await _context.Caminhao.Where(x => x.AnoFab == DateTime.Now.Year && x.AnoMod >= DateTime.Now.Year 
                                                                                     && (x.Modelo == "FM" || x.Modelo == "FH")).OrderBy(p => p.Placa).ToListAsync());
      }
      /// <summary>
      /// Executa quando vai verificar os detalhes do veiculo
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      public async Task<IActionResult> Details(int? id)
      {
         if (id == null) { return NotFound(); }                                                                            // Se não recebeu o ID retorna informação na tela
         var caminhao = await _context.Caminhao.FirstOrDefaultAsync(m => m.Id == id);                                      // Localiza o registro com o id recebido
         if (caminhao == null) { return NotFound(); }                                                                      // Se não localizou o ID retorna informação na tela

         return View(caminhao);                                                                                            // Retorna os dados localizado para a view
      }
      /// <summary>
      /// Cria a view
      /// </summary>
      /// <returns></returns>
      public IActionResult Create()
      {
         return View();                                                                                                    // Retorna a view
      }
      /// <summary>
      /// Adicionar um novo registro
      /// </summary>
      /// <param name="caminhao">Classe com os dados do caminhão</param>
      /// <returns>View com o caminhão cadastrado</returns>
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Create([Bind("Id,Placa,Modelo,AnoFab,AnoMod")] Caminhao caminhao)
      {
         if (ModelState.IsValid)                                                                                           // O model esta valido
         {
            _context.Add(caminhao);                                                                                        // Adciona o registro ao context
            await _context.SaveChangesAsync();                                                                             // Salva as alterações
            return RedirectToAction(nameof(Index));                                                                        // Retona a view de index
         }
         return View(caminhao);                                                                                            // Retona a view dos registro cadastrado
      }

      // GET: Caminhoes/Edit/5
      public async Task<IActionResult> Edit(int? id)
      {
         if (id == null) { return NotFound(); }                                                                            // Se não recebeu o ID retorna informação na tela
         var caminhao = await _context.Caminhao.FindAsync(id);                                                             // Localiza o registro com o id recebido
         if (caminhao == null) { return NotFound(); }                                                                      // Se não localizou o ID retorna informação na tela

         return View(caminhao);                                                                                            // Retorna os dados localizado para a view
      }
      /// <summary>
      /// Atualiza o registro
      /// </summary>
      /// <param name="id">Id do registro</param>
      /// <param name="caminhao">Registro do caminhão</param>
      /// <returns></returns>
      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, [Bind("Id,Placa,Modelo,AnoFab,AnoMod")] Caminhao caminhao)
      {
         if (id != caminhao.Id)                                                                                            // Verifica se o Id é diferente
            return NotFound();                                                                                             // Retorna a tela
         
         if (ModelState.IsValid)                                                                                           // O model esta valido
         {
            try
            {
               _context.Update(caminhao);                                                                                  // Atualiza o registro
               await _context.SaveChangesAsync();                                                                          // Salva as alterações
            }
            catch (DbUpdateConcurrencyException)
            {
               if (!CaminhaoExists(caminhao.Id))                                                                          
                  return NotFound();
               else
                  throw;                                                                                                   // Gera um erro
            }
            return RedirectToAction(nameof(Index));                                                                        // Retorna a view
         }
         return View(caminhao);                                                                                            // Retorna para a view com os registros
      }

      // GET: Caminhoes/Delete/5
      public async Task<IActionResult> Delete(int? id)
      {
         if (id == null) { return NotFound(); }                                                                            // Se não recebeu o ID retorna informação na tela
         var caminhao = await _context.Caminhao.FirstOrDefaultAsync(m => m.Id == id);                                      // Localiza o registro com o id recebido
         if (caminhao == null) { return NotFound(); }                                                                      // Se não localizou o ID retorna informação na tela

         return View(caminhao);                                                                                            // Retorna os dados localizado para a view
      }
      /// <summary>
      /// Executa na hora de apagar um resgistro
      /// </summary>
      /// <param name="id">Id do veiculo a ser deletado</param>
      /// <returns></returns>
      [HttpPost, ActionName("Delete")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> DeleteConfirmed(int id)
      {
         var caminhao = await _context.Caminhao.FindAsync(id);                                                             // Localiza o registro atraves do ID
         _context.Caminhao.Remove(caminhao);                                                                               // Remove o registro atraves do Id 
         await _context.SaveChangesAsync();                                                                                // Salva as alterações
         return RedirectToAction(nameof(Index));                                                                           // Retorna a view
      }

      private bool CaminhaoExists(int id)
      {
         return _context.Caminhao.Any(e => e.Id == id);                                                                    // Verifica se existe o registro
      }
   }
}
