using LincolnHammed.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LincolnHammed.Models;

namespace LincolnHammed.Controllers
{
    public class ProductController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Product
        public ActionResult Index()
        {
            var produtos = context
                .Products
                .Include(c => c.Category)
                .Include(f => f.Supplier)
                .OrderBy(n => n.Nome);
            return View(produtos);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(context.Categories.
                OrderBy(b => b.Nome), "CategoryId", "Nome");
            ViewBag.SupplierId = new SelectList(context.Suppliers.
                OrderBy(b => b.Nome), "SupplierId", "Nome");
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(product);
            }
        }


        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
