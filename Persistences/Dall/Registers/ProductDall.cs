

using Models.Register;
using Models.Tables;
using Persistences.Contexts;
using System.Linq;
using System.Data.Entity;
namespace Persistences.Dall.Registers
{

    public class ProductDall
    {
        private EFContext context = new EFContext();
        public IQueryable<Product> GetProductsOrdereByForName()
        {
            return context
                .Products
                .Include(c => c.Category)
                .Include(f => f.Supplier)
                .OrderBy(n => n.Nome);
        }
        public Product GetProductForId(long id)
        {
            return context
                .Products
                .Where(p => p.ProductId == id)
                .Include(c => c.Category)
                .Include(f => f.Supplier).First();
        }
        public void SaveProduct(Product product)
        {
            if (product.ProductId == null)
            {
                context.Products.Add(product);
            }
            else
            {
                context.Entry(product).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Product DeleteProductForId(long id)

        {
            Product product = GetProductForId(id);
            context.Products.Remove(product);
            context.SaveChanges();
            return product;
        }
    }
}




