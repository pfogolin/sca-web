using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SCA.Models;
using SCA.Repositories;

namespace SCA.Controllers
{
    public class MatriculaController : Controller
    {
        [Authorize]
        public async Task<IActionResult> Index()
        {
            MatriculaViewModel vm = new MatriculaViewModel();
            var alunoRep = new AlunoRepository();
            var cursoRep = new CursoRepository();

            var alunos = await alunoRep.GetAluno();
            var cursos = await cursoRep.GetCurso();            

            ViewBag.AlunosList = alunos;
            ViewBag.CursosList = cursos;

            if (alunos != null && alunos.Count() > 0)
            {
                vm.Alunos = new List<SelectListItem>();
                foreach (var aluno in alunos)
                {
                    vm.Alunos.Add(new SelectListItem()
                    {
                        Text = aluno.NomeCompleto,
                        Value = aluno.Id.ToString()
                    });
                };
            }

            if (cursos != null && cursos.Count() > 0)
            {
                vm.Cursos = new List<SelectListItem>();
                foreach (var curso in cursos)
                {
                    vm.Cursos.Add(new SelectListItem()
                    {
                        Text = curso.NomeCurso,
                        Value = curso.Id.ToString()
                    });
                };
            }

            ViewData["Message"] = "Use as opções abaixo para cadastrar uma Matrícula.";
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MatriculaViewModel matricula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MatriculaRepository rep = new MatriculaRepository();
                    var alunos = await rep.SaveMatricula(matricula);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(matricula);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
