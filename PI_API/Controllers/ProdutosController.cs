using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PI_API.Filters;
using PI_API.Models;

namespace PI_API.Controllers
{
    [GzipCompression]
    public class ProdutosController : ApiController
    {
        private ProjInformaticaEntities db = new ProjInformaticaEntities();

        // GET: api/Produtos
        public IQueryable<DTO_Produto> GetProduto()
        {
            var retval = db.Produto
            .Select(x => new DTO_Produto()
            {
                ID = x.ID,
                ClasseID = x.ClasseID,
                ClasseNome = x.Classe.Nome,
                Imagem = x.Imagem,
                Nome = x.Nome,
                PrecoBase = x.PrecoBase,
                ProdutoPaiID = x.ProdutoPaiID,
                SubProdutoNome = x.Produto2.Nome,
                Ingredientes = x.ProdutoIngrediente.Count()
                });
            return retval;
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produto.Count(e => e.ID == id) > 0;
        }
    }
}