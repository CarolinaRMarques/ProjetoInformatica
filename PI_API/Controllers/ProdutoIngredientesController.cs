using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using PI_API.Filters;
using PI_API.Models;

namespace PI_API.Controllers
{
    [GzipCompression]
    public class ProdutoIngredientesController : ApiController
    {
        private ProjInformaticaEntities db = new ProjInformaticaEntities();

        // GET: api/ProdutoIngredientes
        public IQueryable<DTO_ProdutoIngrediente> GetProdutoIngrediente()
        {
            var retval = db.ProdutoIngrediente
           .Select(x => new DTO_ProdutoIngrediente()
           {
               Ingrediente_ID = x.Ingrediente_ID,
               Quantidade = x.Quantidade,
               Produto_ID = x.Produto_ID,
               ProdutoNome = x.Produto.Nome,
               IngredienteNome =x.Ingrediente.Nome

           }) ;
            return retval;
        }

        // GET: api/ProdutoIngredientes/5
        [ResponseType(typeof(DTO_ProdutoIngrediente))]
        public IEnumerable<DTO_ProdutoIngrediente> GetProdutoIngrediente(int id )
        {

            var ProdI = db.ProdutoIngrediente.Where(x => x.Produto_ID == id).Select(x =>
                 new DTO_ProdutoIngrediente()
                 {
                     Ingrediente_ID = x.Ingrediente_ID,
                     Quantidade = x.Quantidade,
                     Produto_ID = x.Produto_ID,
                     ProdutoNome = x.Produto.Nome,
                     IngredienteNome = x.Ingrediente.Nome

                 }).ToList();
           

            return ProdI;
        }

        private IQueryable<DTO_ProdutoIngrediente> PartialView(IQueryable<ProdutoIngrediente> retVal)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoIngredienteExists(int id)
        {
            return db.ProdutoIngrediente.Count(e => e.Produto_ID == id) > 0;
        }
    }
}