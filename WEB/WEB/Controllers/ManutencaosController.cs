using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BaseModel;
using WEB.Models;
using System;

namespace WEB.Controllers
{
    public class ManutencaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Manutencaos
        public ActionResult Index()
        {
            var manutencaos = db.Manutencaos.Include(m => m._Ferramenta);
            return View(manutencaos.ToList());
        }

        // GET: Manutencaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutencao manutencao = db.Manutencaos.Find(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            return View(manutencao);
        }

        // GET: Manutencaos/Create
        public ActionResult Create()
        {
            ViewBag.FerramentaID = new SelectList(db.Ferramentas, "FerramentaID", "Codigo");
            return View();
        }

        // POST: Manutencaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManutencaoID,CustoManutencao,FerramentaID,DataEntrada,DataSaida")] Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if((db.Manutencaos.FirstOrDefault(m => m.CustoManutencao == manutencao.CustoManutencao && m._Ferramenta == manutencao._Ferramenta && m.DataEntrada == manutencao.DataEntrada && m.DataSaida == manutencao.DataSaida) == null))
                    {
                        db.Manutencaos.Add(manutencao);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Cadastrado realizado com Sucesso!";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Produto já Cadastrado!";
                        return View(manutencao);
                    }
                    
                }catch(Exception e)
                {
                    TempData["Mensagem"] = "Erro ao cadastrar o produto!";
                    return View(manutencao);
                }
                 
            }

            ViewBag.FerramentaID = new SelectList(db.Ferramentas, "FerramentaID", "Codigo", manutencao.FerramentaID);
            return View(manutencao);
        }

        // GET: Manutencaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutencao manutencao = db.Manutencaos.Find(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            ViewBag.FerramentaID = new SelectList(db.Ferramentas, "FerramentaID", "Codigo", manutencao.FerramentaID);
            return View(manutencao);
        }

        // POST: Manutencaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManutencaoID,CustoManutencao,FerramentaID,DataEntrada,DataSaida")] Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(manutencao).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Produto Editada com Sucesso!";
                    return RedirectToAction("Index");
                }catch(Exception e)
                {
                    TempData["Mensagem"] = "Erro ao editar o produto!";
                    return View(manutencao);
                }
             
            }
            ViewBag.FerramentaID = new SelectList(db.Ferramentas, "FerramentaID", "Codigo", manutencao.FerramentaID);
            return View(manutencao);
        }

        // GET: Manutencaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manutencao manutencao = db.Manutencaos.Find(id);
            if (manutencao == null)
            {
                return HttpNotFound();
            }
            return View(manutencao);
        }

        // POST: Manutencaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Manutencao manutencao = db.Manutencaos.Find(id);
                db.Manutencaos.Remove(manutencao);
                db.SaveChanges();
                TempData["Mensagem"] = "Produto Excluído com sucesso!";
                return RedirectToAction("Index");
            }catch(Exception e)
            {
                TempData["Mensagem"] = "Erro ao excluir o produto!";
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
