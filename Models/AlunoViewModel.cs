using System;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

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
        [ModelBinder(BinderType = typeof(PtBrDateTimeBinder))]
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

        // [JsonProperty(PropertyName = "DocIdentidade")]
        // [Display(Name = "Documento de identidade")]
        // public string DocIdentidade { get; set; }

        // [JsonProperty(PropertyName = "CompResidencia")]
        // [Display(Name = "Comprovante de residência")]
        // public string CompResidencia { get; set; }
    }

    public class PtBrDateTimeBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            var value = valueProviderResult.FirstValue;
            DateTime outDate;
            var parsed = DateTime.TryParse(value, new CultureInfo("pt-BR").DateTimeFormat,
                DateTimeStyles.None, out outDate);
    
            var result = ModelBindingResult.Success(outDate);
            if (!parsed)
            {
                result = ModelBindingResult.Failed();
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, "Data inválida");
            }
    
            bindingContext.Result = result;
    
            return Task.FromResult(0);
        }
    }
}