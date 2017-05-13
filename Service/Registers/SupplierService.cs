using Models.Register;
using Persistences.Dall.Registers;
using System.Linq;

namespace Service.Registers
{
    public class SupplierService
    {
        private SupplierDall dal = new SupplierDall();
        public IQueryable<Supplier> GetSuppliersByForName()
        {
            return dal.GetSupplierOrdereByName();
        }
        public Supplier GetSupplierById(long id)
        {
            return dal.GetSupplierForId(id);
        }
        public void SaveSupplier(Supplier supplier)
        {
            dal.SaveSupplier(supplier);
        }
        public Supplier DeleteSupplierForId(long id)
        {
            return dal.DeleteSupplierForId(id);
        }
    }
}
