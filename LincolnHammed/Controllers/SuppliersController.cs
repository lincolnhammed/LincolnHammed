using LincolnHammed.Contexts;
using LincolnHammed.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LincolnHammed.Controllers
{
    public class SuppliersController : Controller
    {
        private EFContext context = new EFContext();

        #region[Action]
        // GET: Suppliers]
        public ActionResult Index()
        {

            //  var query1 = context.Supplier.OrderBy(supplier => supplier.Nome).Select(x => new { Name = x.Nome });
            // var query = from supplier in context.Supplier
            //  orderby supplier.Nome
            // select new {
            //    Name =supplier.Nome
            //};
            return View(context.Supplier.OrderBy(c => c.Nome));
        }

        #region[Create]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        // sobresquita de metodo varias assinaturas diferentes
        public ActionResult Create(Supplier supplier)
        {
            context.Supplier.Add(supplier);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
        #endregion

        #region[Edit]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {

                context.Entry(supplier).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier);
        }
        #endregion

        #region[Details]
        //recebe paramentro ele é um indentificador
        // long? é opcional
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Supplier.Find(id);

            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }
        #endregion

        #region[Delete]
        //	GET:	Fabricantes/Delete/5 
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = context.Supplier.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();

            }
            return View(supplier);
        }

        //	POST:	Fabricantes/Delete/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Supplier supplier = context.Supplier.Find(id);
            context.Supplier.Remove(supplier);
            context.SaveChanges();
            TempData["Message"] = "Fabricante	"
                + supplier.Nome.ToUpper()
                + "	foi	removido";
            return RedirectToAction("Index");
        }



        #endregion


        #endregion
    }
}