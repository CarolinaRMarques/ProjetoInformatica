using System.ComponentModel.DataAnnotations;

namespace PI_BO.Models
{
    public partial class IngredienteMetadata
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Preço")]
        public decimal PrecoBase { get; set; }
        [Display(Name = "Imagem")]
        public string Imagem { get; set; }
        [Display(Name = "Disponivel?")]
        public bool Disponivel { get; set; }
        [Display(Name = "Quente?")]
        public bool Quente { get; set; }
        [Display(Name = "Frio?")]
        public bool Frio { get; set; }
    }
}