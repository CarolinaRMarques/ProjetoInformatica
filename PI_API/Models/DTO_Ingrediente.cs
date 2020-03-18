using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PI_API.Models
{
    public class DTO_Ingrediente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public decimal PrecoBase { get; set; }
        public string Imagem { get; set; }
        public bool Disponivel { get; set; }
        public bool Quente { get; set; }
        public bool Frio { get; set; }
    }
}