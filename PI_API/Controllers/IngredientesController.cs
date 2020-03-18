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
    // [Authorize]
    [GzipCompression]
    /// <summary>
    /// Faz a gestão da Entidade Ingredientes
    /// </summary>
    public class IngredientesController : ApiController
    {
        private ProjInformaticaEntities db = new ProjInformaticaEntities();

        // GET: api/Ingredientes
        /// <summary>
        /// Devolve a lista de Ingredientes
        /// </summary>
        /// <returns></returns>
       
        public IQueryable<DTO_Ingrediente> GetIngrediente()
        {
            //return db.Ingrediente;
            var retVal = db.Ingrediente.Select(x => new DTO_Ingrediente {
                Disponivel = x.Disponivel,
                ID = x.ID, 
                Imagem = x.Imagem, 
                Nome = x.Nome, 
                PrecoBase = x.PrecoBase 
            });
            return retVal;
        }

        // GET: api/Ingredientes/5
        /// <summary>
        /// Devolve a informação relativa a um Ingrediente
        /// </summary>
        /// <param name="id">Identificador do Ingrediente</param>
        /// <returns>Devolve a informção relativa ao Ingrediente Selecionada </returns>
        [ResponseType(typeof(Ingrediente))]
        public IHttpActionResult GetIngrediente(int id)
        {
            Ingrediente ingrediente = db.Ingrediente.Find(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            return Ok(ingrediente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IngredienteExists(int id)
        {
            return db.Ingrediente.Count(e => e.ID == id) > 0;
        }
    }
}