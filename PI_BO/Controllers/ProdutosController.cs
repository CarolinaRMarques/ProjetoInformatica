using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PI_API.Models;
using PI_BO.Models;

namespace PI_BO.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private ProjInformaticaEntities db = new ProjInformaticaEntities();

        // GET: Produtos
        public ActionResult Index(int? page)
        {
            int _page = page ?? 1;
            int pagesize = Int16.Parse(ConfigurationManager.AppSettings["pagesize"]);
            var retval = db.Produto.OrderBy(x => x.Nome).ToPagedList(_page, pagesize);
            return View(retval);
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
            ViewBag.ClasseID = new SelectList(db.Classe, "ID", "Nome");
            ViewBag.ProdutoPaiID = new SelectList(db.Produto, "ID", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,PrecoBase,Imagem,ClasseID,ProdutoPaiID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClasseID = new SelectList(db.Classe, "ID", "Nome", produto.ClasseID);
            ViewBag.ProdutoPaiID = new SelectList(db.Produto, "ID", "Nome", produto.ProdutoPaiID);
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
            ViewBag.ClasseID = new SelectList(db.Classe, "ID", "Nome", produto.ClasseID);
            ViewBag.ProdutoPaiID = new SelectList(db.Produto, "ID", "Nome", produto.ProdutoPaiID);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,PrecoBase,Imagem,ClasseID,ProdutoPaiID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClasseID = new SelectList(db.Classe, "ID", "Nome", produto.ClasseID);
            ViewBag.ProdutoPaiID = new SelectList(db.Produto, "ID", "Nome", produto.ProdutoPaiID);
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
