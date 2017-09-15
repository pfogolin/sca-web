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
    public class CursoController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            ViewData["Message"] = "Use as opções abaixo para cadastrar um Curso.";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CursoViewModel curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CursoRepository rep = new CursoRepository();
                    var alunos = await rep.SaveCurso(curso);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(curso);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
