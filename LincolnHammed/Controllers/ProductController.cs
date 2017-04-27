using LincolnHammed.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LincolnHammed.Models;
using System.Net;

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
                .OrderBy(n => n.Supplier.Nome);
            return View(produtos);
        }

        // GET: Product/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId == id)
              .Include(c => c.Category)
              .Include(f => f.Supplier).First();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
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


        //	GET:	Produtos/Edit/5 
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new
                SelectList(context.Categories.OrderBy(b => b.Nome), "CategoryId", "Nome", product.CategoryId);
            ViewBag.SupplierId = new
                SelectList(context.Suppliers.OrderBy(b => b.Nome), "SupplierId", "Nome", product.SupplierId);
            return View(product);
        }
        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(product).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = context.Products.Where(p => p.ProductId == id)
              .Include(c => c.Category)
              .Include(f => f.Supplier).First();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Product/Delete/5
        //	POST:	Produtos/Delete/5 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Product product = context.Products.Find(id);
                context.Products.Remove(product);
                context.SaveChanges();
                TempData["Message"] = "Produto	" + product.Nome.ToUpper()
                + "	foi	removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
