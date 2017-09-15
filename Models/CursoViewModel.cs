using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SCA.Models
{
    public class CursoViewModel
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "nomeCurso")]
        [Display(Name="Nome do curso")]
        public string NomeCurso { get; set; }

        [JsonProperty(PropertyName = "periodo")]
        [Display(Name="Período")]
        public string Periodo { get; set; }

        [JsonProperty(PropertyName = "valorMatricula")]
        [Display(Name = "Valor da matrícula")]
        public decimal? ValorMatricula { get; set; }

        [JsonProperty(PropertyName = "valorMensalidade")]
        [Display(Name = "Valor da mensalidade")]
        public decimal? ValorMensalidade { get; set; } 

        [JsonProperty(PropertyName = "parcelas")]
        [Display(Name = "Número de parcelas")]
        public int? Parcelas { get; set; }

        [JsonProperty(PropertyName = "nomeCoordenador")]
        [Display(Name="Nome do coordenador")]
        public string NomeCoordenador { get; set; }
    }
}