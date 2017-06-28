using BaseModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class ProdutoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Produtoes
        public ActionResult Index()
        {
            var produtos = db.Produtos.Include(p => p._Maquina);
            return View(produtos.ToList());
        }

        // GET: Produtoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtoes/Create
        public ActionResult Create()
        {
            ViewBag.MaquinaID = new SelectList(db.Maquinas, "MaquinaID", "Codigo");
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,Codigo,Data,MaquinaID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (produto != null)
                    {
                        db.Produtos.Add(produto);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Produto cadastrado com Sucesso!";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Produto já cadastrado!";
                        return View(produto);
                    }

                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao cadastrar o produto!";
                    return View(produto);
                }               
            }
            ViewBag.MaquinaID = new SelectList(db.Maquinas, "MaquinaID", "Codigo", produto.MaquinaID);
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaquinaID = new SelectList(db.Maquinas, "MaquinaID", "Codigo", produto.MaquinaID);
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,Codigo,Data,MaquinaID")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    db.Entry(produto).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Produto Editado com Sucesso!";
                    return RedirectToAction("Create");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao editar o produto!";
                    return View(produto);
                }

            }
            ViewBag.MaquinaID = new SelectList(db.Maquinas, "MaquinaID", "Codigo", produto.MaquinaID);
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Produto produto = db.Produtos.Find(id);
                db.Produtos.Remove(produto);
                db.SaveChanges();
                TempData["Mensagem"] = "Produto Excluído com sucesso!";
                return RedirectToAction("Create");
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro ao Excluir a Produto!";
                return View();
            }

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
