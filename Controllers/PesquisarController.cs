using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SiteMentoria.Data;
using SiteMentoria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteMentoria.Controllers
{
    public class PesquisarController : Controller
    {
        private readonly SiteMentoriaContext _context;

        public PesquisarController(SiteMentoriaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
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

        public IActionResult Pesquisar(Pesquisa pesquisa)
        {
            var atividades = _context.Atividade.ToList();

            if (pesquisa.Data != DateTime.MinValue)
            {
                atividades = atividades.Where(a => a.Data == pesquisa.Data).ToList();
            }

            if (pesquisa.Professor != null && pesquisa.Professor.Id != 0)
            {
                atividades = atividades.Where(a => a.ProfessorId == pesquisa.Professor.Id).ToList();
            }

            if (pesquisa.Aluno != null && pesquisa.Aluno.Id != 0)
            {
                atividades = atividades.Where(a => a.AlunoId == pesquisa.Aluno.Id).ToList();
            }

            if (pesquisa.Status != 0)
            {
                atividades = atividades.Where(a => a.Status == pesquisa.Status).ToList();
            }

            return RedirectToAction("Search", "Atividades", new { atividades = JsonConvert.SerializeObject(atividades) });
        }

        //Método para fazer pesquisa

    }
}
