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
    public class SecretariaController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
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
