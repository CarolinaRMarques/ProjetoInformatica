//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PI_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            this.Encomenda_Menu_Produto = new HashSet<Encomenda_Menu_Produto>();
            this.Encomenda_Produto_Ingrediente = new HashSet<Encomenda_Produto_Ingrediente>();
            this.Menu_Produto = new HashSet<Menu_Produto>();
            this.Produto_Ingrediente = new HashSet<Produto_Ingrediente>();
            this.Produto1 = new HashSet<Produto>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public decimal PrecoBase { get; set; }
        public string Imagem { get; set; }
        public int Classe_ID { get; set; }
        public Nullable<int> SubProduto_ID { get; set; }
    
        public virtual Classe Classe { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda_Menu_Produto> Encomenda_Menu_Produto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Encomenda_Produto_Ingrediente> Encomenda_Produto_Ingrediente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu_Produto> Menu_Produto { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto_Ingrediente> Produto_Ingrediente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produto> Produto1 { get; set; }
        public virtual Produto Produto2 { get; set; }
    }
}
