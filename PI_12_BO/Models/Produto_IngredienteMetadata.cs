using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_12_BO.Models
{
    public class Produto_IngredienteMetadata
    {
        [Display(Name = "Produto")]
        public int Produto_ID { get; set; }

        [Display(Name = "Ingrediente")]
        public int Ingrediente_ID { get; set; }

        [Required]
        [Display(Name ="Quantidade")]
        public string Quantidade { get; set; }
    }
}