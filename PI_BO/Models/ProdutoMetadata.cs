using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_BO.Models
{
    public partial class ProdutoMetadata
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Preço")]
        public decimal PrecoBase { get; set; }
        [Display(Name = "URL da Imagem")]
        public string Imagem { get; set; }
        public Nullable<int> ClasseID { get; set; }
        public Nullable<int> ProdutoPaiID { get; set; }
    }
}