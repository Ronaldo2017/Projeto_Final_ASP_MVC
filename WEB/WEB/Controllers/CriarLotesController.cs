using BaseModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class CriarLotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CriarLotes
        public ActionResult Index()
        {
            return View(db.CriarLotes.ToList());
        }

        // GET: CriarLotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriarLote criarLote = db.CriarLotes.Find(id);
            if (criarLote == null)
            {
                return HttpNotFound();
            }
            return View(criarLote);
        }

        // GET: CriarLotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CriarLotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CriarLoteID,Lote")] CriarLote criarLote)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if ((db.CriarLotes.FirstOrDefault(l => l.Lote == criarLote.Lote) == null))
                    {
                        db.CriarLotes.Add(criarLote);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Lote Cadastrado com Sucesso!";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Lote já Cadastrado !";
                        return View(criarLote);
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao cadastrar o Lote!";
                    return View(criarLote);
                }

            }

            return View(criarLote);
        }

        // GET: CriarLotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriarLote criarLote = db.CriarLotes.Find(id);
            if (criarLote == null)
            {
                return HttpNotFound();
            }
            return View(criarLote);
        }

        // POST: CriarLotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CriarLoteID,Lote")] CriarLote criarLote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(criarLote).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Lote alterado com Sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro na alteração do Lote!";
                    return View(criarLote);
                }

            }
            return View(criarLote);
        }

        // GET: CriarLotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CriarLote criarLote = db.CriarLotes.Find(id);
            if (criarLote == null)
            {
                return HttpNotFound();
            }
            return View(criarLote);
        }

        // POST: CriarLotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CriarLote criarLote = db.CriarLotes.Find(id);
                db.CriarLotes.Remove(criarLote);
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
