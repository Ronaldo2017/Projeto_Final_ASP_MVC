using BaseModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WEB.Models;

namespace WEB.Controllers
{
    public class ProducaosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Producaos
        public ActionResult Index()
        {
            var producaos = db.Producaos.Include(p => p._Lote).Include(p => p._Maquina).Include(p => p._Produto);
            return View(producaos.ToList());
        }

        // GET: Producaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producao producao = db.Producaos.Find(id);
            if (producao == null)
            {
                return HttpNotFound();
            }
            return View(producao);
        }

        // GET: Producaos/Create
        public ActionResult Create()
        {
            ViewBag.LoteID = new SelectList(db.Lotes, "LoteID", "LoteFerramenta");
            ViewBag.MaquinaID = new SelectList(db.Maquinas, "MaquinaID", "Codigo");
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Codigo");
            return View();
        }

        // POST: Producaos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProducaoID,DataEntrada,LoteID,MaquinaID,ProdutoID")] Producao producao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if(producao != null)
                    {
                        db.Producaos.Add(producao);
                        db.SaveChanges();
                        TempData["Mensagem"] = "Cadastrado realizado com Sucesso!";
                        return RedirectToAction("Create");
                    }
                    else
                    {
                        TempData["Mensagem"] = "Produtos já Cadastrado !";
                        return View(producao);
                    }
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao cadastrar os produtos!";
                    return View(producao);
                }
                
            }

            ViewBag.LoteID = new SelectList(db.Lotes, "LoteID", "LoteFerramenta", producao.LoteID);
            ViewBag.MaquinaID = new SelectList(db.Maquinas, "MaquinaID", "Codigo", producao.MaquinaID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Codigo", producao.ProdutoID);
            return View(producao);
        }

        // GET: Producaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producao producao = db.Producaos.Find(id);
            if (producao == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoteID = new SelectList(db.Lotes, "LoteID", "LoteFerramenta", producao.LoteID);
            ViewBag.MaquinaID = new SelectList(db.Maquinas, "MaquinaID", "Codigo", producao.MaquinaID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Codigo", producao.ProdutoID);
            return View(producao);
        }

        // POST: Producaos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProducaoID,DataEntrada,LoteID,MaquinaID,ProdutoID")] Producao producao)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(producao).State = EntityState.Modified;
                    db.SaveChanges();
                    TempData["Mensagem"] = "Produtos alterados com sucesso!";
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    TempData["Mensagem"] = "Erro ao editar o Lote!";
                    return View(producao);
                }
                
            }
            ViewBag.LoteID = new SelectList(db.Lotes, "LoteID", "LoteFerramenta", producao.LoteID);
            ViewBag.MaquinaID = new SelectList(db.Maquinas, "MaquinaID", "Codigo", producao.MaquinaID);
            ViewBag.ProdutoID = new SelectList(db.Produtos, "ProdutoID", "Codigo", producao.ProdutoID);
            return View(producao);
        }

        // GET: Producaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producao producao = db.Producaos.Find(id);
            if (producao == null)
            {
                return HttpNotFound();
            }
            return View(producao);
        }

        // POST: Producaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Producao producao = db.Producaos.Find(id);
                db.Producaos.Remove(producao);
                db.SaveChanges();
                TempData["Mensagem"] = "Produtos excluídos com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Mensagem"] = "Erro ao Excluir os produtos!";
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
