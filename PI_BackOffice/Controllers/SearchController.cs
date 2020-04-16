using PI_BackOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PI_BackOffice.Controllers
{
    public class SearchController : Controller
    {
        private ProjInformaticaEntities db = new ProjInformaticaEntities();
        // GET: Search
        public ActionResult Index(string q)
        {
            var retVal = db.Ingrediente
                .Where(x => x.Nome.Contains(q))
                .Select(x => new DTO_SearchResult()
                {
                    id = x.ID,
                    origem = "Ingredientes",
                    text = x.Nome
                })
                .ToList()
                .Union(
                    db.Produto
                    .Where(x => x.Nome.Contains(q))
                    .Select(x => new DTO_SearchResult()
                    {
                        id = x.ID,
                        origem = "Produtos",
                        text = x.Nome
                    })
                    .ToList()
                )
                .Union(
                    db.Classe
                    .Where(x => x.Nome.Contains(q))
                    .Select(x => new DTO_SearchResult()
                    {
                        id = x.ID,
                        origem = "Classes",
                        text = x.Nome
                    })
                    .ToList()

                );
            ViewBag.SearchString = q;
            return View(retVal);
        }
    }
}