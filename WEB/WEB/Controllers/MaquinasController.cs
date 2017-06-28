using BaseModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class MaquinasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maquinas
        public ActionResult Index()
        {
            return View(db.Maquinas.ToList());
        }

        // GET: Maquinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maquina maquina = db.Maquinas.Find(id);
            if (maquina == null)
            {
                return HttpNotFound();
            }
            return View(maquina);
        }

        // GET: Maquinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaquinaID,Codigo,Descricao,Data")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (maquina != null)
                    {
                        db.Maquinas.Add(maquina);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Máquina salva com sucesso!";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Máquina já cadastrada!";
                        return View(maquina);
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao cadastrar a máquina!";
                    return View(maquina);
                }

            }

            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maquina maquina = db.Maquinas.Find(id);
            if (maquina == null)
            {
                return HttpNotFound();
            }
            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaquinaID,Codigo,Descricao,Data")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(maquina).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Máquina Editada com sucesso!";
                    return RedirectToAction("Edit");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Error ao Editar!";
                    return View(maquina);
                }
            }
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maquina maquina = db.Maquinas.Find(id);
            if (maquina == null)
            {
                return HttpNotFound();
            }
            return View(maquina);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Maquina maquina = db.Maquinas.Find(id);
                db.Maquinas.Remove(maquina);
                db.SaveChanges();
                TempData["Mensagem"] = "Máquina Excluída com sucesso!";
                return RedirectToAction("Delete");
            }catch(Exception e)
            {
                TempData["Mensagem"] = "Erro ao Excluir a máquina!";
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
