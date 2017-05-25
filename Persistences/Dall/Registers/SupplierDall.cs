using Models.Register;
using Persistences.Contexts;
using System.Linq;
using System.Data.Entity;


namespace Persistences.Dall.Registers
{
    public class SupplierDall
    {


        private EFContext context = new EFContext();
        public IQueryable<Supplier>
        GetSupplierOrdereByName()
        {
            return context.Suppliers.OrderBy(b => b.Nome);
        }

        public Supplier GetSupplierForId(long id)
        {

            return context
                .Suppliers
                .Where(s => s.SupplierId == id)
                .Include("Products.Category")
                .First();
        }
        public void SaveSupplier(Supplier supplier)
        {
            if (supplier.SupplierId == null)
            {
                context.Suppliers.Add(supplier);
            }
            else
            {
                context.Entry(supplier).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Supplier DeleteSupplierForId(long id)
        {
            Supplier supplier = GetSupplierForId(id);
            context.Suppliers.Remove(supplier);
            context.SaveChanges();
            return supplier;
        }
    }


}

