using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_BackOffice.Models
{
    [MetadataType(typeof(IngredienteMetadata))]
    public partial class Ingrediente { };
    [MetadataType(typeof(ProdutoMetadata))]
    public partial class Produto { };
    [MetadataType(typeof(ClasseMetadata))]
    public partial class Classe { };
}