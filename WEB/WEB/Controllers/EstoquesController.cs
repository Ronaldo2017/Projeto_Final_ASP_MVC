using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BaseModel;
using WEB.Models;
using System;

namespace WEB.Controllers
{
    public class EstoquesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Estoques
        public ActionResult Index()
        {
            var estoques = db.Estoques.Include(e => e._Lote);
            return View(estoques.ToList());
        }

        // GET: Estoques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // GET: Estoques/Create
        public ActionResult Create()
        {
            ViewBag.LoteID = new SelectList(db.Lotes, "LoteID", "LoteFerramenta");
            return View();
        }

        // POST: Estoques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EstoqueID,LoteID,_Situacao,DataEntrada,DataSaida")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Estoques.Add(estoque);
                    db.SaveChanges();
                    TempData["Mensagem"] = "Cadastrado com sucesso!";
                    return RedirectToAction("Create");

                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao cadastrar!";
                    return View(estoque);
                }

            }

            ViewBag.LoteID = new SelectList(db.Lotes, "LoteID", "LoteFerramenta", estoque.LoteID);
            return View(estoque);
        }

        // GET: Estoques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoteID = new SelectList(db.Lotes, "LoteID", "LoteFerramenta", estoque.LoteID);
            return View(estoque);
        }

        // POST: Estoques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EstoqueID,LoteID,Situação,DataEntrada,DataSaida")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(estoque).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Produto alterado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro na alteração do Produto!";
                    return View(estoque);
                }

            }
            ViewBag.LoteID = new SelectList(db.Lotes, "LoteID", "LoteFerramenta", estoque.LoteID);
            return View(estoque);
        }

        // GET: Estoques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // POST: Estoques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Estoque estoque = db.Estoques.Find(id);
                db.Estoques.Remove(estoque);
                db.SaveChanges();
                TempData["Mensagem"] = "Produto Excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro ao Excluir o Produto!";
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
