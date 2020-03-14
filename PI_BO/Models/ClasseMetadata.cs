using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_BO.Models
{
    public partial class ClasseMetadata
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Produtos")]
        public virtual IList<Produto> Produto { get; set; }
    }
}