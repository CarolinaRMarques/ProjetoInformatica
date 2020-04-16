using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PI_12_BO.Models;

namespace PI_12_BO.Controllers
{
    [Authorize]
    public class Menu_ProdutoController : Controller
    {
        private pi_12Entities db = new pi_12Entities();

        // GET: Menu_Produto
        public ActionResult _IndexProdutos(int Menu_ID)
        {
            var retVal = db.Menu_Produto
                .Where(x => x.Menu_ID == Menu_ID)
                .Include(x => x.Menu)
                .Include(x => x.Produto)
                .OrderBy(x => x.Produto.Nome);
            ViewBag.Menu_ID = Menu_ID;
            return PartialView(retVal);
        }

        
        public ActionResult _ProdutosParaMenu(int Menu_ID)
        {
            HashSet<int> setToRemove = new HashSet<int>(db.Menu_Produto
                                    .Where(x => x.Menu_ID == Menu_ID)
                                    .Select(x => x.Produto.ID)
                                    .ToList());
            List<SelectListItem> Produtos = db.Produto
                                    .Where(r => !setToRemove.Contains(r.ID))
                                    .OrderBy(x => x.Nome)
                                    .Select(x => new SelectListItem()
                                    {
                                        Text = x.Nome,
                                        Value = x.ID.ToString()
                                    })
                                    .ToList();

            ViewBag.Menu_ID = Menu_ID;
            ViewBag.Produtos = Produtos;
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssociateProduto([Bind(Include = "Menu_ID,Produto_ID,Quantidade")] Menu_Produto menu_produto)
        {
            if (ModelState.IsValid)
            {
                db.Menu_Produto.Add(menu_produto);
                db.SaveChanges();
                return RedirectToAction("Details", "Menus", new { ID = menu_produto.Menu_ID });
            }

            return RedirectToAction("_ProdutosParaMenu", "Menu_Produto", new { ID = menu_produto.Menu_ID });
        }

        public ActionResult _ProdutoEmMenu(int Menu_ID, int Produto_ID)
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
        public ActionResult RemoveProduto(int Menu_ID, int Produto_ID)
        {
            Menu_Produto menu_produto = db.Menu_Produto.FirstOrDefault(x => x.Menu_ID == Menu_ID && x.Produto_ID == Produto_ID);
            if (menu_produto != null)
            {
                db.Menu_Produto.Remove(menu_produto);
                db.SaveChanges();
            }
            return RedirectToAction("Details", "Menus", new { ID = Menu_ID });
        }
    }
}
