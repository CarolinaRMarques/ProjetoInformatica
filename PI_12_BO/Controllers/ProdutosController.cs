using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PI_12_BO.Models;

namespace PI_12_BO.Controllers
{
   [Authorize]
    public class ProdutosController : Controller
    {
        private pi_12Entities db = new pi_12Entities();

        // GET: Produtos
        public ActionResult Index(int? page)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            int pageSize = Int16.Parse(System.Configuration.ConfigurationManager.AppSettings["ItemsPorPagina"]);
            int pageNumber = (page ?? 1);

            var retVal = db.Produto
                            //.Include(p => p.Classe)
                            //.Include(p => p.Produto2)
                            .OrderBy(x => x.Nome)
                            .ToPagedList(pageNumber, pageSize);

            stopwatch.Stop();
            ViewBag.ElapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            return View(retVal);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.Classe_ID = new SelectList(db.Classe, "ID", "Nome");
            ViewBag.SubProduto_ID = new SelectList(db.Produto, "ID", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Classe_ID,SubProduto_ID,PrecoBase,Imagem")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Classe_ID = new SelectList(db.Classe, "ID", "Nome", produto.Classe_ID);
            ViewBag.SubProduto_ID = new SelectList(db.Produto, "ID", "Nome", produto.SubProduto_ID);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classe_ID = new SelectList(db.Classe, "ID", "Nome", produto.Classe_ID);
            ViewBag.SubProduto_ID = new SelectList(db.Produto, "ID", "Nome", produto.SubProduto_ID);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Classe_ID,SubProduto_ID,PrecoBase,Imagem")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Classe_ID = new SelectList(db.Classe, "ID", "Nome", produto.Classe_ID);
            ViewBag.SubProduto_ID = new SelectList(db.Produto, "ID", "Nome", produto.SubProduto_ID);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produto.Find(id);
            db.Produto.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
