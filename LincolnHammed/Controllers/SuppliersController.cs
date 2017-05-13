using Service.Registers;
using Service.Registration;
using Service.Tables;
using System.Net;
using System.Web.Mvc;
using Models.Register;
using Persistences.Contexts;
using System.Data.Entity;
using System.Linq;

namespace LincolnHammed.Controllers
{
    public class SuppliersController : Controller
    {
        #region[//]
        
        private ProductService productService = new ProductService();
        private CategoryService categoryService = new CategoryService();
        private SupplierService supplierService = new SupplierService();

        #region [Index]
        public ActionResult Index()
        {
            return View(supplierService.
           GetSuppliersByForName());
        }
        #endregion

        #region[Edit]
        public ActionResult Edit(long? id)
        {
            PublicViewBag(supplierService.GetSupplierById((long)id));
            return GetViewSupplierById(id);
        }

        [HttpPost]
        public ActionResult Edit(Supplier supplier)
        {
            return SaveSupplier(supplier);
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
        public ActionResult Create(Supplier supplier)
        {
            return SaveSupplier(supplier);
        }
        #endregion

        #region[ Delete]
        public ActionResult Delete(long? id)
        {
            return GetViewSupplierById(id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Supplier supplier = supplierService.DeleteSupplierForId(id);
                TempData["Message"] = "Product " + supplier.Nome.ToUpper()
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
            return GetViewSupplierById(id);
        }
        #endregion

        #region[SaveProduct]
        private ActionResult SaveSupplier(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    supplierService.SaveSupplier(supplier);
                    return RedirectToAction("Index");
                }
                return View(supplier);
            }
            catch
            {
                return View(supplier);
            }
        }
        #endregion

        #region[GetViewProductById] 
        private ActionResult GetViewSupplierById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Supplier supllier = supplierService.GetSupplierById((long)id);
            if (supllier == null)
            {
                return HttpNotFound();
            }
            return View(supllier);
        }
        #endregion

        #region[PublicViewBag]
        private void PublicViewBag(Supplier supplier = null)
        {
            if (supplier == null)
            {
                ViewBag.SupplierId = new SelectList(supplierService.
              GetSuppliersByForName(),
               "SupplierId", "Nome");


            }

            else
            {
                ViewBag.SupplierId = new SelectList(supplierService.
                GetSuppliersByForName(),
                "SupplierId", "Nome", supplier.SupplierId);
            }

        }
        #endregion
        
        #endregion[//]

        #region[comentario]
       /*
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
            var supplier= context.Suppliers.OrderBy(s => s.Nome);

            return View(supplier);
            
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
            context.Suppliers.Add(supplier);
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
            Supplier supplier = context.Suppliers.Find(id);
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
            Supplier supplier = context
                .Suppliers
                .Where(f => f.SupplierId == id)
                .Include("Products.Category")
                .First();

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

            Supplier supplier = context.Suppliers.Find(id);
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

            Supplier supplier = context.Suppliers.Find(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            TempData["Message"] = "Fabricante	"
                + supplier.Nome.ToUpper()
                + "	foi	removido";
            return RedirectToAction("Index");
        }



        #endregion


        #endregion
   */
        #endregion[cometario]
    }
}