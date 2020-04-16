using PI_12_BO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PI_12_BO.Controllers
{
    [Authorize]
    public class Produtos_IngredientesController : Controller
    {
        private pi_12Entities db = new pi_12Entities();

        // GET: Produtos_Ingredientes
        public ActionResult _IndexIngredientes(int Produto_ID)
        {
            var retVal = db.Produto_Ingrediente
                .Where(x => x.Produto_ID == Produto_ID)
                .Include(x => x.Produto)
                .Include(x => x.Ingrediente)
                .OrderBy(x => x.Ingrediente.Nome);
            ViewBag.Produto_ID = Produto_ID;
            return PartialView(retVal);
        }

        public ActionResult _IngredientesParaProduto(int Produto_ID)
        {
            HashSet<int> setToRemove = new HashSet<int>(db.Produto_Ingrediente
                                    .Where(x => x.Produto_ID == Produto_ID)
                                    .Select(x => x.Ingrediente.ID)
                                    .ToList());
            List<SelectListItem> Ingredientes = db.Ingrediente
                                    .Where(r => !setToRemove.Contains(r.ID))
                                    .OrderBy(x => x.Nome)
                                    .Select(x => new SelectListItem()
                                    {
                                        Text = x.Nome,
                                        Value = x.ID.ToString()
                                    })
                                    .ToList();
           
            ViewBag.Produto_ID = Produto_ID;
            ViewBag.Ingredientes = Ingredientes;
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssociateIngrediente([Bind(Include = "Produto_ID,Ingrediente_ID,Quantidade")] Produto_Ingrediente produto_ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Produto_Ingrediente.Add(produto_ingrediente);
                db.SaveChanges();
                return RedirectToAction("Details", "Produtos", new { ID = produto_ingrediente.Produto_ID });
            }

            return RedirectToAction("_IngredientesParaProduto", "Produtos_Ingredientes", new { ID = produto_ingrediente.Produto_ID });
        }

        public ActionResult _IngredienteEmProduto(int Produto_ID, int Ingrediente_ID)
        {
            //Produto_Ingrediente produto_ingrediente = db.Produto_Ingrediente.FirstOrDefault(x => x.Produto_ID == Produto_ID && x.Ingrediente_ID == Ingrediente_ID);
            //if (produto_ingrediente == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //return PartialView(produto_ingrediente);
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveIngrediente(int Produto_ID, int Ingrediente_ID)
        {
            Produto_Ingrediente produto_ingrediente = db.Produto_Ingrediente.FirstOrDefault(x => x.Produto_ID == Produto_ID && x.Ingrediente_ID == Ingrediente_ID);
            if (produto_ingrediente != null)
            {
                db.Produto_Ingrediente.Remove(produto_ingrediente);
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Produtos", new { ID = Produto_ID });
        }
    }
}