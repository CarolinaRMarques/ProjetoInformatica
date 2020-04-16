using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_API.Models
{
    public class DTO_Encomenda_Menu_Produto
    {
        public int Encomenda_ID { get; set; }
        public int Produto_ID { get; set; }
        public int Menu_ID { get; set; }
        public string Quantidade { get; set; }
        public decimal PrecoBase { get; set; }

    }
}