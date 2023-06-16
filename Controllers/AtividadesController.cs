using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SiteMentoria.Data;
using SiteMentoria.Models;

namespace SiteMentoria.Controllers
{
    public class AtividadesController : Controller
    {
        private readonly SiteMentoriaContext _context;

        public AtividadesController(SiteMentoriaContext context)
        {
            _context = context;
        }

        // GET: Lista de Atividades
        public IActionResult Search(string atividades)
        {
            var atividadesModels = JsonConvert.DeserializeObject<List<Atividade>>(atividades);

            foreach (var atividade in atividadesModels)
            {
                atividade.Aluno = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.AlunoId);
                atividade.Professor = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.ProfessorId);
            }

            return View(atividadesModels);
        }

        public IActionResult Pesquisar()
        {
            return RedirectToAction("Index", "Pesquisar", null);
        }

        // GET: Atividades
        public async Task<IActionResult> Index()
        {
            var atividades = _context.Atividade.ToList();

            foreach (var atividade in atividades)
            {
                atividade.Aluno = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.AlunoId);
                atividade.Professor = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.ProfessorId);
            }  

            return View(atividades);
        }

        // GET: Atividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade.FirstOrDefaultAsync(m => m.Id == id);
       
            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Aluno = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.AlunoId);
            atividade.Professor = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.ProfessorId);

            return View(atividade);
        }

        // GET: Atividades/Create
        public IActionResult Create()
        {
            ViewBag.Alunos = GetAlunosFromDatabaseAsync();
            ViewBag.Professores = GetProfessoresFromDatabaseAsync();
            ViewBag.Status = new List<Status>
            {
                new Status { Id = 1, Nome = "Pronto para desenvolvimento"},
                new Status { Id = 2, Nome = "Em desenvolvimento"},
                new Status { Id = 3, Nome = "Concluído"},
                new Status { Id = 4, Nome = "Cancelado"}

            };
            return View();
        }

        private List<Pessoa> GetAlunosFromDatabaseAsync()
        {
            var alunos = _context.Pessoa.Where(a => a.IsProfessor == false).ToList();
            return alunos;
        }

        private List<Pessoa> GetProfessoresFromDatabaseAsync()
        {
            var professores = _context.Pessoa.Where(p => p.IsProfessor == true).ToList();
            return professores;
        }

        // POST: Atividades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Atividade atividade)
        {
            var alunoSelecionado = await _context.Pessoa.FirstOrDefaultAsync(m => m.Id == atividade.Aluno.Id);

            var professorSelecionado = await _context.Pessoa.FirstOrDefaultAsync(m => m.Id == atividade.Professor.Id);

            atividade.Aluno = alunoSelecionado;
            atividade.Professor = professorSelecionado;

            _context.Add(atividade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Atividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }
            atividade.Aluno = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.AlunoId);
            atividade.Professor = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.ProfessorId);

            ViewBag.Alunos = GetAlunosFromDatabaseAsync();
            ViewBag.Professores = GetProfessoresFromDatabaseAsync();
            ViewBag.Status = new List<Status>
            {
                new Status { Id = 1, Nome = "Pronto para desenvolvimento"},
                new Status { Id = 2, Nome = "Em desenvolvimento"},
                new Status { Id = 3, Nome = "Concluído"},
                new Status { Id = 4, Nome = "Cancelado"}

            };

            return View(atividade);
        }

        // POST: Atividades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Atividade atividade)
        {
            if (id != atividade.Id)
            {
                return NotFound();
            }

            var alunoSelecionado = await _context.Pessoa.FirstOrDefaultAsync(m => m.Id == atividade.Aluno.Id);
            var professorSelecionado = await _context.Pessoa.FirstOrDefaultAsync(m => m.Id == atividade.Professor.Id);

            atividade.Aluno = alunoSelecionado;
            atividade.Professor = professorSelecionado;

            try
                {
                    _context.Update(atividade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadeExists(atividade.Id))
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

        // GET: Atividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividade = await _context.Atividade.FirstOrDefaultAsync(m => m.Id == id);
            if (atividade == null)
            {
                return NotFound();
            }

            atividade.Aluno = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.AlunoId);
            atividade.Professor = _context.Pessoa.FirstOrDefault(m => m.Id == atividade.ProfessorId);

            return View(atividade);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atividade = await _context.Atividade.FindAsync(id);
            _context.Atividade.Remove(atividade);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadeExists(int id)
        {
            return _context.Atividade.Any(e => e.Id == id);
        }
    }
}
