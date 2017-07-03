using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BaseModel;
using WEB.Models;
using System;

namespace WEB.Controllers
{
    public class FerramentasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ferramentas
        public ActionResult Index()
        {
            return View(db.Ferramentas.ToList());
        }

        // GET: Ferramentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ferramenta ferramenta = db.Ferramentas.Find(id);
            if (ferramenta == null)
            {
                return HttpNotFound();
            }
            return View(ferramenta);
        }

        // GET: Ferramentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ferramentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FerramentaID,Codigo,Descricao,Data")] Ferramenta ferramenta)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if ((db.Ferramentas.FirstOrDefault(f => f.Codigo == ferramenta.Codigo && f.Descricao == ferramenta.Descricao && f.Data == ferramenta.Data) == null))
                    {
                        db.Ferramentas.Add(ferramenta);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Ferramenta Cadastrada com Sucesso!";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Ferramenta já Cadastrada !";
                        return View(ferramenta);
                    }

                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao cadastrar a ferramenta!";
                    return View(ferramenta);
                }
            }
            return View(ferramenta);
        }

        // GET: Ferramentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ferramenta ferramenta = db.Ferramentas.Find(id);
            if (ferramenta == null)
            {
                return HttpNotFound();
            }
            return View(ferramenta);
        }

        // POST: Ferramentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FerramentaID,Codigo,Descricao,Data")] Ferramenta ferramenta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(ferramenta).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Ferramenta alterada com Sucesso!";
                    return RedirectToAction("Index");
                }catch(Exception e)
                {
                    TempData["Mensagem"] = "Erro na alteração da ferramenta!";
                    return View(ferramenta);
                }
            }
            return View(ferramenta);
        }

        // GET: Ferramentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ferramenta ferramenta = db.Ferramentas.Find(id);
            if (ferramenta == null)
            {
                return HttpNotFound();
            }
            return View(ferramenta);
        }

        // POST: Ferramentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Ferramenta ferramenta = db.Ferramentas.Find(id);
                db.Ferramentas.Remove(ferramenta);
                db.SaveChanges();
                TempData["Mensagem"] = "Ferramenta Excluída com sucesso!";
                return RedirectToAction("Index");
            }catch(Exception e)
            {
                TempData["Mensagem"] = "Erro ao Excluir a ferramenta!";
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
