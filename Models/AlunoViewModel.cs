using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SCA.Models
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "nomeCompleto")]
        [Display(Name="Nome completo")]
        public string NomeCompleto { get; set; }

        [JsonProperty(PropertyName = "dataNascimento")]
        [Display(Name="Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        [JsonProperty(PropertyName = "RG")]
        [Display(Name = "RG")]
        public string RG { get; set; }

        [JsonProperty(PropertyName = "CPF")]
        [Display(Name = "CPF")]
        public string CPF { get; set; } 

        [JsonProperty(PropertyName = "Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "CEP")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [JsonProperty(PropertyName = "Endereco")]
        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        [JsonProperty(PropertyName = "Telefone")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "DocIdentidade")]
        [Display(Name = "Documento de identidade")]
        public string DocIdentidade { get; set; }

        [JsonProperty(PropertyName = "CompResidencia")]
        [Display(Name = "Comprovante de residência")]
        public string CompResidencia { get; set; }
    }
}