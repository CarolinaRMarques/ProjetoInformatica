using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_12_BO.Models
{
    public partial class ProdutoMetadata
    {
        public int ID { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Classe")]
        public int Classe_ID { get; set; }
        [Display(Name = "É subproduto de ...")]
        public Nullable<int> SubProduto_ID { get; set; }
        [Display(Name = "Preço Base")]
        public decimal PrecoBase { get; set; }
        [Display(Name = "Imagem")]
        public string Imagem { get; set; }
    }
}