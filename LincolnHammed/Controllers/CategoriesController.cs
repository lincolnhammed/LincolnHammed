using Models.Tables;
using Persistences.Contexts;
using Service.Registers;
using Service.Registration;
using Service.Tables;
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
        #region[//]
        
        private ProductService productService = new ProductService();
        private CategoryService categoryService = new CategoryService();
        private SupplierService supplierService = new SupplierService();

        #region [Index]
        public ActionResult Index()
        {
            return View(categoryService.
           GetCategoriesOrderByName());
        }
        #endregion

        #region[Edit]
        public ActionResult Edit(long? id)
        {
            PublicViewBag(categoryService.GetCategoryById((long)id));
            return GetViewCategoryById(id);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            return SaveCategory(category);
        }
        #endregion

        #region[Create]
        public ActionResult Create()
        {
            PublicViewBag();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            return SaveCategory(category);
        }
        #endregion

        #region[ Delete]
        public ActionResult Delete(long? id)
        {
            return GetViewCategoryById(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Category category = categoryService.DeleteCategoryForId(id);
                TempData["Message"] = "Product " + category.Nome.ToUpper()
                + " was removed";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region[ Details] 

        public ActionResult Details(long? id)
        {
            return GetViewCategoryById(id);
        }
        #endregion

        #region[SaveProduct]
        private ActionResult SaveCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryService.SaveCategory(category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }
        #endregion

        #region[GetViewCategoryById] 
        private ActionResult GetViewCategoryById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Category category = categoryService.GetCategoryById((long)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        #endregion

        #region[PublicViewBag]
        private void PublicViewBag(Category category = null)
        {
            if (category == null)
            {
                ViewBag.categoryId = new SelectList(categoryService.
              GetCategoriesOrderByName(),
               "SupplierId", "Nome");


            }

            else
            {
                ViewBag.CategoryId = new SelectList(categoryService.
                GetCategoriesOrderByName(),
                "SupplierId", "Nome", category.CategoryId);
            }

        }
        #endregion
       
        #endregion[//]

        #region [comentario]
        /*
        #region [ Properties ]

        private EFContext context =
            new EFContext();

        #endregion [ Properties ]

        #region [ Actions ]

        // GET: Categories
        public ActionResult Index()
        {
            var categories = context
                .Categories.OrderBy(s => s.Nome);

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
                .Categories
                .Where(f => f.CategoryId == id)
                .Include("Products.Supplier")
                .First();

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

            var category = context.Categories.Find(id);

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
   */
        #endregion
    }
}