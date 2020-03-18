using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_API.Models
{
    public class DTO_Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public decimal PrecoBase { get; set; }
        public string Imagem { get; set; }
        public int ClasseID { get; set; }
        public string ClasseNome { get; set; }
        public Nullable<int> ProdutoPaiID { get; set; }
        public string SubProdutoNome { get; set; }
        public int Ingredientes { get; set; }

    }
}