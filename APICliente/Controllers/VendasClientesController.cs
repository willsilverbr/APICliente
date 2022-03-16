using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APICliente.Models;
using System.Net.Http;
using System.Net.Http.Headers;


namespace APICliente.Controllers
{
    public class VendasClientesController : Controller
    {


        private AnaliseDeCreditoEntities db = new AnaliseDeCreditoEntities();

        // GET: VendasClientes
        public ActionResult Index()
        {
            return View(db.VendasCliente.ToList());
        }

        // GET: VendasClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendasCliente vendasCliente = db.VendasCliente.Find(id);
            if (vendasCliente == null)
            {
                return HttpNotFound();
            }
            return View(vendasCliente);
        }

        // GET: VendasClientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendasClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo,Data_Venda,Valor_Venda")] VendasCliente vendasCliente)
        {
            if (ModelState.IsValid)
            {
                db.VendasCliente.Add(vendasCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendasCliente);
        }

        // GET: VendasClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendasCliente vendasCliente = db.VendasCliente.Find(id);
            if (vendasCliente == null)
            {
                return HttpNotFound();
            }
            return View(vendasCliente);
        }

        // POST: VendasClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo,Data_Venda,Valor_Venda")] VendasCliente vendasCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendasCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendasCliente);
        }

        // GET: VendasClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendasCliente vendasCliente = db.VendasCliente.Find(id);
            if (vendasCliente == null)
            {
                return HttpNotFound();
            }
            return View(vendasCliente);
        }

        // POST: VendasClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendasCliente vendasCliente = db.VendasCliente.Find(id);
            db.VendasCliente.Remove(vendasCliente);
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
