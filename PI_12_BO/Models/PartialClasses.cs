using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PI_12_BO.Models
{
    [MetadataType(typeof(IngredienteMetadata))]
    public partial class Ingrediente { }

    [MetadataType(typeof(ProdutoMetadata))]
    public partial class Produto { }

    [MetadataType(typeof(Produto_IngredienteMetadata))]
    public partial class Produto_Ingrediente { }

    [MetadataType(typeof(AspNetUsersMetdata))]
    public partial class AspNetUsers { }
}