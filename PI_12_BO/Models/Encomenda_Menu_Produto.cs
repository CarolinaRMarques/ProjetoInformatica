//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI_12_BO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Encomenda_Menu_Produto
    {
        public int Encomenda_ID { get; set; }
        public int Produto_ID { get; set; }
        public int Menu_ID { get; set; }
        public string Quantidade { get; set; }
        public decimal PrecoBase { get; set; }
    
        public virtual Encomenda Encomenda { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
