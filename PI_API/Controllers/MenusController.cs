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
    // [GzipCompression]
    public class MenusController : ApiController
    {
        private ProjInformaticaEntities db = new ProjInformaticaEntities();

        // GET: api/Menus
        public IQueryable<DTO_Menu> GetMenu()
        {
            var retVal = db.Menu.Select(x => new DTO_Menu
            {

                ID = x.ID,
                Nome = x.Nome,

            });
            return retVal;
        }

        // GET: api/Menus/5
        [ResponseType(typeof(Menu))]
        public IHttpActionResult GetMenu(int id)
        {
            Menu menu = db.Menu.Find(id);
            if (menu == null)
            {
                return NotFound();
            }

            return Ok(menu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MenuExists(int id)
        {
            return db.Menu.Count(e => e.ID == id) > 0;
        }
    }
}