using LincolnHammed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LincolnHammed.Controllers
{
    public class CategoriesController : Controller
    {
        #region [List Category]
        private static IList<Category> categories = new List<Category>()
        {
            new Category() {CategoryId = 1, Nome= "Notebooks"},
            new Category() {CategoryId = 2, Nome= "Monitores"},
            new Category() {CategoryId = 3, Nome= "Impressoras"},
            new Category() {CategoryId = 4, Nome= "mauses"},
            new Category() {CategoryId = 5, Nome= "Desktops"}
        };
        #endregion

        #region[Index]
        // GET: Categories
        public ActionResult Index()
        {
            return View(categories);
        }
        #endregion

        #region[Create]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            categories.Add(category);
            category.CategoryId = categories.Select(m => m.CategoryId).Max() + 1;
            return RedirectToAction("index");
        }
        #endregion

        #region [Edit]
        public ActionResult Edit(long Id)
        {
            return View(LoadCategory(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var idx = categories.IndexOf(LoadCategory(category.CategoryId));
            categories[idx] = category;
            return RedirectToAction("Index");


        }
        #endregion

        #region[Delete]
        public ActionResult Delete(long Id)
        {
            return View(LoadCategory(Id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category category)
        {
            var idx = categories.Remove(LoadCategory(category.CategoryId));
            return RedirectToAction("Index");
        }
        #endregion

        #region [Details]
        public ActionResult Details(long Id)
        {
            return View(LoadCategory(Id));
        }
        #endregion

        #region[Bank function]
        private Category LoadCategory(long categoryId)
        {
            return categories.Where(c => c.CategoryId == categoryId).First();
        }
        #endregion
    }
}