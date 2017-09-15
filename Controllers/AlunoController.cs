using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCA.Models;
using SCA.Repositories;

namespace SCA.Controllers
{
    public class AlunoController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewData["Message"] = "Use as opções abaixo para cadastrar um Aluno.";
            return View();
        }

        [HttpGet("/Aluno/BolsaEnem")]
        public async Task<int> GetBolsaEnem(int idAluno)
        {
            AlunoRepository rep = new AlunoRepository();
            int bolsa = await rep.GetBolsaEnem();
            return bolsa;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AlunoViewModel aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    AlunoRepository rep = new AlunoRepository();
                    var alunos = await rep.SaveAluno(aluno);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(aluno);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
