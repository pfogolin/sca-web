using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace SCA.Models
{
    public class MatriculaViewModel
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "alunoId")]
        [Display(Name = "Aluno")]
        public int AlunoId { get; set; }

        [JsonProperty(PropertyName = "cursoId")]
        [Display(Name = "Curso")]
        public int CursoId { get; set; }

        [JsonProperty(PropertyName = "dataInicio")]
        [Display(Name = "Data início")]
        public DateTime? DataInicio { get; set; }

        [JsonProperty(PropertyName = "dataFim")]
        [Display(Name = "Data fim")]
        public DateTime? DataFim { get; set; }

        [JsonProperty(PropertyName = "bolsaEstudos")]
        [Display(Name = "Bolsa de estudos")]
        public decimal BolsaEstudos { get; set; }

        public List<SelectListItem> Alunos { set; get; }

        public List<SelectListItem> Cursos { set; get; }

    }
}