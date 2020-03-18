using System.ComponentModel.DataAnnotations;

namespace PI_BackOffice.Models
{
    public partial class ClasseMetadata
    {
        public int ID { get; set; }
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
    }
}