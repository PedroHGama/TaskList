using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskList.Data;
using TaskList.Models;

namespace TaskList.Controllers
{
    public class TarefasController : Controller
    {
        private readonly TaskListContext _context;

        public TarefasController(TaskListContext context)
        {
            _context = context;
        }

        // GET: Tarefas
        public async Task<IActionResult> Index()
        {
            var taskListContext = _context.Tarefa.Include(t => t.Setor).Include(t => t.Usuario);
            return View(await taskListContext.ToListAsync());
        }

        // GET: Tarefas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa
                .Include(t => t.Setor)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.IdTarefa == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // GET: Tarefas/Create
        public IActionResult Create()
        {
            ViewData["IdSetor"] = new SelectList(_context.Set<Setor>(), "IdSetor", "NomeSetor");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "EmailUsuario");
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTarefa,Descricao,Status,Prioridade,DataCadastro,IdUsuario,IdSetor")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarefa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSetor"] = new SelectList(_context.Set<Setor>(), "IdSetor", "NomeSetor", tarefa.IdSetor);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "EmailUsuario", tarefa.IdUsuario);
            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound();
            }
            ViewData["IdSetor"] = new SelectList(_context.Set<Setor>(), "IdSetor", "NomeSetor", tarefa.IdSetor);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "EmailUsuario", tarefa.IdUsuario);
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarefa,Descricao,Status,Prioridade,DataCadastro,IdUsuario,IdSetor")] Tarefa tarefa)
        {
            if (id != tarefa.IdTarefa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarefa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarefaExists(tarefa.IdTarefa))
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
            ViewData["IdSetor"] = new SelectList(_context.Set<Setor>(), "IdSetor", "NomeSetor", tarefa.IdSetor);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "IdUsuario", "EmailUsuario", tarefa.IdUsuario);
            return View(tarefa);
        }

        // GET: Tarefas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefa
                .Include(t => t.Setor)
                .Include(t => t.Usuario)
                .FirstOrDefaultAsync(m => m.IdTarefa == id);
            if (tarefa == null)
            {
                return NotFound();
            }

            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tarefa = await _context.Tarefa.FindAsync(id);
            if (tarefa != null)
            {
                _context.Tarefa.Remove(tarefa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarefaExists(int id)
        {
            return _context.Tarefa.Any(e => e.IdTarefa == id);
        }
    }
}
