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
  //  [GzipCompression]
    public class Encomenda_Menu_ProdutoController : ApiController
    {
        private ProjInformaticaEntities db = new ProjInformaticaEntities();

        // GET: api/Encomenda_Menu_Produto
        public IQueryable<DTO_Encomenda_Menu_Produto> GetEncomenda_Menu_Produto()
        {
            var retVal = db.Encomenda_Menu_Produto.Select(x => new DTO_Encomenda_Menu_Produto
            {
               Encomenda_ID = x.Encomenda_ID,
               Produto_ID = x.Produto_ID,
               Menu_ID = x.Produto_ID,
               Quantidade = x.Quantidade,
               PrecoBase = x.PrecoBase
            });
            return retVal;
        }

        // GET: api/Encomenda_Menu_Produto/5
        [ResponseType(typeof(Encomenda_Menu_Produto))]
        public IHttpActionResult GetEncomenda_Menu_Produto(int id)
        {
            Encomenda_Menu_Produto encomenda_Menu_Produto = db.Encomenda_Menu_Produto.Find(id);
            if (encomenda_Menu_Produto == null)
            {
                return NotFound();
            }

            return Ok(encomenda_Menu_Produto);
        }

     

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Encomenda_Menu_ProdutoExists(int id)
        {
            return db.Encomenda_Menu_Produto.Count(e => e.Encomenda_ID == id) > 0;
        }
    }
}