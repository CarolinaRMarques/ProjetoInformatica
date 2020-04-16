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
    //   [GzipCompression]
    public class EncomendasController : ApiController
    {
        private ProjInformaticaEntities db = new ProjInformaticaEntities();

        // GET: api/Encomendas
        public IQueryable<DTO_Encomenda> GetEncomenda()
        {
            var retVal = db.Encomenda.Select(x => new DTO_Encomenda
            {
                ID = x.ID,
                DataEncomenda = x.DataEncomenda,
                DataEntrega = x.DataEntrega,
                DataRecolha = x.DataRecolha,
                Estado = x.Estado,
                User_ID = x.User_ID
            });
            return retVal;
        }

        // GET: api/Encomendas/5
        [ResponseType(typeof(Encomenda))]
        public IHttpActionResult GetEncomenda(int id)
        {
            Encomenda encomenda = db.Encomenda.Find(id);
            if (encomenda == null)
            {
                return NotFound();
            }

            return Ok(encomenda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EncomendaExists(int id)
        {
            return db.Encomenda.Count(e => e.ID == id) > 0;
        }
    }
}