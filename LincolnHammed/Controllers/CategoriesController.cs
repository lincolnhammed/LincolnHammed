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
    public class CategoriesController : Controller
    {

        #region [ Properties ]

        private EFContext context =
            new EFContext();

        #endregion [ Properties ]

        #region [ Actions ]

        // GET: Categories
        public ActionResult Index()
        {
            var categories = context
                .Categories

                .OrderBy(s => s.Nome);

            return View(categories);
        }

        // GET: Categories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = context
                .Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        #region [ Create ]

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion [ Create ]

        #region [ Edit ]

        // GET: Categories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = context
                .Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Entry(category)
                        .State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }

        #endregion [ Edit ]

        #region [ Delete ]

        // GET: Categories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                    HttpStatusCode.BadRequest);
            }

            var category = context
                .Categories.Find(id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            var category = context
                .Categories
                .Find(id);

            context
                .Categories
                .Remove(category);

            context.SaveChanges();

            return RedirectToAction("Index");
        }

        #endregion [ Edit ]

        #endregion [ Actions ]

    }
}