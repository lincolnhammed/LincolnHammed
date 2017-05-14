using System.Web.Mvc;
using System.Net;
using Models.Register;
using Service.Registration;
using Service.Tables;
using Service.Registers;

namespace LincolnHammed.Controllers
{
    public class ProductController : Controller
    {


        private ProductService productService = new ProductService();
        private CategoryService categoryService = new CategoryService();
        private SupplierService supplierService = new SupplierService();

        #region [Index]
        public ActionResult Index()
        {
            return View(productService.
           GetProductsOrderByForName());
        }
        #endregion

        #region[Edit]
        public ActionResult Edit(long? id)
        {
            PublicViewBag(productService.GetProductById((long)id));
            return GetViewProductById(id);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            return SaveProduct(product);
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
        public ActionResult Create(Product product)
        {
            return SaveProduct(product);
        }
        #endregion

        #region[ Delete]
        public ActionResult Delete(long? id)
        {
            return GetViewProductById(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Product product = productService.DeleteProductForId(id);
                TempData["Message"] = "Product " + product.Nome.ToUpper()
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
            return GetViewProductById(id);
        }
        #endregion

        #region[SaveProduct]
        private ActionResult SaveProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productService.SaveProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }
        #endregion

        #region[GetViewProductById] 
        private ActionResult GetViewProductById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Product product = productService.GetProductById((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        #endregion

        #region[PublicViewBag]
        private void PublicViewBag(Product product = null)
        {
            if (product == null)
            {
                ViewBag.CategoryId = new SelectList(categoryService.
                GetCategoriesOrderByName(),
                "CategoryId", "Nome");
                ViewBag.SupplierId = new SelectList(supplierService.
               GetSuppliersByForName(),
                "SupplierId", "Nome");
            }

            else
            {
                ViewBag.CategoryId = new SelectList(categoryService.
                GetCategoriesOrderByName(),
                "CategoryId", "Nome", product.CategoryId);
                ViewBag.SupplierId = new SelectList(supplierService.
               GetSuppliersByForName(),
                "SupplierId", "Nome", product.SupplierId);
            }

        }
        #endregion

        #region[comentario]
        /*
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
            Product product = context
                .Products
                .Where(p => p.ProductId == id)
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
        }*/
        #endregion
    }
}