using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_12_BO.Models
{
    public partial class IngredienteMetadata
    {
        public int ID { get; set; }
        [StringLength(256)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Preço base")]
        public decimal PrecoBase { get; set; }
        [Display(Name = "Imagem")]
        public string Imagem { get; set; }
        [Display(Name = "Disponível?")]
        public bool Disponivel { get; set; }

    }
}