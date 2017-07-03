using BaseModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class LotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lotes
        public ActionResult Index()
        {
            var lotes = db.Lotes.Include(l => l._CriarLote).Include(l => l._Ferramenta);
            return View(lotes.ToList());
        }

        // GET: Lotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lotes.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // GET: Lotes/Create
        public ActionResult Create()
        {
            ViewBag.CriarLoteID = new SelectList(db.CriarLotes, "CriarLoteID", "Lote");
            ViewBag.FerramentaID = new SelectList(db.Ferramentas, "FerramentaID", "Codigo");
            return View();
        }

        // POST: Lotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LoteID,LoteFerramenta,FerramentaID,CriarLoteID")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (lote != null)
                    {
                        db.Lotes.Add(lote);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Lote Cadastrado com Sucesso!";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Lote já Cadastrado !";
                        return View(lote);
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao cadastrar o lote!";
                    return View(lote);
                }
            }

            ViewBag.CriarLoteID = new SelectList(db.CriarLotes, "CriarLoteID", "Lote", lote.CriarLoteID);
            ViewBag.FerramentaID = new SelectList(db.Ferramentas, "FerramentaID", "Codigo", lote.FerramentaID);
            return View(lote);
        }

        // GET: Lotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lotes.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            ViewBag.CriarLoteID = new SelectList(db.CriarLotes, "CriarLoteID", "Lote", lote.CriarLoteID);
            ViewBag.FerramentaID = new SelectList(db.Ferramentas, "FerramentaID", "Codigo", lote.FerramentaID);
            return View(lote);
        }

        // POST: Lotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LoteID,LoteFerramenta,FerramentaID,CriarLoteID")] Lote lote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(lote).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Lote alterado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro para na alteração do Lote!";
                    return View(lote);
                }

            }
            ViewBag.CriarLoteID = new SelectList(db.CriarLotes, "CriarLoteID", "Lote", lote.CriarLoteID);
            ViewBag.FerramentaID = new SelectList(db.Ferramentas, "FerramentaID", "Codigo", lote.FerramentaID);
            return View(lote);
        }

        // GET: Lotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lote lote = db.Lotes.Find(id);
            if (lote == null)
            {
                return HttpNotFound();
            }
            return View(lote);
        }

        // POST: Lotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Lote lote = db.Lotes.Find(id);
                db.Lotes.Remove(lote);
                db.SaveChanges();
                TempData["Mensagem"] = "Lote Excluído com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro ao Excluir o Lote!";
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
